using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheMovingOrb01 : OrbsMechanics
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        base.orbOnCollision(collision, "moving1");
    }
}
