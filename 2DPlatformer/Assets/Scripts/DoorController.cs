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
        if(other.gameObject.CompareTag("Player")) {
            playWinSound();
            Invoke("Win", 3);
        }
    }
    void Start()
    {
        bc = gameObject.GetComponent<BoxCollider2D>();
        bc.isTrigger = true;
        source = GetComponent<AudioSource>();
    }

    public void Win() {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }

    public void playWinSound() {
        source.PlayOneShot(clip);
    }

}
