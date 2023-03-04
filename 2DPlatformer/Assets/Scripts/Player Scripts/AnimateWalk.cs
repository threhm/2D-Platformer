using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class AnimateWalk : MonoBehaviour
{
    private SpriteRenderer sr;
    private PlayerRespawn respawning;
    private int frameIndex;
    public Sprite[] frames;
    public Sprite[] deathFrames;
    public float fps = 3;
    //a slighly slower speed for dying for more dramatic effect
    public float deathfps = 1;
    private float sliderTimer;
    //variables specifically for dying
    //a living check was needed so that all functions could be properly frozen across different scripts
    [NonSerialized] public bool isAlive;
    [NonSerialized] public int deathFrameIndex;
    private float deathTimer;

    //need velocities to tell when to change animations
    public Sprite standingSprite;
    public Sprite jumpSprite;
    public Sprite wallSprite;
    public Sprite fallSprite;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        respawning = gameObject.GetComponent<PlayerRespawn>();
        sliderTimer = (1f / fps);
        frameIndex = 0;
        deathTimer = (1f / deathfps);
        deathFrameIndex = 0;
        isAlive = true;
    }

    //method that dictates when to play animations using variables from the movement script
    public void playerAnim(int dFacing, bool grounded, bool walled, float airtime, bool notMoving, bool zeroG)
    {
        if (isAlive)
        {
            //direction to face
            sr.flipX = dFacing < 0;
            sr.flipY = zeroG;
            //basic walk and movement
            if (grounded)
            {
                //uses the walk cycle unless standing still, the idle pose is only one frame currently
                if (!notMoving)
                {
                    sliderTimer -= Time.deltaTime;
                    if (sliderTimer <= 0)
                    {
                        frameIndex++;
                        if (frameIndex >= frames.Length) { frameIndex = 0; }

                        sliderTimer = (1f / fps);
                        sr.sprite = frames[frameIndex];
                    }
                }
                else { sr.sprite = standingSprite; }
            }
            else
            {
                //wall jump sprite needs to face opposite of wall
                if (walled)
                {
                    sr.flipX = !(dFacing < 0);
                    sr.sprite = wallSprite;
                }
                //jumping and falling not exactly 0 to adjust for float velocity calculations
                else
                {
                    if (airtime > 0.1) { sr.sprite = jumpSprite; }
                    if (airtime < 0.1) { sr.sprite = fallSprite; }
                }
            }
        }
        else
        {
            //controls dying using attachment to player respawn script
            isAlive = false;
            deathTimer -= Time.deltaTime;
            if (deathTimer <= 0)
            {
                deathFrameIndex++;

                if (deathFrameIndex >= deathFrames.Length)
                {
                    //need to go back to kill after all this
                    respawning.kill();
                    return;
                }
                deathTimer = (1f / deathfps);
                sr.sprite = deathFrames[deathFrameIndex];
            }
        }
    }

    

}
