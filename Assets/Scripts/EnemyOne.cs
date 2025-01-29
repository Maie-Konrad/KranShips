using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : MonoBehaviour
{
    public float HP;

    public float MaxHP;

    public float speedMovement;

    private void Update()
    {

        transform.position += new Vector3(1 * speedMovement * Time.deltaTime, 0,0);
    }

   
    
}
