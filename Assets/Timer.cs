using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float timer;
    public bool isFree = true;
    public GameObject[] cubes;
    public Transform points;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

    }

    
    public void IsFree()
    {

        if (timer > 1)
        {
            isFree = true;
        }
        else
            isFree = false;

    }
    public void Spawn()
    {
        if (isFree)
        {




            GameObject cube = Instantiate(cubes[Random.Range(0, 2)], points);

            cube.transform.localPosition = Vector3.zero;

            cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
            timer = 0;

        }
    }
}
