using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefly : MonoBehaviour {

    public int gridPositionX;
    public int gridPositionZ;

    //private static float eatenTime = 1.25f;
    //private float eatenTimer = 0f;
    
    // Start is called before the first frame update
    void Start() {
        this.gridPositionX = (int)(this.transform.position.x / World.gridToUnit);
        this.gridPositionZ = (int)(this.transform.position.z / World.gridToUnit);

        this.transform.Rotate(new Vector3(-90, (int)Random.Range(0, 4) * 90, 0), Space.Self);
    }
}
