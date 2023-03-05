using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    SpriteRenderer mySpriteRenderer;
    public Sprite activeDoor;
    private bool notActive = true;
    private BoxCollider2D bc;

    private AudioSource source;
    public AudioClip clip;

    public string nextScene;

    void Start()
    {
        bc = gameObject.GetComponent<BoxCollider2D>();
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        bc.isTrigger = true;
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (nextScene == "Level2" && OrbsStatus.levelOneComplete() && notActive)
        {
            mySpriteRenderer.sprite = activeDoor;
            notActive = false;
        }
        else if (nextScene == "Level3" && OrbsStatus.levelTwoComplete() && notActive)
        {
            mySpriteRenderer.sprite = activeDoor;
            notActive = false;
        }
        else if (nextScene == "Level4" && OrbsStatus.levelThreeComplete() && notActive)
        {
            mySpriteRenderer.sprite = activeDoor;
            notActive = false;
        }
        else if (nextScene == "Level5" && OrbsStatus.levelFourComplete() && notActive)
        {
            mySpriteRenderer.sprite = activeDoor;
            notActive = false;
        }
        else if (nextScene == "Level6" && OrbsStatus.levelFiveComplete() && notActive)
        {
            mySpriteRenderer.sprite = activeDoor;
            notActive = false;
        }
        else if (nextScene == "EndLevel" && OrbsStatus.levelSixComplete() && notActive)
        {
            mySpriteRenderer.sprite = activeDoor;
            notActive = false;
        }
    }

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
            else if (nextScene == "Level5" && OrbsStatus.levelFourComplete())
            {
                WinMechanics();
            }
            else if (nextScene == "Level6" && OrbsStatus.levelFiveComplete())
            {
                WinMechanics();
            }
            else if (nextScene == "EndLevel" && OrbsStatus.levelSixComplete())
            {
                WinMechanics();
            }
        }
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
