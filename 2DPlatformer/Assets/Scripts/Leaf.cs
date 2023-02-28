using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    //bool falling = false;
    
    
    public float downForce = 0.01f;
    bool firstTime = true;
    SpriteRenderer sp;
    Rigidbody2D rg;
    PolygonCollider2D pc;


    float fadingTimer = 2f;
    float fallingTimer = 2f;
    public GameObject player;
    BoxCollider2D playerCollider;

    bool fadingStarts = false;

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
        foreach (GameObject leaf in leaves)
        {
            if (leaf.gameObject.GetComponent<PolygonCollider2D>().IsTouching(playerCollider) && firstTime)
            {
                firstTime = false;
                StartCoroutine(LeafFalling());
            }
        }

        if (fadingStarts)
        {
            FadingEffects(fadingTimer, sp);
            foreach (SpriteRenderer childSp in leafSprites)
            {
                FadingEffects(fadingTimer, childSp);
            }
        }
    }

    private IEnumerator LeafFalling()
    {
        yield return new WaitForSeconds(fallingTimer);
        fadingStarts = true;

        Destroy(gameObject, fadingTimer);
        rgUpdate(rg);
        foreach (GameObject leaf in leaves)
        {
            rgUpdate(leaf.gameObject.GetComponent<Rigidbody2D>());
        }
        
    }

    private void rgUpdate(Rigidbody2D rigidbody)
    {
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        rigidbody.WakeUp();
        rigidbody.AddForce(Random.insideUnitCircle * downForce);
        rigidbody.gravityScale = 1;
    }

    private void FadingEffects(float fadingTime, SpriteRenderer targetSpriteRenderer)
    {
        Color color = targetSpriteRenderer.color;
        color.a -= Time.deltaTime * fadingTime;
        targetSpriteRenderer.color = color;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && firstTime)
        {
            firstTime = false;
            StartCoroutine(LeafFalling());
        }
    }

}
