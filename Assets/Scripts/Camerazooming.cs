using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camerazooming : MonoBehaviour
{

    CinemachineVirtualCamera cam;
    public float zoomSpeed = 10f;
    public float minZoom = 20f;
    public float maxZoom = 100f;

    private void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }
    void Update()
    {
        // Odczyt scrolla myszki
        float scroll = Input.mouseScrollDelta.y;

        
      
        
            cam.m_Lens.OrthographicSize -= scroll * zoomSpeed * Time.deltaTime;
            cam.m_Lens.OrthographicSize = Mathf.Clamp(cam.m_Lens.OrthographicSize, minZoom, maxZoom);
            
        
    }

}