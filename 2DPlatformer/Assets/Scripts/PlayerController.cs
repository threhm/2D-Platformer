using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpHeight;
    public float baseSpeed;
    public float wallJumpHeight;
    private float speedToUse;

    public bool doubleJump;

    public LayerMask groundMask;


    public Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        doubleJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Create the new movement vector
        Vector3 movement = new Vector3();

        //Set the current movement to be what the player currently has
        movement.x = rb2d.velocity.x;
        movement.y = rb2d.velocity.y;

        //Handle the player jumping
        if(Input.GetKeyDown(KeyCode.Space)) {
            //Jump if on the ground. This is done through raycasting downwards with a bitmask set to only hit the ground layer.
            //We must to two raycasts here in case on leg is on a platform and the other isn't, this way we jump if either leg is touching a platform
            Vector2 position1 = new Vector2(transform.position.x + 0.5f, transform.position.y);
            Vector2 position2 = new Vector2(transform.position.x - 0.5f, transform.position.y);
            if (Physics2D.Raycast(position1, Vector3.down, 1.1f, groundMask) || Physics2D.Raycast(position2, Vector3.down, 1.1f, groundMask)) {
                movement.y = jumpHeight;  
            } else {

                //Jump if touching a wall. This is done in an else statement because the height from jumping off the ground should take priority
                Vector2 position3 = new Vector2(transform.position.x, transform.position.y + 1);
                Vector2 position4 = new Vector2(transform.position.x, transform.position.y - 1);
                if (Physics2D.Raycast(position3, Vector3.left, 1.1f, groundMask) || Physics2D.Raycast(position4, Vector3.left, 1.1f, groundMask) ||
                    Physics2D.Raycast(position3, Vector3.right, 1.1f, groundMask) || Physics2D.Raycast(position4, Vector3.right, 1.1f, groundMask)) {
                    movement.y = wallJumpHeight;  
                }
            }
        }

        //Handle the player sprinting or not
        if(Input.GetKey(KeyCode.LeftShift)) {
            speedToUse = baseSpeed * 3;
        } else {
            speedToUse = baseSpeed;
        }
        //Handle the player moving left and right
        if(Input.GetKey(KeyCode.LeftArrow)) {
            movement.x = -speedToUse;
        }
        else if(Input.GetKey(KeyCode.RightArrow)) {
            movement.x = speedToUse;
        }
        else {
            movement.x = 0;
        }
        rb2d.velocity = new Vector2(movement.x, movement.y);
    }
}
