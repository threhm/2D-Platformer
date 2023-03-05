using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlatformEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler
{
    public GameObject platform;
    public float xLeftOffset;
    public float xRightOffset;
    public float yOffset;
    GameObject leftPlatform;
    GameObject rightPlatform;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3 leftPos = new Vector3(transform.position.x - xLeftOffset, transform.position.y + yOffset, transform.position.z);
        Vector3 rightPos = new Vector3(transform.position.x + xRightOffset, transform.position.y + yOffset, transform.position.z);
        leftPlatform = Instantiate(platform, leftPos, Quaternion.identity);
        rightPlatform = Instantiate(platform, rightPos, Quaternion.identity);
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