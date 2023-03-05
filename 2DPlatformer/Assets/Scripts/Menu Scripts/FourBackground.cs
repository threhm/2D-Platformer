using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FourBackground : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject water;
    GameObject waterObj;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3 waterPos = new Vector3(transform.position.x, transform.position.y + 1.1f, transform.position.z);
        waterObj = Instantiate(water, waterPos, Quaternion.identity);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(waterObj);
    }

    public void OnSelect(BaseEventData eventData)
    {
        Destroy(waterObj);
    }
}