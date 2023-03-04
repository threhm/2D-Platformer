using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    void Update()
    {
        //Quit the game if escape is pressed
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
        //Reload the scene if R is pressed
        if(Input.GetKeyDown(KeyCode.R)){
             Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
         }
    }
}
