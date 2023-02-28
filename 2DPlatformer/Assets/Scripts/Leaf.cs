using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    SpriteRenderer sp;
    Rigidbody2D rg;
    PolygonCollider2D pc;

    public float fadingSpeed = 1.5f;
    public float fallingTimer = 2f;

    public GameObject player;
    BoxCollider2D playerCollider;

    public float downForce = 0.01f;
    bool fadingStarts = false;
    bool firstTime = true;

    private List<GameObject> leaves = new List<GameObject>();
    private List<SpriteRenderer> leafSprites = new List<SpriteRenderer>();

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        pc = GetComponent<PolygonCollider2D>();
        pc.isTrigger = true;

        sp = GetComponent<SpriteRenderer>();

        playerCollider = player.gameObject.GetComponent<BoxCollider2D>();

        // Disable parent leaf's rigidBody
        rg.bodyType = RigidbodyType2D.Static;

        // Collecting children gameObjects/components and initializing children rigidBody
        foreach (Transform child in transform)
        {
            if (child.gameObject.CompareTag("Leaf"))
            {
                leaves.Add(child.gameObject);
                leafSprites.Add(child.gameObject.GetComponent<SpriteRenderer>());

                child.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
        }
    }

    private void Update()
    {
        // Destory the leaves once they fade away
        if (sp.color.a <= 0.2f)
        {
            Destroy(gameObject);
        }

        // Checking if the children leaves collide with the player or not.
        // If so and the green orb is collected, start the leaves mechanics
        foreach (GameObject leaf in leaves)
        {
            if (OrbsStatus.getStatus("green") &&
                leaf.gameObject.GetComponent<PolygonCollider2D>().IsTouching(playerCollider) &&
                firstTime)
            {
                firstTime = false;
                StartCoroutine(LeafFalling());
            }
        }

        // If the leaves start to fall, makes the leaves fade away
        if (fadingStarts)
        {
            FadingEffects(fadingSpeed, sp);
            foreach (SpriteRenderer childSp in leafSprites)
            {
                FadingEffects(fadingSpeed, childSp);
            }
        }
    }

    /**
     * Create a delay before the leaves start to fall apart
     */
    private IEnumerator LeafFalling()
    {
        yield return new WaitForSeconds(fallingTimer);

        // When reached, start the fading visual effect
        fadingStarts = true;

        // When reached, create the falling physics
        rgUpdate(rg);
        foreach (GameObject leaf in leaves)
        {
            rgUpdate(leaf.gameObject.GetComponent<Rigidbody2D>());
        }
        
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
     * Create the fading away visual effect
     * @param {fadingTime} the speed objects are fading
     * @param {targetSpriteRenderer} the target sprite to apply the fading effect to
     */
    private void FadingEffects(float fadingTime, SpriteRenderer targetSpriteRenderer)
    {
        Color color = targetSpriteRenderer.color;
        color.a -= Time.deltaTime * fadingTime;
        targetSpriteRenderer.color = color;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // If collide with the player and the green orb is collected,
        // start the leaves mechanics
        if (OrbsStatus.getStatus("green") && col.gameObject.CompareTag("Player") && firstTime)
        {
            firstTime = false;
            StartCoroutine(LeafFalling());
        }
    }

}
