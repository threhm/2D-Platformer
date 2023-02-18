using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    private BoxCollider2D bc2D;
    // Start is called before the first frame update
    void Start()
    {
        bc2D = gameObject.GetComponent<BoxCollider2D>();
        bc2D.isTrigger = true;
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            PlayerRespawn pr = other.GetComponent<PlayerRespawn>();
            if(pr != null) {
                pr.respawnPoint = this.gameObject;
            }
        }
    }
}
