using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
    public float speed = 1;
    void Update()
    {
        // Pobranie pozycji kursora w przestrzeni œwiata

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        mousePos.z = transform.position.z;
        // Obliczenie ró¿nicy od obiektu do kursora
       Vector2 direction = (mousePos - transform.position).normalized;

        // Obliczenie k¹ta - tangesa do okreœlenia k¹ta 0 w uk³adzie wspo³rzêdnym
        // i ustawienie rotacji
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //pozycja obiektu
        Quaternion currentRotation = transform.rotation;
        //pozycja do której obiekt ma byæ zwrócony
        Quaternion targetRotation = Quaternion.Euler(0,0,angle);
  
        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, speed * Time.deltaTime);

    }

}
