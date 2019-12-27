using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float[] samples = AudioPeer.samples;
    [SerializeField]
    private float timer;
    // Start is called before the first frame update
    [SerializeField]
    public Transform[] transforms;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        samples = AudioPeer.samples;
        timer += Time.deltaTime;

        if (AudioPeer.beat)
        {


        }
        AudioPeer.beat = false;
    }


}

