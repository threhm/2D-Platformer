using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ThreeBackground : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler
{
    public GameObject gravity;
    GameObject gravityObj;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3 gravityPos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        gravityObj = Instantiate(gravity, gravityPos, Quaternion.identity);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(gravityObj);
    }

    public void OnSelect(BaseEventData eventData)
    {
        Destroy(gravityObj);
    }
}