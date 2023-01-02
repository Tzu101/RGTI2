using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour {

    private float totalTime = 0;
    public Light sun;
    public Light moon;

    // Start is called before the first frame update
    void Start() {
        //this.moon = this.transform.GetChild(1).GetComponent<Light>();
    }

    // Update is called once per frame
    void Update() {
        this.totalTime += Time.deltaTime;

        this.sun.transform.position = new Vector3(Mathf.Sin(this.totalTime / 10) * 100f, Mathf.Cos(this.totalTime / 10) * 100f, 0);
        this.sun.transform.LookAt(Vector3.zero, Vector3.up);
        this.sun.color = new Color(1, 0.5f + this.sun.transform.position.y / 300, 0);

        if (this.sun.transform.position.y < 0) {
            this.sun.intensity = Mathf.Max(0, this.sun.transform.position.y + 10) / 10;
        } else {
            this.sun.intensity = 1;
        }

        this.moon.transform.position = new Vector3(-Mathf.Sin(this.totalTime / 10) * 10f, -Mathf.Cos(this.totalTime / 10) * 10f, 0);
        this.moon.transform.LookAt(Vector3.zero, Vector3.up);

        if (this.moon.transform.position.y < -10) {
            this.moon.enabled = false;
        } else {
            this.moon.enabled = true;
        }
    }
}
