using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUDInGame : MonoBehaviour
{
    [SerializeField] private GunShoting gunShooting; 
    [SerializeField] private TextMeshProUGUI Recoiltext;
    [SerializeField] private ShipMovement shipMovement;
    [SerializeField] private TextMeshProUGUI Turbotext;
    [SerializeField] private TextMeshProUGUI SpeedText;

    public float Recoil;
    public float turbo;
    public float speed;
    void Start()
    {

        if (gunShooting == null)
        {
            Debug.LogError("GunShooting nie jest przypisany!");
        }

        if (Recoiltext == null)
        {
            Debug.LogError("TextMeshProUGUI nie jest przypisany!");
        }
        if (shipMovement == null)
        {
            Debug.LogError("shipMovement nie jest przypisany!");
        }

        if (Turbotext == null)
        {
            Debug.LogError("Turbo nie jest przypisany!");
        }

        if (SpeedText == null)
        {
            Debug.LogError("SpeedText nie jest przypisany!");
        }

    }


    // Update is called once per frame
    void Update()
    {
       
        if(gunShooting != null && Recoiltext != null) 
        {   

            Recoiltext.text = "Recoil" + gunShooting.RecoilValue.ToString("F1");
            
        }

        if (shipMovement != null && Turbotext != null)
        {

            Turbotext.text = "Turbo" + shipMovement.TurboValue(turbo).ToString("P1") ;
            


        }
        if (shipMovement != null && SpeedText != null)
        {

            SpeedText.text = "Turbo" + shipMovement.Speed(turbo).ToString("F1");



        }
    }
}
