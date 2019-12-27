using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerNew : MonoBehaviour
{
    public float[] samples = AudioPeer.samples;
    public Transform[] transforms;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AudioPeer.beat)
        {
            for (int i = 0; i < transforms.Length; i++)
            {
                if (transforms[i].GetComponent<Timer>().isFree)
                {
                    transforms[i].GetComponent<Timer>().Spawn();
                }
            }

        }
        AudioPeer.beat = false;
    }
}
