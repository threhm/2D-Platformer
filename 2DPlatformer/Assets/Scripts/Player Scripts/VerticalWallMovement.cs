using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalWallMovement : MonoBehaviour
{

    //Highest Y value the platform will move to
    public float topY;
    //Smallest Y value the platform will move to
    public float bottomY;
    //Speed of the platforms movement
    public float speed;
    //Is the platform currently moving up. Set to public so that we can edit if platforms initially move up or down
    public bool movingUp = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    //Move the platform up or down each update call if all the movement orbs have been collected
    void Update()
    {
        if (OrbsStatus.getStatus("moving0") &&
            OrbsStatus.getStatus("moving1") &&
            OrbsStatus.getStatus("moving2"))
        {
            Vector3 movement = new Vector3();
            if (movingUp)
            {
                if (transform.position.y < (topY))
                {
                    movement.y += speed;
                }
                else
                {
                    movingUp = false;
                }
            }
            else if (!movingUp)
            {
                if (transform.position.y > (bottomY))
                {
                    movement.y -= speed;
                }
                else
                {
                    movingUp = true;
                }
            }
            rb.velocity = new Vector2(movement.x, movement.y);
        }
    }
}