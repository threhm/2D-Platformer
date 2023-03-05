using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TwoBackground : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler
{
    public GameObject moving;
    GameObject movingObj;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3 movingPos = new Vector3(transform.position.x + 0.01f, transform.position.y + 1f, transform.position.z);
        movingObj = Instantiate(moving, movingPos, Quaternion.identity);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(movingObj);
    }

    public void OnSelect(BaseEventData eventData)
    {
        Destroy(movingObj);
    }
}
