using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelSelectBackground : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler
{
    public Sprite levelSelectSprite;
    public Sprite originalSprite;

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.parent.parent.GetComponent<Image>().sprite = levelSelectSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.parent.parent.GetComponent<Image>().sprite = originalSprite;
    }

    public void OnSelect(BaseEventData eventData)
    {
        transform.parent.parent.GetComponent<Image>().sprite = originalSprite;
    }

}
