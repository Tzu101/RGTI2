using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public AudioSource winSource;
    
    void Start() {
        this.winSource.Play();
    }
}
