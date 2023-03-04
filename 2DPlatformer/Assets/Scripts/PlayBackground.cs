using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayBackground : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite playSprite;
    public Sprite originalSprite;

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.parent.parent.GetComponent<Image>().sprite = playSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.parent.parent.GetComponent<Image>().sprite = originalSprite;
    }

}
