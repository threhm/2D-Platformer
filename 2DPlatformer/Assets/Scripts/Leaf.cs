using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    //bool falling = false;
    
    Rigidbody2D rg;
    PolygonCollider2D pc;
    public float downForce = 10f;
    bool firstTime = true;
    //SpriteRenderer sp;
    float fadingTimer = 2f;
    float fallingTimer = 5f;

    private List<GameObject> leaves = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        pc = GetComponent<PolygonCollider2D>();
        //sp.GetComponent<SpriteRenderer>();
        rg.bodyType = RigidbodyType2D.Static;
        foreach (Transform child in transform)
        {
            if (child.gameObject.CompareTag("Leaf"))
            {
                leaves.Add(child.gameObject);
            }
        }
    }

    private IEnumerator LeafFalling()
    {
        Debug.Log("Coroutine starts");
        yield return new WaitForSeconds(fallingTimer);
        Debug.Log("Coroutine ends");
        rg.bodyType = RigidbodyType2D.Dynamic;
        rg.WakeUp();
        rg.AddForce(Random.insideUnitCircle * 5);
        rg.gravityScale = 5;
        rg.mass = 10;
        //FadingEffects(fadingTimer);
        //Destroy(gameObject, fadingTimer);
        
    }

    //private void FadingEffects(float fadingTime)
    //{
    //    Color color = sp.color;
    //    color.a -= Time.deltaTime * fadingTime;
    //    sp.color = color;
    //}

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.CompareTag("Player") && firstTime)
        {
            firstTime = false;
            StartCoroutine(LeafFalling());
        }
    }

}
