using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbsMechanics : MonoBehaviour
{
    public void orbOnCollision(Collision2D collision, string OrbColor)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OrbsStatus.active(OrbColor);
        }

        Destroy(gameObject);
    }
}
