using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateWalk : MonoBehaviour
{
     private SpriteRenderer sr;
    private int frameIndex;
    public Sprite[] frames;
    public float fps = 3;
    private float sliderTimer;

    public Sprite standingSprite;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sliderTimer = (1f / fps);
        frameIndex = 0;
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftArrow)) {
            sr.flipX = true;
            sliderTimer -= Time.deltaTime;
            if (sliderTimer <= 0)
            {
                frameIndex++;
                if (frameIndex >= frames.Length) { frameIndex = 0; }

                sliderTimer = (1f / fps);
                sr.sprite = frames[frameIndex];
            }
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            sr.flipX = false;
            sliderTimer -= Time.deltaTime;
            if (sliderTimer <= 0)
            {
                frameIndex++;
                if (frameIndex >= frames.Length) { frameIndex = 0; }

                sliderTimer = (1f / fps);
                sr.sprite = frames[frameIndex];
            }
        } else {
            sr.sprite = standingSprite;
        }
    }
}
