using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyWallBehawiure : MonoBehaviour
{
    [SerializeField] private float SpeedWall;
    private Rigidbody2D rb2d;
    [SerializeField] private GameObject gameOverObject;
    private bool StartAttack = false;
    private void Start()
    {
       rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(WaitforPlayer());
    }
    private void Update()
    {
        GameObject playerobject = GameObject.FindGameObjectWithTag("Player");

        if(transform.position.x >= playerobject.transform.position.x)
        {
            gameOverObject.SetActive(true);

        }
    }
    private void FixedUpdate()
    {
        if(StartAttack) 
        {
            rb2d.velocity = new Vector2(SpeedWall, 0f);
        }
       
    }

    public float speed()
    {
        float speed;
        speed  = SpeedWall;
        return speed;

    }    
    IEnumerator WaitforPlayer()
    {
        
        yield return new WaitForSeconds(20f);
        StartAttack = true;
    }
}
