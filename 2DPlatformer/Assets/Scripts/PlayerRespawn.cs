using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject respawnPoint;
    private Rigidbody2D rb2D;

    void Start() {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    public void kill() {
        rb2D.transform.position = respawnPoint.transform.position;
    }
}
