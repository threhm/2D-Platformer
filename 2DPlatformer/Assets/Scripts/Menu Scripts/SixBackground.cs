using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SixBackground : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler
{
    public GameObject fire;
    GameObject fireObj;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3 firePos = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z);
        fireObj = Instantiate(fire, firePos, Quaternion.identity);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(fireObj);
    }

    public void OnSelect(BaseEventData eventData)
    {
        Destroy(fireObj);
    }
}