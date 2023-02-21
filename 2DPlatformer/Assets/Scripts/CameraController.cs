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
        //Control x movement
        int playerX = (int) player.transform.position.x;
        playerX = playerX / 64;
        int camX = (playerX * 64) + 32;
        transform.position = new Vector3( camX, transform.position.y, transform.position.z);

        int playerY = (int) player.transform.position.y;
        playerY = playerY / 40;
        int camY = (playerY * 40) + 20;
        transform.position = new Vector3( transform.position.x, camY, transform.position.z);
    }
}
