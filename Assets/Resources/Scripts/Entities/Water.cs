using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    private Mesh water;
    private Vector3[] vertices;
    private float totalTime = 0f;

    // Start is called before the first frame update
    void Start() {
        this.water = GetComponent<MeshFilter>().mesh;
        this.vertices = this.water.vertices;
    }

    // Update is called once per frame
    void Update() {
        this.totalTime += Time.deltaTime;

        for (int v=0; v<this.vertices.Length; v++) {
            float noise = Mathf.PerlinNoise(this.vertices[v].x + totalTime, this.vertices[v].z + totalTime);
            this.vertices[v] = new Vector3(this.vertices[v].x, noise, this.vertices[v].z);
        }

        this.water.vertices = vertices;
        this.water.RecalculateBounds();
    }
}
