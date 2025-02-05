using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    public HealtSystem healtsystem;
    public float plusYparamentr;
    [SerializeField] private Slider slider;
    private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;


    private void Start()
    {
        
        cam = FindObjectOfType<Camera>().GetComponent<Camera>();
    
    }

    public void Setup(HealtSystem healtsystem)
    { this.healtsystem = healtsystem; }



    private void Update()
    {
        // Aktualizacja skali paska zdrowia
        // transform.Find("Bar").localScale = new Vector3(healtsystem.getHealtProcent(), 1);
        if (healtsystem != null) { Debug.Log("healsystem nie nieistnieje"); } 
        slider.value = healtsystem.getHealtProcent();

        transform.parent.rotation = cam.transform.rotation;
        transform.position = target.position + offset;
       
    }
}


