using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredOrb : OrbsMechanics
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        base.orbOnCollision(collision, "Spike");
    }
}
