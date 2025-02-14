using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] TransformSpawn;
    [SerializeField] private GameObject[] EnemyObjectToSpawn;
    [SerializeField] private AnimationCurve SpawnerSpeed; 
    [SerializeField] private float curveDuration = 270f; 
    [SerializeField] private Transform TargetToFollow;
    [SerializeField] private Vector3 offset;

    private int randomizerlocation = 0;
    private bool isRespawn = false;
    private float timer = 0f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private void Update()
    {
        Vector3 direction = new Vector3(TargetToFollow.position.x + offset.x, 0, 0);
        transform.position = direction;
    }

    private IEnumerator SpawnEnemies()
    {
        while (true) 
        {
            if (!isRespawn)
            {
                isRespawn = true;

                float curveValue = SpawnerSpeed.Evaluate(timer / curveDuration);

     
                yield return new WaitForSeconds(curveValue);

            
                Instantiate(EnemyObjectToSpawn[0], TransformSpawn[RandomizerPositionEnemy()].position, Quaternion.identity);

             
                if (timer >= curveDuration)
                {
                    timer = 0f;
                }

                isRespawn = false;
            }

           
            timer += Time.deltaTime;
            yield return null;
        }
    }

    private int RandomizerPositionEnemy()
    {
        int newRandomLocation;

        do
        {
            newRandomLocation = Random.Range(0, TransformSpawn.Length); 
        }
        while (newRandomLocation == randomizerlocation); 

        randomizerlocation = newRandomLocation; 
        return newRandomLocation;
    }
}