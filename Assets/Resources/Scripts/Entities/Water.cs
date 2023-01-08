using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Water : MonoBehaviour {

    private Mesh water;
    private Vector3[] vertices;
    private Vector2[] uv;
    private float totalTime = 0f;

    // Start is called before the first frame update
    void Start() {
        this.water = GetComponent<MeshFilter>().mesh;

        this.vertices = this.water.vertices;
        this.uv = this.water.uv;
    }

    // Update is called once per frame
    void Update() {
        this.totalTime += Time.deltaTime / 2;

        for (int v=0; v<this.vertices.Length; v++) {
            float noiseX = this.transform.position.x + this.vertices[v].x + totalTime;
            float noiseZ = this.transform.position.z + this.vertices[v].z + totalTime;
            float noise = Mathf.PerlinNoise(noiseX, noiseZ);
            this.vertices[v] = new Vector3(this.vertices[v].x, noise*12.5f, this.vertices[v].z);
        }

        for (int u=0; u<this.uv.Length; u++) {
            this.uv[u] += new Vector2(Time.deltaTime / 100, Time.deltaTime / 100);
        }

        this.water.vertices = this.vertices;
        this.water.uv = this.uv;
        this.water.RecalculateBounds();
    }
}
