using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private PolygonCollider2D pc;
    public SpriteRenderer mySpriteRenderer;

    void Start()
    {
        pc = gameObject.GetComponent<PolygonCollider2D>();
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        pc.isTrigger = true;
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            PlayerRespawn pr = other.GetComponent<PlayerRespawn>();
            
            if (pr != null && OrbsStatus.getStatus("spike"))
            {
                pr.kill();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (OrbsStatus.getStatus("spike"))
        {
            
        }
    }

   
}

