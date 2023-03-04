using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    SpriteRenderer sp;
    Rigidbody2D rg;
    public Sprite activeLeaf;

    public float fadingOutSpeed = 1.5f;
    public float fallingTimer = 2f;
    public float respawnTimer = 1f;

    public GameObject player;
    public GameObject leafPlatform;
    private Vector3 originalLoc;
    BoxCollider2D playerCollider;

    public float downForce = 0.1f;
    bool fadingStarts = false;
    bool fadingInFinished = false;
    bool fadingOutFinished = false;
    bool firstTime = true;
    bool spriteUnchanged = true;
    bool noRespawn = true;

    private List<Rigidbody2D> leavesRg = new List<Rigidbody2D>();
    private List<SpriteRenderer> leafSprites = new List<SpriteRenderer>();

    private GameObject box;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        StartCoroutine(RestoringColor(sp));

        playerCollider = player.gameObject.GetComponent<BoxCollider2D>();
        originalLoc = transform.position;

        // Disable parent leaf's rigidBody
        rg.bodyType = RigidbodyType2D.Static;

        // Collecting children gameObjects/components
        // initializing children rigidBody and sprites
        // initializing box collider
        foreach (Transform child in transform)
        {
            if (child.gameObject.CompareTag("Leaf"))
            {
                Rigidbody2D leafRg = child.gameObject.GetComponent<Rigidbody2D>();
                leafRg.bodyType = RigidbodyType2D.Static;
                leavesRg.Add(leafRg);

                SpriteRenderer leafSr = child.gameObject.GetComponent<SpriteRenderer>();
                leafSprites.Add(leafSr);
                StartCoroutine(RestoringColor(leafSr));

            } else if (child.gameObject.CompareTag("Box Collider"))
            {
                box = child.gameObject;
                boxCollider = child.gameObject.GetComponent<BoxCollider2D>();
                boxCollider.isTrigger = false;
                boxCollider.enabled = true;
            }
        }
    }

    private void Update()
    {
        if (OrbsStatus.getStatus("green") && spriteUnchanged)
        {
            spriteUnchanged = false;
            sp.sprite = activeLeaf;
            foreach (SpriteRenderer childSp in leafSprites)
            {
                childSp.sprite = activeLeaf;
            }
        }

        // Respawn the leaf platform after respawnTimer tiem once the old one fades away
        if (fadingOutFinished && noRespawn && fadingInFinished)
        {
            noRespawn = false;
            StartCoroutine(LeafRespawn());
        }

        // Checking if the children leavesRg collide with the player or not.
        // If so and the green orb is collected, start the leavesRg mechanics
        if (OrbsStatus.getStatus("green") && firstTime && boxCollider.IsTouching(playerCollider))
        {
            firstTime = false;
            StartCoroutine(LeafFalling());
        }

        // If the leavesRg start to fall, makes the leavesRg fade away
        if (fadingStarts)
        {
            fadingStarts = false;
            foreach (SpriteRenderer childSp in leafSprites)
            {
                StartCoroutine(FadingOut(childSp));
            }
            StartCoroutine(FadingOut(sp));
        }
    }

    /**
     * Create a delay before the leavesRg start to fall apart
     */
    private IEnumerator LeafFalling()
    {
        yield return new WaitForSeconds(fallingTimer);
        // Destory the box collider
        boxCollider.enabled = false;
        // When reached, start the fading visual effect
        fadingStarts = true;
        // When reached, create the falling physics
        rgUpdate(rg);
        foreach (Rigidbody2D leaf in leavesRg)
        {
            rgUpdate(leaf);
        }
        
    }

    /**
     * Respawn the platform after respawnTimer time
     */
    private IEnumerator LeafRespawn()
    {
        yield return new WaitForSeconds(respawnTimer);
        Instantiate(leafPlatform, originalLoc, Quaternion.identity);
        Destroy(gameObject);
    }

    /**
     * Enable rigidbody and give it gravity/extra force to have the falling effects
     * @param {rigidbody} the rigidbody to set
     */
    private void rgUpdate(Rigidbody2D rigidbody)
    {
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        rigidbody.WakeUp();
        rigidbody.AddForce(Random.insideUnitCircle * downForce);
        rigidbody.gravityScale = 1;
    }

    /**
     * Create the fading in visual effect
     * @param {targetSpriteRenderer} the target sprite to apply the fading in effect to
     */
    private IEnumerator FadingOut(SpriteRenderer targetSpriteRenderer)
    {
        Color color = targetSpriteRenderer.color;
        for (float a = 1f; a >= 0f; a -= 0.001f)
        {
            color.a = a;
            targetSpriteRenderer.color = color;
            yield return new WaitForEndOfFrameUnit();
        }
        fadingOutFinished = true;
    }


    /**
     * Create the fading in visual effect
     * @param {targetSpriteRenderer} the target sprite to apply the fading in effect to
     */
    private IEnumerator RestoringColor(SpriteRenderer targetSpriteRenderer)
    {
        Color color = targetSpriteRenderer.color;
        for (float a = 0.1f; a <= 1f; a += 0.001f)
        {
            color.a = a;
            targetSpriteRenderer.color = color;
            yield return new WaitForEndOfFrameUnit();
        }
        fadingInFinished = true;
    }

}
