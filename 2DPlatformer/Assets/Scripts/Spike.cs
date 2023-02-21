using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private PolygonCollider2D pc;
    public bool color = false;
    void Start()
    {
        pc = gameObject.GetComponent<PolygonCollider2D>();
        pc.isTrigger = true;
    }


    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            PlayerRespawn pr = other.GetComponent<PlayerRespawn>();
        
            if (pr != null && color == true)
            {
                pr.kill();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
