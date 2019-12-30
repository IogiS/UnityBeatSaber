using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerNew : MonoBehaviour
{
    [SerializeField]
    private float timer;
    public bool isFree = true;

    public float[] samples = AudioPeer.samples;
    public Transform[] transforms;
    public GameObject[] cubes;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (AudioPeer.beat)
        {

            IsFree();
            Spawn();
            
        }
        AudioPeer.beat = false;
    }
    public void Spawn()
    {
        if (isFree)
        {
            
            GameObject cube = Instantiate(cubes[Random.Range(0, 2)], transforms[index]);

            cube.transform.localPosition = Vector3.zero;

            cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
            timer = 0;
            index++;
        }
        if (index == 3)
            index = 0;
    }

    public void IsFree()
    {

        if (timer > 0.3)
        {
            isFree = true;
        }
        else
            isFree = false;

    }
}
