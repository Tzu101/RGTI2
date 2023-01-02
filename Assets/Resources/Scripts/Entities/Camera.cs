using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    private Vector3 frogPosition = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start() {
        this.calibratePosition();
    }

    // Update is called once per frame
    void Update() {

        if (!this.frogPosition.Equals(EntityManager.frogs.transform.position)) {
            this.calibratePosition();
        }
    }

    private void calibratePosition() {
        float newPositionX = -(EntityManager.frogs.transform.position.x - EntityManager.lilypadCenter.x * World.gridToUnit);
        float newPositionZ = -(EntityManager.frogs.transform.position.z - EntityManager.lilypadCenter.z * World.gridToUnit);

        float ratio = Mathf.Sqrt(newPositionX*newPositionX + newPositionZ*newPositionZ);
        newPositionX = newPositionX / ratio * 20f;
        newPositionZ = newPositionZ / ratio * 20f;

        this.transform.position = new Vector3(newPositionX, 20f, newPositionZ);
        this.transform.LookAt(EntityManager.frogs.transform, Vector3.up);

        this.frogPosition = EntityManager.frogs.transform.position;
    }
}
