using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public AudioSource loseSource;
    
    void Start() {
        this.loseSource.Play();
    }
}
