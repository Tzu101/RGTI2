using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        /*this.transform.position = this.transform.position * 10;
        this.transform.position -= new Vector3(0, 5, 0);

        this.transform.localScale = this.transform.localScale * 10;*/
    }

    // Update is called once per frame
    void Update() {
        this.totalTime += Time.deltaTime;

        for (int v=0; v<this.vertices.Length; v++) {
            float noiseX = this.transform.position.x + this.vertices[v].x + totalTime;
            float noiseZ = this.transform.position.z + this.vertices[v].z + totalTime;
            float noise = Mathf.PerlinNoise(noiseX, noiseZ);
            this.vertices[v] = new Vector3(this.vertices[v].x, noise, this.vertices[v].z);
        }

        for (int u=0; u<this.uv.Length; u++) {
            this.uv[u] += new Vector2(totalTime / 2500, totalTime / 2500);
        }

        this.water.vertices = vertices;
        this.water.uv = uv;
        this.water.RecalculateBounds();
    }
}
