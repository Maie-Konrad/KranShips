using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    

    public float DestroyTime = 5f;
    public GameObject BulletPreFab;

    public GameObject Explosion;
    public AudioClip ExplosionSound;

    public float speedBullet;


    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right, ForceMode2D.Impulse);
        rb.velocity = transform.right * speedBullet;

      
    }
    private void Update()
    {
        StartCoroutine(BulletDestroy(DestroyTime));
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log("Pocisk trafi³ w: " + collision.gameObject.name);

        
        Destroy(gameObject);
    }
    IEnumerator BulletDestroy(float Delay)
    {

        yield return new WaitForSeconds(DestroyTime);
         Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      //  Debug.Log("HIT in" +  collision.gameObject.name.ToString());
        Explode();
        Destroy(gameObject);

    }

    private void Explode()
    {
        if(Explosion != null)
        {
        Instantiate(Explosion,transform.position,Quaternion.identity);
        }
        if(ExplosionSound != null) 
        {
            Instantiate(ExplosionSound,transform.position,Quaternion.identity);
        }
       
        
    }

}
