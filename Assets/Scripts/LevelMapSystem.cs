using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class GameObjectWithFloat
{
    public GameObject gameObject;
    [Range(0f, 1f)] public float Occurrence;
}
public class LevelMapSystem : MonoBehaviour
{
    [SerializeField] private Transform LevelStart;
    [SerializeField] private Transform LevelEnd;

    [SerializeField] private Transform PlayerPosition;

    [SerializeField] private Transform EnemyPosition;

    [SerializeField] private TextMeshProUGUI ProgresUI;

    [SerializeField] private Slider EnemyProgres;

    [SerializeField] private Slider ProgresSlider;
    [SerializeField] private EnemyWallBehawiure enemyWallBehawiure;

    [SerializeField] private GameObjectWithFloat[] enemyspawn;


    private float timer = 20f;

    private bool startTimer = false;
    void Start()
    {
        StartCoroutine(WaitforPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelStart == null || LevelEnd == null || PlayerPosition == null || EnemyPosition == null || ProgresUI == null || EnemyProgres == null || ProgresSlider == null)
        {
            Debug.LogError("Nie wszystkie wymagane obiekty s¹ przypisane w inspektorze.");
            return;
        }

        float Result = Mathf.InverseLerp(LevelStart.position.x, LevelEnd.position.x, PlayerPosition.position.x);

        ProgresSlider.value = Result;

        float ResultEnemy = Mathf.InverseLerp(LevelStart.position.x, LevelEnd.position.x, EnemyPosition.position.x);
        EnemyProgres.value = ResultEnemy;

        if (startTimer) 
        {
            if (enemyWallBehawiure != null)
            {
                float speed = enemyWallBehawiure.speed();
                float distanceToTarget = Vector2.Distance(EnemyPosition.position, LevelEnd.position);
                float timeToTarget = CalculateTimeToTarget(distanceToTarget, speed, 0);





                ProgresUI.text =  FormatSecoundandMinutes((int)timeToTarget);
            }
            else
            {
                ProgresUI.text = "N/A"; // Jeœli EnemyWallBehawiure nie istnieje, wyœwietl "N/A"
            }


        }
        else
        {
            
                timer -= Time.deltaTime;
            ProgresUI.text = "MASZ PRZEJEBANE ZA :  " + timer.ToString("F1");

        }





    }


        public float CalculateTimeToTarget(float distance, float speed, float deceleration)
        {
            if (deceleration <= 0)
            {
                // Jeœli nie ma deceleracji, czas = odleg³oœæ / prêdkoœæ
                return distance / speed;

            }
            float time = (Mathf.Sqrt(2 * deceleration * distance + speed * speed) - speed) / deceleration;
            return time;
        }

    private string FormatSecoundandMinutes(int TotalSecounds)
    {

        int minutes = TotalSecounds / 60;
        int secounds = TotalSecounds % 60;

        return $"{minutes:D2}:{secounds:D2}  ";

    }

    IEnumerator WaitforPlayer()
    {

        yield return new WaitForSeconds(20f);
        startTimer = true;
    }



}


