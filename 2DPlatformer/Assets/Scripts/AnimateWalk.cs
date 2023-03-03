using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class AnimateWalk : MonoBehaviour
{
    private SpriteRenderer sr;
    private int frameIndex;
    public Sprite[] frames;
    public float fps = 3;
    private float sliderTimer;
    //need velocities to tell when to change animations
    public Sprite standingSprite;
    public Sprite jumpSprite;
    public Sprite wallSprite;
    public Sprite fallSprite;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sliderTimer = (1f / fps);
        frameIndex = 0;
    }

    public void playerAnim(int dFacing, bool grounded, bool walled, float airtime, bool notMoving, bool zeroG)
    {
        sr.flipX = dFacing < 0;
        sr.flipY = zeroG;

        if (grounded) {
            if (!notMoving) {
                //sr.flipX = true;
                sliderTimer -= Time.deltaTime;
                if (sliderTimer <= 0)
                {
                    frameIndex++;
                    if (frameIndex >= frames.Length) { frameIndex = 0; }

                    sliderTimer = (1f / fps);
                    sr.sprite = frames[frameIndex];
                }
            }
            else { sr.sprite = standingSprite;}
        } 
        else{
            if (walled)
            {
                sr.flipX = !(dFacing < 0);
                sr.sprite = wallSprite;
            }
            else
            {
                if (airtime > 0.1) { sr.sprite = jumpSprite; }
                if (airtime < 0.1) { sr.sprite = fallSprite; }
            }
        }
    }
}
