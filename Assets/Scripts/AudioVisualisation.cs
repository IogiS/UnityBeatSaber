using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum VisualisationMode
{
    Ring,
    RingWithBeat
}
public class AudioVisualisation : MonoBehaviour
{
    public int bufferSampleSize;
    public float samplePercentage;
    public float emphasisMultiplier;
    public float  retractionSpeed;

    public int amountOfSegments;
    public float radius;
    public float bufferSizeArea;
    public float maximumExtendLength;

    public GameObject lineRendererPrefab;
    public Material lineRendererMaterial;
    public VisualisationMode visualisationMode;

    public Gradient colorGradientA = new Gradient();
    public Gradient colorGradientB = new Gradient();

    private Gradient currentColor = new Gradient();

    private float samplesRate;

    private float[] samples;
    private float[] spectrum;
    private float[] extendLength;

    private LineRenderer[] lineRenderers;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


}
