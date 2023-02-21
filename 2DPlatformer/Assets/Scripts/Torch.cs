using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mySpriteRenderer.enabled = OrbsStatus.getStatus("red");
        transform.GetChild(0).gameObject.SetActive(OrbsStatus.getStatus("red"));
    }
}
