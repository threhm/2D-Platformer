using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject respawnPoint;
    private Rigidbody2D rb2D;
    private AnimateWalk spriteAnim;
    private Collider2D mcol;
    void Start() {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        spriteAnim = gameObject.GetComponent<AnimateWalk>();
        mcol= gameObject.GetComponent<Collider2D>();
    }

    //respawns the player when they die using whatever the currently active respawn point is
    public void kill()
    {
        //need to recognize player as dead first to let the controller know, then the controller comes back here later with animations
        //additionally we have to prep for death by making sure nothing can move the player at all while dying
        spriteAnim.isAlive = false;
        mcol.enabled=false;
        rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
        if (spriteAnim.deathFrameIndex >= spriteAnim.deathFrames.Length)
        {
            //reset the variables
            mcol.enabled=true;
            rb2D.constraints = RigidbodyConstraints2D.None;
            rb2D.transform.position = respawnPoint.transform.position;
            spriteAnim.isAlive = true;
            spriteAnim.deathFrameIndex = 0;
        }
    }
}
