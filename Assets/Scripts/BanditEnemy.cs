using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BanditEnemy : MonoBehaviour
{
    [SerializeField] float SpeedMovement;
    [SerializeField] float SpeedRotation;

    const int MAXHP = 100;
    [SerializeField] int GetDamage = 10;


    public Rigidbody2D playerRB;

    private Rigidbody2D enemyRb;

    public HealtBar HealtBar;

    private Transform PlayerTransform;
    public Vector3 offest;
    HealtSystem healtSystem = new HealtSystem(MAXHP);
    public void Start()
    {

        HealtBar.Setup(healtSystem);



        playerRB = FindObjectOfType<ShipMovement>().GetComponent<Rigidbody2D>();
        if (playerRB == null)
        {
            Debug.LogWarning("Nie znaleziono Rigidbody2D gracza.");
        }

        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null)
        {
            PlayerTransform = Player.transform;

        }
        else
        {
            //Debug.LogWarning("Player not found");
        }

        enemyRb = GetComponent<Rigidbody2D>();



    }


    void Update()
    {
        if (healtSystem.getHealt() == 0)
        {
            Destroy(gameObject);
        }
    }





    private void FixedUpdate()
    {
        Movement();
       // RotatioEnemyShip();
    }
    public void Movement()
    {

       

        enemyRb.transform.position = Vector3.Lerp(transform.position, PlayerTransform.position + offest, SpeedMovement);
    }

    public void RotatioEnemyShip()
    {
        float angle = Mathf.Atan2(enemyRb.velocity.y, enemyRb.velocity.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        Quaternion targetRotation2 = Quaternion.Euler(0, 0, enemyRb.rotation);
        transform.rotation = Quaternion.Slerp(targetRotation2, targetRotation, SpeedRotation * 0.1f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("colison okok??");
        if (collision.collider.CompareTag("Bullet"))
        {

            healtSystem.Damege(GetDamage);

        }

    }
}

