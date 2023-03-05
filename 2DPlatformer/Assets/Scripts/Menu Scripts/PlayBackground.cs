using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayBackground : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler
{
    public GameObject platform;
    GameObject leftPlatform;
    GameObject rightPlatform;
    private AudioSource myAudioSource;
    public AudioClip highlight_sound;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3 leftPos = new Vector3(transform.position.x - 1.9f, transform.position.y - 0.55f, transform.position.z);
        Vector3 rightPos = new Vector3(transform.position.x + 1.75f, transform.position.y - 0.55f, transform.position.z);
        leftPlatform = Instantiate(platform, leftPos, Quaternion.identity);
        rightPlatform = Instantiate(platform, rightPos, Quaternion.identity);
        myAudioSource.PlayOneShot(highlight_sound);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(leftPlatform);
        Destroy(rightPlatform);
    }

    public void OnSelect(BaseEventData eventData)
    {
        Destroy(leftPlatform);
        Destroy(rightPlatform);
    }

}
