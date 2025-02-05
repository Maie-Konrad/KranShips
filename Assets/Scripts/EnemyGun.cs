using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private int typeOfEnemy; //zmienna liczbowa okreúlajπca typ przeciwka.
    [SerializeField] private float frequency = 0.2f;

    private Transform playerTransform; // Transform gracza

    private bool isFireee = false;

    public GameObject missile;
    public GameObject gunPosition;

    private void Start()
    {
        // Znajdü gracza na poczπtku, aby uniknπÊ ciπg≥ego wyszukiwania w Update
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Nie znaleziono obiektu z tagiem 'Player'!");
        }
    }
    void Update()
    {
        if (!isFireee) 
        {
            StartCoroutine(GunShooting());
        }

        
        Vector2 direction = (playerTransform.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion currentRotation = transform.rotation;
    
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    IEnumerator GunShooting()
    {
        if(typeOfEnemy == 0)
        {

            isFireee = true;
            
                GunShot();
               
            
            yield return new WaitForSeconds(frequency);
            isFireee = false;
        }
        else if(typeOfEnemy == 1)
        {
            isFireee = true;
            for (int i = 0; i < 3; i++)
            {
                GunShot();
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(frequency);
            isFireee = false;

        }
       
    }
    private void GunShot()
    {

        Instantiate(missile, gunPosition.transform.position, gunPosition.transform.rotation);
        //Rigidbody2D rb = GetComponent<Rigidbody2D>();
        
    }
}
