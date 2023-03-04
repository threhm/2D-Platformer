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
        sr = gameObject.GetComponent<SpriteRenderer>();

        bc2D.isTrigger = true;
    }

    //Once we collect the purple orb the reverse gravity should become active, otherwise it should be deactive
    void Update()
    {
        if (OrbsStatus.getStatus("purple") && spriteUnchanged)
        {
            spriteUnchanged = false;
            sr.sprite = activeReverseGravity;
        }
    }

    //When the player enters the reverse grav field we want to set the player's reverse
    //grav bool to be true and reverse the gravity on the player
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") && OrbsStatus.getStatus("purple")) {
            PlayerController pc = other.gameObject.GetComponent<PlayerController>();
            if(pc != null) {
                pc.reverseGrav = true;
                other.gameObject.GetComponent<Rigidbody2D>().gravityScale = -8;
            }
        }
    }

    //When the player exits the reverse grav field we want to set the player's reverse
    //grav bool to false and set their gravity back to normal
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
