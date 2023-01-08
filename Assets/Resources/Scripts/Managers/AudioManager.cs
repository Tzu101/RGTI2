using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class AudioManager : MonoBehaviour {

    public AudioSource crunchSource;
    public AudioSource flySource;
    public AudioSource jumpSource;
    public AudioSource musicSource;
    public AudioSource splashSource;
    public AudioSource stingSource;
    public AudioSource winSource;

    // Start is called before the first frame update
    void Start() {
        Debug.Log(SceneManager.GetActiveScene().name.ToString());
        if(SceneManager.GetActiveScene().name.ToString() == "Game Over" || SceneManager.GetActiveScene().name.ToString() == "Winner"){
            this.flySource.Stop();
            this.musicSource.Stop();
        }
        else{
            this.flySource.loop = true;
            this.musicSource.loop = true;           
        }
    }

    public void playCrunch() {
        this.crunchSource.Play();
    }

    public void playFly() {
        this.flySource.Play();
    }

    public void playJump() {
        this.jumpSource.Play();
    }

    public void playMusic() {
        this.musicSource.Play();
    }

    public void playSplash() {
        this.splashSource.Play();
    }

    public void playSting() {
        this.stingSource.Play();
    }

    public void playWin() {
        this.winSource.Play();
    }
}
