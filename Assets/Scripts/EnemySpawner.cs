using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] int enemyCount;

    [SerializeField] GameObject parentEnemies;


    private Enemy[] enemies;
    private int nextEnemy = 0;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateBullets();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InstantiateBullets(){
        enemies = new Enemy[enemyCount];
        for(int i = 0; i < enemyCount; i++){
            enemies[i] = Instantiate(enemy, new Vector3(-25,0,0), Quaternion.identity);
            enemies[i].transform.parent = parentEnemies.transform;
            enemies[i].gameObject.SetActive(false);
        }
    }


    private void GetAvailable(){
        for(int i = 0; i < enemies.Length; i++){
            if(!enemies[i].gameObject.activeInHierarchy){
                nextEnemy = i;
                return;
            }
        }
    }

    public void SpawnEnemies(int day){

        int count = (day - 1) * 2;
        for(int i = 0; i < count; i++){
            GetAvailable();
            
            int pos = Random.Range(1, 5);

            if(pos == 1){
                enemies[nextEnemy].transform.position = new Vector3(Random.Range(-25,25), Random.Range(10,19), 0);
            } else if(pos == 2){
                enemies[nextEnemy].transform.position = new Vector3(Random.Range(-25,25), Random.Range(-10,-19), 0);
            } else if(pos == 3){
                enemies[nextEnemy].transform.position = new Vector3(Random.Range(-25,-14), Random.Range(-19,19), 0);
            } else if(pos == 4){
                enemies[nextEnemy].transform.position = new Vector3(Random.Range(14,25), Random.Range(-19,19), 0);
            } else {    
                enemies[nextEnemy].transform.position = new Vector3(Random.Range(-25,25), Random.Range(10,19), 0);
            }
               
            enemies[nextEnemy].gameObject.SetActive(true);
        }
    }
}
