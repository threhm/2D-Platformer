using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseGravity : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2D;
    private BoxCollider2D bc2D;
    private SpriteRenderer sr;
    public Sprite activeReverseGravity;
    private bool spriteUnchanged = true;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        bc2D = gameObject.GetComponent<BoxCollider2D>();
        bc2D.isTrigger = true;
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (OrbsStatus.getStatus("purple") && spriteUnchanged)
        {
            spriteUnchanged = false;
            sr.sprite = activeReverseGravity;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") && OrbsStatus.getStatus("purple")) {
            PlayerController pc = other.gameObject.GetComponent<PlayerController>();
            if(pc != null) {
                pc.reverseGrav = true;
                other.gameObject.GetComponent<Rigidbody2D>().gravityScale = -8;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") && OrbsStatus.getStatus("purple")) {
            PlayerController pc = other.gameObject.GetComponent<PlayerController>();
            if(pc != null) {
                pc.reverseGrav = false;
                other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            }
        }
    }
}
