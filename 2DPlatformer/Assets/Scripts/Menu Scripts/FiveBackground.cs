using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FiveBackground : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler
{
    public GameObject leaf;
    GameObject leafObj;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3 leafPos = new Vector3(transform.position.x + 0.1f, transform.position.y + 0.8f, transform.position.z);
        leafObj = Instantiate(leaf, leafPos, Quaternion.identity);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(leafObj);
    }

    public void OnSelect(BaseEventData eventData)
    {
        Destroy(leafObj);
    }
}