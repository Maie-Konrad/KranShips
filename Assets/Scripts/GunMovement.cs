using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
    public float speed = 1;
    void Update()
    {
        // Pobranie pozycji kursora w przestrzeni �wiata

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        mousePos.z = transform.position.z;
        // Obliczenie r�nicy od obiektu do kursora
       Vector2 direction = (mousePos - transform.position).normalized;

        // Obliczenie k�ta - tangesa do okre�lenia k�ta 0 w uk�adzie wspo�rz�dnym
        // i ustawienie rotacji
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //pozycja obiektu
        Quaternion currentRotation = transform.rotation;
        //pozycja do kt�rej obiekt ma by� zwr�cony
        Quaternion targetRotation = Quaternion.Euler(0,0,angle);
  
        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, speed * Time.deltaTime);

    }

}
