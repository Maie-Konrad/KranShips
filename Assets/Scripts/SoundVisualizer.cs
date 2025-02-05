using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVisualizer : MonoBehaviour
{
    public AudioSource audioSource; // èrÛd≥o düwiÍku
    public GameObject[] visualizerObjects; // Obiekty do wizualizacji (np. s≥upki)
    public float updateStep = 0.1f; // CzÍstotliwoúÊ aktualizacji danych
    public int sampleDataLength = 1024; // D≥ugoúÊ prÛbki audio

    private float[] spectrumData; // Tablica na dane widma
    private float[] visualizerScales; // Skale dla obiektÛw wizualizacyjnych
    public float maxScale = 10f; // Maksymalna skala obiektÛw

    private void Start()
    {
        spectrumData = new float[sampleDataLength];
        visualizerScales = new float[visualizerObjects.Length];
    }

    private void Update()
    {
        // Pobierz dane widma z AudioSource
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Hamming);

        // Zaktualizuj skalÍ obiektÛw wizualizacyjnych
        for (int i = 0; i < visualizerObjects.Length; i++)
        {
            // Uúrednij wartoúci z widma dla p≥ynniejszej wizualizacji
            float spectrumValue = spectrumData[i] * maxScale;
            visualizerScales[i] = Mathf.Lerp(visualizerScales[i], spectrumValue, updateStep);

            // Zastosuj skalÍ do obiektu
            visualizerObjects[i].transform.localScale = new Vector3(1, visualizerScales[i], 1);
        }
    }

}
