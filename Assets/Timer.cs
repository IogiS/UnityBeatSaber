using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool isFree = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawner.timer > 1)
        {
            isFree = false;
            spawner.timer = 0;
        }
    }

    public void Spawn(int i)
    {

            GameObject cube = Instantiate(spawner.cubes[Random.Range(0, 2)], spawner.points[i]);

            cube.transform.localPosition = Vector3.zero;

            cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));

        
    }
}
