using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    private BoxCollider2D bc2D;
    public SpriteRenderer sr;
    public Sprite active;
    public Sprite inactive;

    public bool isActive;

    private RespawnController otherRespawn;
    // Start is called before the first frame update
    void Start()
    {
        bc2D = gameObject.GetComponent<BoxCollider2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        bc2D.isTrigger = true;
        isActive = false;
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            PlayerRespawn pr = other.GetComponent<PlayerRespawn>();
            //If the player has yet to touch a respawn point set this one to be the currently active one
            if(pr.respawnPoint == null) {
                pr.respawnPoint = this.gameObject;
                SwitchSprite();
            } else {
                //Check to see if the currently active respawn point is this point, if it is do nothing
                //otherwise set this to be the new active point
                otherRespawn = pr.respawnPoint.gameObject.GetComponent<RespawnController>();
                if(otherRespawn.gameObject != this.gameObject) {
                    otherRespawn.SwitchSprite();
                    pr.respawnPoint = this.gameObject;
                    SwitchSprite();
                }
            }
        }
    }

    public void SwitchSprite() {
        if(isActive) {
            isActive = false;
            sr.sprite = inactive;
        } else {
            isActive = true;
            sr.sprite = active;
        }
    }
}
