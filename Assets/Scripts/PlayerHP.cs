using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerHP : MonoBehaviour
{

    HealtSystem healtsystem = new HealtSystem(1000);
    public HealtBar HealtBar;
    [SerializeField] private int GetDamegeFromCollision = 100;
    [SerializeField] private int GetDamegeFromEnemyBullet = 100;
    public bool GodMode;
    bool gethit = false;

    public static event Action PlayerDeatch;
    private void Start()
    {

        HealtBar.Setup(healtsystem);

    }
   
    private void Update()
    {
        if (!GodMode && healtsystem.getHealt() == 0)
        {
            PlayerDeatch?.Invoke();

            Destroy(gameObject.gameObject);

            Debug.LogWarning("ZGINALES");
           
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {

            if (!gethit)
            {
                StartCoroutine(GetHitCooldown());
            }

        }
        if (collision.collider.CompareTag("EnemyBullet"))
        {


            healtsystem.Damege(GetDamegeFromEnemyBullet);
        }
    }
    IEnumerator GetHitCooldown()
    {
        gethit = true;

        healtsystem.Damege(GetDamegeFromCollision);
        Debug.Log("Dosta³eœ Obra¿enia Równe :  " +  GetDamegeFromCollision);
        yield return new WaitForSeconds(2f);

        gethit = false;

    }


}
