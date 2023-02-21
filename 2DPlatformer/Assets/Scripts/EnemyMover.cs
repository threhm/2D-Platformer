using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float X1;
    public float X2;
    public float Y1;
    public float Y2;
    private float xDist;
    private float yDist;

    public float speed;
    public bool destination1 = false;
    private Rigidbody2D rb;
    private GameObject player;
    private bool movePlayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        movePlayer = false;
        xDist = Mathf.Abs(X1 - X2) / speed;
        yDist = Mathf.Abs(Y1 - Y2) / speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 movement = new Vector3();
        float positionX = transform.position.x;
        float positionY = transform.position.y;
        if(destination1) {
            if(positionX < (X1)) {
                positionX += xDist;
                positionY += yDist;
            } else {
                destination1 = false;
            }
        } else if (!destination1) {
            if(positionX > (X2)) {
                positionX -= xDist;
                positionY -= yDist;
            } else {
                destination1 = true;
            }
        }
        this.transform.position = new Vector2(positionX, positionY);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerRespawn>().kill();
        }
    }
}
