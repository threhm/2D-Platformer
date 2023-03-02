using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalWallMovement : MonoBehaviour
{

    //public float topX;
    public float topY;
    //public float bottomX;
    public float bottomY;

    public float speed;
    public bool movingUp = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OrbsStatus.getStatus("moving"))
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