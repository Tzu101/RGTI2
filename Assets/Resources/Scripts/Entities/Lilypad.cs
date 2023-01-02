using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lilypad : MonoBehaviour {
    
    // Start is called before the first frame update
    void Start() {
        this.transform.Rotate(new Vector3(-90, (int)Random.Range(0, 4) * 90, 0), Space.Self);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
