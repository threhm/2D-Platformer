using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D bc;

    private AudioSource source;
    public AudioClip clip;

    public string nextScene;

    void OnTriggerEnter2D(Collider2D other) {
        //SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
        if (other.gameObject.CompareTag("Player")) {

            if (nextScene == "Level2" && OrbsStatus.levelOneComplete())
            {
                WinMechanics();
            }
            else if (nextScene == "Level3" && OrbsStatus.levelTwoComplete())
            {
                WinMechanics();
            }
            else if (nextScene == "Level4" && OrbsStatus.levelThreeComplete())
            {
                WinMechanics();
            }
        }
    }
    void Start()
    {
        bc = gameObject.GetComponent<BoxCollider2D>();
        bc.isTrigger = true;
        source = GetComponent<AudioSource>();
    }

    public void WinMechanics() {
        playWinSound();
        Invoke("Win", 3);
    }

    public void Win() {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }

    public void playWinSound() {
        source.PlayOneShot(clip);
    }

}
