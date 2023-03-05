using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OneBackground : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler
{
    public GameObject spike;
    GameObject spikeObj;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3 spikePos = new Vector3(transform.position.x, transform.position.y + 0.9f, transform.position.z);
        spikeObj = Instantiate(spike, spikePos, Quaternion.identity);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(spikeObj);
    }

    public void OnSelect(BaseEventData eventData)
    {
        Destroy(spikeObj);
    }
}
