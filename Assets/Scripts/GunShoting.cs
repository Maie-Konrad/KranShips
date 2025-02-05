using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class GunShoting : MonoBehaviour
{
    public GameObject missile;
    public GameObject gunPosition;
    [SerializeField] AudioSource missileSource;
    [SerializeField]float MaxRecoil = 100f;
    public float RecoilValue = 0f;
    [SerializeField] float TimeCooling = 3f;


    private bool isCooling = false;
    private bool isOverHeated = false;

    Rigidbody2D rb;

    private void Update()
    {
        GuncoolingDown();

        if (RecoilValue <= MaxRecoil && isOverHeated == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GunShot();
            }
        }
        if(RecoilValue >= 100)
        {
            isOverHeated = true;
           
            StartCoroutine(Gunovergeated());



        }

      //  Debug.Log(RecoilValue);

        RecoilValue = Mathf.Clamp(RecoilValue, 0f, MaxRecoil);

    }
     private void GuncoolingDown()
    {

        if ( !isCooling && RecoilValue>0)
        {
            StartCoroutine(CoolDownCuruntine());
        }

    }

    IEnumerator CoolDownCuruntine()
    {
        isCooling = true;
        while(RecoilValue> 0) 
        {
            
          //  Debug.Log("Wartoœæ recoil :" + RecoilValue.ToString());

           


            yield return new WaitForSeconds(0.25f);
            RecoilValue -= 2.5f;
           
            
        }
        isCooling = false;
    }
    IEnumerator Gunovergeated()
    {
        
       Debug.Log("Dzia³o zosta³o przegrzane");
        yield return new WaitForSeconds(TimeCooling);
        isOverHeated = false;



    }

    private void GunShot()
    {

        Instantiate(missile, gunPosition.transform.position, gunPosition.transform.rotation);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        RecoilValue += 5f;
        missileSource.Play();
    }

    public void RecoilOverH()
    {
       
    }
}
