using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instatiate128cubes : MonoBehaviour
{

    public GameObject sampleCubePrefab;
    GameObject[] samplesCube = new GameObject[64];

    public float maxScale;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 64; i++)
        {
            GameObject instantiateSampleCube = (GameObject)Instantiate(sampleCubePrefab);
            instantiateSampleCube.transform.position = this.transform.position;
            instantiateSampleCube.transform.parent = this.transform;
            instantiateSampleCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -5.625f * i, 0);
            instantiateSampleCube.transform.position = Vector3.forward * 100;
            samplesCube[i] = instantiateSampleCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 64; i++)
        {
            if (samplesCube != null)
            {
                samplesCube[i].transform.localScale = new Vector3(10, (AudioPeer.samples[i] * maxScale) + 2, 10);
            }
        }
    }
}
