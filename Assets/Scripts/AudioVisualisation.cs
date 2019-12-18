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
        samplesRate = AudioSettings.outputSampleRate;

        samples = new float[bufferSampleSize];
        spectrum = new float[bufferSampleSize];

        switch (visualisationMode)
        {
            case VisualisationMode.Ring:
                initialRing();
                break;
            case VisualisationMode.RingWithBeat:
                break;
            default:
                break;
        }


    }

    private void initialRing()
    {
        extendLength = new float[amountOfSegments + 1];
        lineRenderers = new LineRenderer[extendLength.Length];

        for (int i = 0; i < lineRenderers.Length; i++)
        {
            GameObject go = Instantiate(lineRendererPrefab);
            go.transform.position = Vector3.zero;

            LineRenderer lineRenderer = go.GetComponent<LineRenderer>();
            lineRenderer.sharedMaterial = lineRendererMaterial;

            lineRenderer.positionCount = 2;
            lineRenderer.useWorldSpace = true;
            lineRenderers[i] = lineRenderer;
        }
    }

    private void Update()
    {
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        UpdateExtends();

        if (visualisationMode == VisualisationMode.Ring)
        {
            UpdateRing();
        }
    }

    private void UpdateExtends()
    {
        int iteration = 0;
        int indexOnSpectrum = 0;
        int averageValue = (int)(Mathf.Abs(samples.Length * samplePercentage) / amountOfSegments);

        if (averageValue < 1)
        {
            averageValue = 1;
        }

        while (iteration < amountOfSegments)
        {
            int iterationIndex = 0;
            float sumValueY = 0;

            while (iterationIndex < averageValue)
            {
                sumValueY += spectrum[indexOnSpectrum];
                indexOnSpectrum++;
                iterationIndex++;
            }

            float y = sumValueY / averageValue * emphasisMultiplier;
            extendLength[iteration] -= retractionSpeed * Time.deltaTime;

            if (extendLength[iteration] < y)
            {
                extendLength[iteration] = y;
            }

            if (extendLength[iteration] > maximumExtendLength)
            {
                extendLength[iteration] = maximumExtendLength;
            }
            iteration++;
        }
    }

    private void UpdateRing()
    {
        for (int i = 0; i < lineRenderers.Length; i++)
        {
            float t = i / (lineRenderers.Length - 2f);
            float a = t * Mathf.PI * 2f;

            Vector2 direction = new Vector2(Mathf.Cos(a), Mathf.Sin(a));
            float maximumRadius = (radius + bufferSizeArea + extendLength[i]);

            lineRenderers[i].SetPosition(0, direction * radius);
            lineRenderers[i].SetPosition(1, direction * maximumRadius);

            lineRenderers[i].startWidth = Spacing(radius);
            lineRenderers[i].endWidth = Spacing(maximumRadius);

            lineRenderers[i].startColor = colorGradientA.Evaluate(0);
            lineRenderers[i].endColor = colorGradientA.Evaluate((extendLength[i] - 1) / (maximumExtendLength - 1f));

        }


    }

    private float Spacing(float radius)
    {
        float c = 2f * Mathf.PI * radius;
        float n = lineRenderers.Length;
        return c / n;
    }

}
