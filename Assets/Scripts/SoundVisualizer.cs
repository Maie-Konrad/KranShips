using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVisualizer : MonoBehaviour
{
    public AudioSource audioSource; // �r�d�o d�wi�ku
    public GameObject[] visualizerObjects; // Obiekty do wizualizacji (np. s�upki)
    public float updateStep = 0.1f; // Cz�stotliwo�� aktualizacji danych
    public int sampleDataLength = 1024; // D�ugo�� pr�bki audio

    private float[] spectrumData; // Tablica na dane widma
    private float[] visualizerScales; // Skale dla obiekt�w wizualizacyjnych
    public float maxScale = 10f; // Maksymalna skala obiekt�w

    private void Start()
    {
        spectrumData = new float[sampleDataLength];
        visualizerScales = new float[visualizerObjects.Length];
    }

    private void Update()
    {
        // Pobierz dane widma z AudioSource
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Hamming);

        // Zaktualizuj skal� obiekt�w wizualizacyjnych
        for (int i = 0; i < visualizerObjects.Length; i++)
        {
            // U�rednij warto�ci z widma dla p�ynniejszej wizualizacji
            float spectrumValue = spectrumData[i] * maxScale;
            visualizerScales[i] = Mathf.Lerp(visualizerScales[i], spectrumValue, updateStep);

            // Zastosuj skal� do obiektu
            visualizerObjects[i].transform.localScale = new Vector3(1, visualizerScales[i], 1);
        }
    }

}
