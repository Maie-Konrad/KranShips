using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtBar : MonoBehaviour
{
    public HealtSystem healtsystem;
    private void Start()
    {  }
    public void Setup(HealtSystem healtsystem)
    { this.healtsystem = healtsystem; }

    private void Update()
    {
        transform.Find("Bar").localScale = new Vector3(healtsystem.getHealtProcent(), 1);
    }

}


