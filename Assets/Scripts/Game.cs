using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] Text dayUI;
    [SerializeField] Text timerText;
    [SerializeField] int dayLength = 15;

    [SerializeField] Player player;
    [SerializeField] GameObject enemySpawner;
    [SerializeField] EnemySpawner spawner;

    [SerializeField] GameObject gun;
    [SerializeField] GameObject alien;
    
    private int day = 1;
    private int curDay = 1;
    private float timer;

    private bool dayOne = true;
    private bool dayTwo = true;
    private bool dayThree = true;
    private bool dayFour = true;
    private bool dayNine = true;
    private bool dayTwenty = true;
    private bool dayThirtyFive = true;
    

    // Start is called before the first frame update
    void Start()
    {
        dayUI.text = "Day " + day.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        UpdateDay();
        
    }

    private void UpdateDay(){
        
        if(timer > dayLength){
            day = (int) Mathf.Floor(timer / dayLength) + 1;
        }

        if(curDay != day){
            curDay = day;
            if(enemySpawner.activeInHierarchy){
                spawner.SpawnEnemies(day);
            }
        }

        if(day >= 1 && dayOne){
            dayOne = false;
            player.SetSpeech("Stuck on this planet. Guess I'll explore.");
        }


        if(day >= 2 && dayTwo){
            dayTwo = false;
            player.SetSpeech("Wow, the days are flying by...");
        }

        if(day >= 3 && dayThree){
            dayThree = false;
            enemySpawner.SetActive(true);
            alien.SetActive(true);
            gun.SetActive(true);
            player.SetSpeech("What the fuck is that? Guess I'll shoot it.");
        }

        if(day >= 4 && dayFour){
            dayFour = false;
            player.SetSpeech("More of them!?");
        }


        if(day >= 9 && dayNine){
            dayNine = false;
            player.SetSpeech("This shit is getting old");
        }


        if(day >= 20 && dayTwenty){
            dayTwenty = false;
            player.SetSpeech("My trigger finger is getting tired...");
        }



        if(day >= 35 && dayThirtyFive){
            dayThirtyFive = false;
            player.SetSpeech("How the hell am I still alive!?");
        }

        dayUI.text = "Day " + day.ToString();
    }
}
