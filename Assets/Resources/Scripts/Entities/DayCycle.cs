using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour {

    private float totalTime = 0;
    public Light sun;
    public UnityEngine.Camera cam;

    // Start is called before the first frame update
    void Start() {
        this.cam.clearFlags = CameraClearFlags.SolidColor;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().playMusic();
    }

    // Update is called once per frame
    void Update() {
        this.totalTime += Time.deltaTime;

        this.sun.transform.position = new Vector3(Mathf.Sin(this.totalTime / 10) * 100, Mathf.Cos(this.totalTime / 10) * 100, 0);
        this.sun.color = new Color(0.5f + this.sun.transform.position.y / 300, 0.5f + this.sun.transform.position.y / 300, 0);
        this.sun.intensity = Mathf.Max(0.2f, this.sun.transform.position.y / 100);
        this.sun.transform.LookAt(Vector3.zero, Vector3.up);

        float ambientLight = Mathf.Max(0, this.sun.transform.position.y / 300);
        Color ambientColor = new Color(ambientLight + 0.1f, ambientLight + 0.1f, ambientLight + 0.2f);
        RenderSettings.ambientLight = ambientColor;
        RenderSettings.fogColor = ambientColor;
        this.cam.backgroundColor = ambientColor;

        if (this.sun.transform.position.y < 0) {
            this.sun.intensity = 0.2f;
            this.sun.color = new Color(1, 1, 1);
            this.sun.transform.position = new Vector3(-this.sun.transform.position.x, -this.sun.transform.position.y, 0);
            this.sun.transform.LookAt(Vector3.zero, Vector3.up);
        }
    }
}
