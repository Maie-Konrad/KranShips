using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObecjt : MonoBehaviour
{
   public  GameObject ThisGameoOject;

    public void DestroyThisObject()
    {
        Destroy(ThisGameoOject);

    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
