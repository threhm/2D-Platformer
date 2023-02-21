using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueOrbs : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BlueOrbsStatus.blueOrbsCollected = true;
        }

        Destroy(gameObject);
    }
}
