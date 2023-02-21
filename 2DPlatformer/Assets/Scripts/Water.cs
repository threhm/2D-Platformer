using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    private BoxCollider2D boxCollider;
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
    }

    void Update()
    {
        mySpriteRenderer.enabled = BlueOrbsStatus.blueOrbsCollected;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerRespawn pr = other.GetComponent<PlayerRespawn>();
            if (pr != null)
            {
                pr.kill();
            }
        }
    }
}
