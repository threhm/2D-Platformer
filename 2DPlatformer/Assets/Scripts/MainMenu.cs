using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quit");
    }

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
