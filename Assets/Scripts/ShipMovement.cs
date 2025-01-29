using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipMovement : MonoBehaviour
{
    [Header(" Movement ")]
    [SerializeField] float acceleration = 1f;
        
    [SerializeField] float maxSpeed = 5f;
    [SerializeField] float minSpeed;
    [SerializeField] float damping = 0.95f;
    [SerializeField] float  constSpeed = 4f;

    

    [Header(" Turbo ")]
    float turboReserve = 0;
    [SerializeField] float accelerationTurbo = 1f; 
    [SerializeField] float turboReserveMax = 20f;
    [SerializeField] float turboSpeedFueling = 0.5f;
    [SerializeField] float turboConsumption = 3f;
    [SerializeField] float turbocooldown = 0;

    private Rigidbody2D rb;

    private Vector2 targetVelocity; // Docelowa prêdkoœæ
    Vector2 InputDirection; //Docelowy Kierunek


    float xMovement;
    float YMovement;
    bool isTurbo = true;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        turboReserve = 4f;
    }
   
    public void FixedUpdate()
    {
        Vector2 movingFoward = new Vector2(constSpeed, 0);
        turboReserve = Mathf.Clamp(turboReserve, 0, turboReserveMax);

       
        // Regeneracja turbo
        if (turboReserve < turboReserveMax)
        {
            turboReserve += Time.fixedDeltaTime * turboSpeedFueling;
        }

        // Ruch statku
        xMovement = (Input.GetAxisRaw("Horizontal"));
        YMovement = (Input.GetAxisRaw("Vertical"));

       


        InputDirection = new Vector2(xMovement, YMovement).normalized;

        targetVelocity += InputDirection * acceleration * Time.fixedDeltaTime;

        if (targetVelocity.magnitude > maxSpeed)
        {
            targetVelocity = targetVelocity * maxSpeed;
        }
        //turbo
        if (Input.GetKey(KeyCode.LeftShift) && isTurbo == true )
        {
            Turbo();
        }
        
        // Obrót statku
        if (rb.velocity.sqrMagnitude > 0.1f) // Obrót tylko, gdy statek siê porusza
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        // Aktualizacja prêdkoœci i t³umienie


        rb.velocity = movingFoward + targetVelocity;

        if(rb.velocity.x < minSpeed)
        {
             rb.velocity = new Vector2(minSpeed, rb.velocity.y);
        }
       
            targetVelocity *= Mathf.Pow(damping, Time.fixedDeltaTime * 50f);
    }

    public void Turbo()
    {

        

        if  (turboReserve > 0 && isTurbo)
        {
            targetVelocity += InputDirection * accelerationTurbo * Time.deltaTime;
            turboReserve -= Time.fixedDeltaTime * turboConsumption;
        }

        if (turboReserve <= 0 && isTurbo)
        {
            Debug.Log("Cooldown turbo");
            StartCoroutine(TurboCoolDown());
        }

    }
    public float TurboValue(float turboreserve)
    {
         turboreserve = turboReserve;
        return turboreserve / turboReserveMax;
    }
    public float Speed(float speedvalue)
    {

        speedvalue = rb.velocity.magnitude;
      
        
        return speedvalue;
    }

    IEnumerator TurboCoolDown()
    {
        isTurbo = false;
        Debug.Log("Turbo cooldown rozpoczêty.");
        yield return new WaitForSeconds(turbocooldown);
        Debug.Log("Turbo cooldown zakoñczony.");
        isTurbo = true;
    }

}
