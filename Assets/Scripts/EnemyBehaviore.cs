using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviore : MonoBehaviour
{
    [SerializeField] float SpeedMovement;
    [SerializeField] float SpeedRotation;
  
    [SerializeField] int MAXHP = 100;
    [SerializeField] int HP = 100;

    public Rigidbody2D playerRB;

    Rigidbody2D enemyRb;
    public HealtBar HealtBar;
    private Transform PlayerTransform;

    void Start()
    {
        HealtSystem healtSystem = new HealtSystem(MAXHP);
        HealtBar.Setup(healtSystem);
        healtSystem.Damege(50);
        

        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null)
        {
            PlayerTransform = Player.transform;
           
        }
        else
        {
            Debug.LogWarning("Player not found");
        }

        enemyRb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
       
    }





    private void FixedUpdate()
    {
        Movement();
        RotatioEnemyShip();
    }
    public void Movement()
    {
     
        Vector2 Direction = playerRB.position - enemyRb.position;

        float angle = Mathf.Atan2(Direction.y, Direction.x);

        Vector2 movement = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        enemyRb.velocity = movement * SpeedMovement;
    }

    public void RotatioEnemyShip()
    {
        float angle = Mathf.Atan2(enemyRb.velocity.y, enemyRb.velocity.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        Quaternion targetRotation2 = Quaternion.Euler(0, 0,enemyRb.rotation);
        transform.rotation = Quaternion.Slerp(targetRotation2, targetRotation, SpeedRotation *0.1f);
    }
}

