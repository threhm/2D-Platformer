using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int playerX = (int) player.transform.position.x;
        playerX = playerX / 64;
        int camX = (playerX * 64) + 32;
        transform.position = new Vector3( camX, transform.position.y, transform.position.z);
    }
}
