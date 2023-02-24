using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public int width;
    public int height;

    void Update()
    {
        //Control x movement
        int playerX = (int) player.transform.position.x;
        playerX = playerX / width;
        int camX = (playerX * width) + width/2;
        transform.position = new Vector3( camX, transform.position.y, transform.position.z);

        //Control y movement
        int playerY = (int) player.transform.position.y;
        playerY = playerY / height;
        int camY = (playerY * height) + height/2;
        transform.position = new Vector3( transform.position.x, camY, transform.position.z);
    }
}
