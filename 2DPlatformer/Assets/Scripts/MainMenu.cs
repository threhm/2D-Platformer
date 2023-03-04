using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //If play is selected load the first scene
    public void PlayGame() {
        SceneManager.LoadScene(1);
    }

    //If quit is selected quit the game. Debug statement is here so we know the button works in Unity Editor
    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quit");
    }

    //Load the index of the given level, and set the appropriate orb statuses.
    public void loadLevel(int level) {
        if (level == 1)
        {
            OrbsStatus.levelOnePrep();
        }
        else if (level == 2)
        {
            OrbsStatus.levelTwoPrep();
        }
        else if (level == 3)
        {
            OrbsStatus.levelThreePrep();
        }
        else if (level == 4)
        {
            OrbsStatus.levelFourPrep();
        }
        else if (level == 5)
        {
            OrbsStatus.levelFivePrep();
        }
        else if (level == 6)
        {
            OrbsStatus.levelSixPrep();
        }
        SceneManager.LoadScene(level);
    }
}
