
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private PolygonCollider2D pc;
    SpriteRenderer mySpriteRenderer;
    public Sprite deactiveSpike;
    public Sprite activeSpike;

    private AudioSource source;
    public AudioClip[] clip;

    void Start()
    {
        pc = gameObject.GetComponent<PolygonCollider2D>();
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();

        pc.isTrigger = true;
        
    }


    //If the player touches the spike we should kill them and play the death by spike sound
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            PlayerRespawn pr = other.GetComponent<PlayerRespawn>();
            
            if (pr != null && OrbsStatus.getStatus("spike"))
            {
                pr.kill();
                playDeathSound();
            }
        }
    }

    // If we have collected the spike orb then the spike should look active, otherwise they should look deactive
    void Update()
    {
        if (OrbsStatus.getStatus("spike"))
        {
            mySpriteRenderer.sprite = activeSpike;
        }
        else
        {
            mySpriteRenderer.sprite = deactiveSpike;
        }
    }

    //Plays a random death sound from the clip array
    void playDeathSound() {
        int length = clip.Length;
        int clipToPlay = Random.Range(0,length);
        source.PlayOneShot(clip[clipToPlay]);
    }

   
}

