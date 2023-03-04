using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuitBackground : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite quitSprite;
    public Sprite originalSprite;

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.parent.parent.GetComponent<Image>().sprite = quitSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.parent.parent.GetComponent<Image>().sprite = originalSprite;
    }

}
