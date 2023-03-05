using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightSoundEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isLoop;
    private AudioSource myAudioSource;
    public AudioClip highlight_sound;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.clip = highlight_sound;
        myAudioSource.loop = isLoop;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        myAudioSource.clip = highlight_sound;
        myAudioSource.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myAudioSource.Stop();
        myAudioSource.clip = null;
    }
}
