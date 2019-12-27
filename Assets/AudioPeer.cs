using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour
{
    public float framePerSec;
    float previousAverageSample;
    static public bool beat = false;
    AudioSource audioSource;
    public static float[] samples = new float[64];
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        CheckBeat();
    }

    void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
        
    }
  
    void  CheckBeat()
    {
        float averageSample = 0;
        for (int i = 0; i < 10; i++)
        {
            averageSample += samples[i]; 
        }

            if (previousAverageSample - averageSample > 0.35)
            {
                beat = true;
            }
        
       
        previousAverageSample = averageSample;


    }
}
