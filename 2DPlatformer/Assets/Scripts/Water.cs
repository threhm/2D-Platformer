using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    private BoxCollider2D boxCollider;
    public Sprite activeWater;
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = false;
        boxCollider.enabled = false;
    }

    void Update()
    {
        if (OrbsStatus.getStatus("blue"))
        {
            mySpriteRenderer.sprite = activeWater;
        }
        boxCollider.isTrigger = OrbsStatus.getStatus("blue");
        boxCollider.enabled = OrbsStatus.getStatus("blue");
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
