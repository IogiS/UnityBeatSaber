using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public static GameObject[] cubes;
    public static Transform[] points;
    public float beats = (60 / 105) * 2;
    [SerializeField]
    public float[] samples;
    public static float timer; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time;

        if (AudioPeer.beat)
        {
            for(int i = 0; i < 3; i++)
            {
                if (points[i].GetComponent<Timer>().isFree)
                {
                    points[i].GetComponent<Timer>().Spawn(i);
                }


            }
        }
    }
    
}
