using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
        if(Input.GetKeyDown(KeyCode.P)) {
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }
        if(Input.GetKeyDown(KeyCode.L)) {
            SceneManager.LoadScene("Level3", LoadSceneMode.Single);
        }
    }
}
