using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalWallMovement : MonoBehaviour
{
    public float topX;
    public float bottomX;

    public float speed;
    public bool movingLeft = false;
    private Rigidbody2D rb;
    private GameObject player;
    private bool movePlayer;

    SpriteRenderer spriteRenderer;
    public Sprite deactiveHWall;
    public Sprite activeHWall;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        movePlayer = false;
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (OrbsStatus.getStatus("moving0") &&
            OrbsStatus.getStatus("moving1") &&
            OrbsStatus.getStatus("moving2"))
        {
            spriteRenderer.sprite = activeHWall;
            //Vector3 movement = new Vector3();
            float positionX = transform.position.x;
            if (movingLeft)
            {
                if (positionX < (topX))
                {
                    positionX += speed;
                }
                else
                {
                    movingLeft = false;
                }
            }
            else if (!movingLeft)
            {
                if (positionX > (bottomX))
                {
                    positionX -= speed;
                }
                else
                {
                    movingLeft = true;
                }
            }

            if (movePlayer)
            {
                if (movingLeft)
                {
                    player.transform.position = new Vector2(player.transform.position.x + speed, player.transform.position.y);
                }
                else
                {
                    player.transform.position = new Vector2(player.transform.position.x - speed, player.transform.position.y);
                }
            }
            this.transform.position = new Vector2(positionX, transform.position.y);
            rb.velocity = new Vector2(0, 0);
        }
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            player = other.gameObject;
            movePlayer = true;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            movePlayer = false;
        }
    }
}
