using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheRedOrb : OrbsMechanics
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        base.orbOnCollision(collision, "red");
    }
}
