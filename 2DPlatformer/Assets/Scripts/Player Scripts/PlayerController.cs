using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //player parameters
    public float jumpHeight;
    public float maxSpeed;
    public float horizontalAcceleration;
    public float wallJumpHeight;
    private AnimateWalk spriteAnim;
    public float wallJumpPush;

    //variables connected to movement types
    private int facing = 1;
    private bool onGround;
    private bool onWall = false;

    public bool doubleJump;

    public LayerMask groundMask;

    //outside forces that act on player
    public bool reverseGrav;

    public GameObject spike;

    private AudioSource source;
    public AudioClip basicJumpClip;


    public Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        
        doubleJump = true;
        reverseGrav = false;
        spriteAnim = gameObject.GetComponent<AnimateWalk>();
        source = GetComponent<AudioSource>();
        source.volume = 0.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Check if the player is currently on the ground
        onGround = false;
        Vector2 position1 = new Vector2(transform.position.x + 0.45f, transform.position.y);
        Vector2 position2 = new Vector2(transform.position.x - 0.45f, transform.position.y);
        if(!reverseGrav) {
            if (Physics2D.Raycast(position1, Vector3.down, 1.5f, groundMask) || Physics2D.Raycast(position2, Vector3.down, 1.5f, groundMask)) {
                onGround = true;
            }
        } else {
            if (Physics2D.Raycast(position1, Vector3.up, 1.5f, groundMask) || Physics2D.Raycast(position2, Vector3.up, 1.5f, groundMask)) {
                onGround = true;
            }
        }

        if (rb2d.velocity.x > 0 && facing == -1) {
            facing = 1;
        }
        else if (rb2d.velocity.x < 0 && facing == 1) {
            facing = -1;
        }

        //Handle the player moving left and right, needed to add a living check to use for the death animation
        if (Input.GetKey(KeyCode.LeftArrow) && spriteAnim.isAlive) {
            if(rb2d.velocity.x > 0 && onGround) {
                Vector2 newVelocity = new Vector2(0, rb2d.velocity.y);
                rb2d.velocity = newVelocity;
            }
            if(rb2d.velocity.x > -maxSpeed) {
                rb2d.AddForce(new Vector3(-horizontalAcceleration, 0f, 0f), ForceMode2D.Impulse);
            }
        }
        else if(Input.GetKey(KeyCode.RightArrow) && spriteAnim.isAlive) {
            if(rb2d.velocity.x < 0 && onGround) {
                Vector2 newVelocity = new Vector2(0, rb2d.velocity.y);
                rb2d.velocity = newVelocity;
            }
            if(rb2d.velocity.x < maxSpeed) {
                rb2d.AddForce(new Vector3(horizontalAcceleration, 0f, 0f), ForceMode2D.Impulse);
            }
        }
        else if (onGround) {
            Vector2 newVelocity = new Vector2(0, rb2d.velocity.y);
            rb2d.velocity = newVelocity;
        }

    }

    void Update() {
        //Handle the player jumping
        onWall= false;
        if(Input.GetKeyDown(KeyCode.Space) && spriteAnim.isAlive) {
            Vector2 position1 = new Vector2(transform.position.x + 0.4f, transform.position.y);
            Vector2 position2 = new Vector2(transform.position.x - 0.4f, transform.position.y);
            if(!reverseGrav) {
                if (Physics2D.Raycast(position1, Vector3.down, 1.5f, groundMask) || Physics2D.Raycast(position2, Vector3.down, 1.5f, groundMask)) { 
                    rb2d.AddForce(new Vector3(0f, jumpHeight, 0f), ForceMode2D.Impulse);
                    playBasicJump();
                } else {
                    //Jump if touching a wall. This is done in an else statement because the height from jumping off the ground should take priority
                    Vector2 position3 = new Vector2(transform.position.x, transform.position.y + 1);
                    Vector2 position4 = new Vector2(transform.position.x, transform.position.y - 1);

                    //Check if jumping off of a wall on the left
                    if (Physics2D.Raycast(position3, Vector3.left, 1.5f, groundMask) || Physics2D.Raycast(position4, Vector3.left, 1.5f, groundMask)) {
                        rb2d.AddForce(new Vector3(wallJumpPush, wallJumpHeight, 0f), ForceMode2D.Impulse);
                    } // Otherwise check if we are jumping off a wall on the right
                    else if (Physics2D.Raycast(position3, Vector3.right, 1.5f, groundMask) || Physics2D.Raycast(position4, Vector3.right, 1.5f, groundMask)) {
                        rb2d.AddForce(new Vector3(-wallJumpPush, wallJumpHeight, 0f), ForceMode2D.Impulse);
                    }
                }
            } else {
                if (Physics2D.Raycast(position1, Vector3.up, 1.5f, groundMask) || Physics2D.Raycast(position2, Vector3.up, 1.5f, groundMask)) { 
                    rb2d.AddForce(new Vector3(0f, -jumpHeight, 0f), ForceMode2D.Impulse);
                    playBasicJump();
                } else {
                    //Jump if touching a wall. This is done in an else statement because the height from jumping off the ground should take priority
                    Vector2 position3 = new Vector2(transform.position.x, transform.position.y + 1);
                    Vector2 position4 = new Vector2(transform.position.x, transform.position.y - 1);

                    //Check if jumping off of a wall on the left
                    if (Physics2D.Raycast(position3, Vector3.left, 1.5f, groundMask) || Physics2D.Raycast(position4, Vector3.left, 1.5f, groundMask)) {
                        rb2d.AddForce(new Vector3(wallJumpPush, -wallJumpHeight, 0f), ForceMode2D.Impulse);
                    } // Otherwise check if we are jumping off a wall on the right
                    else if (Physics2D.Raycast(position3, Vector3.right, 1.5f, groundMask) || Physics2D.Raycast(position4, Vector3.right, 1.5f, groundMask)) {
                        rb2d.AddForce(new Vector3(-wallJumpPush, -wallJumpHeight, 0f), ForceMode2D.Impulse);
                    }
                }
            }
        }
        //a collection of the various wall catches to determine whenever the player is on the wall. It's then stored in a boolean to be used for the animator
        Vector2 wallCheck3 = new Vector2(transform.position.x, transform.position.y + 1);
        Vector2 wallCheck4 = new Vector2(transform.position.x, transform.position.y - 1);
        if (Physics2D.Raycast(wallCheck3, Vector3.left, 1.5f, groundMask) || Physics2D.Raycast(wallCheck4, Vector3.left, 1.5f, groundMask) ||
            Physics2D.Raycast(wallCheck3, Vector3.right, 1.5f, groundMask) || Physics2D.Raycast(wallCheck4, Vector3.right, 1.5f, groundMask)) {onWall = true;}
        else {onWall= false;}
        //information to be sent to the animator so that it knows what to animate and when
            spriteAnim.playerAnim(facing, onGround, onWall, rb2d.velocity.y, rb2d.velocity.x == 0, reverseGrav);
    }

    void playBasicJump() {
        source.PlayOneShot(basicJumpClip);
    }

    



}
