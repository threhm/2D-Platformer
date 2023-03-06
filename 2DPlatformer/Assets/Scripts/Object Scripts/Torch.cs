using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Torch : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    public Sprite[] torchSprites;
    private bool animationBegin = true;
    public float TorchSpeedTimer = 0.1f;

    public AudioClip torchLighting;
    private AudioSource myAudioSource;
    public float volume = 0.5f;
    private bool playSound = true;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.volume = volume;
        myAudioSource.clip = torchLighting;
        myAudioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (OrbsStatus.getStatus("red") && playSound)
        {
            playSound = false;
            myAudioSource.Play();
        }
        if (OrbsStatus.getStatus("red") && animationBegin)
        {
            animationBegin = false;
            StartCoroutine(FireAnimation());
        }
        
        transform.GetChild(0).gameObject.SetActive(OrbsStatus.getStatus("red"));
    }

    private IEnumerator FireAnimation()
    {
        foreach (Sprite torchSprite in torchSprites)
        {
            mySpriteRenderer.sprite = torchSprite;
            yield return new WaitForSeconds(TorchSpeedTimer);
        }
        animationBegin = true;
    }
}
