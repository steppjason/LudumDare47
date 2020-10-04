using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Projectile[] projectiles;
    [SerializeField] int numberOfProjectiles = 20;
    [SerializeField] GameObject parentProjectile;
    [SerializeField] int currentPowerLevel = 0;

    private Projectile[,] bulletList;
    private int nextBullet = 0;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateBullets();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){

            
            direction = Input.mousePosition;
            direction.z = 0.0f;
            direction = Camera.main.ScreenToWorldPoint(direction);
            direction.z = 0.0f;

            direction.x = direction.x - transform.position.x;
            direction.y = direction.y - transform.position.y;
            

            Fire(direction.normalized);
            
        }
    }

    public void Fire(Vector3 target){
        GetAvailable();

        Debug.Log("TARGET:" + target);
        Debug.Log("NOT NORMALIZED?:" + (target - transform.position));
        Debug.Log("NORMALIZE?:" + (target - transform.position).normalized);

        bulletList[currentPowerLevel, nextBullet].transform.position = transform.position;
        //bulletList[currentPowerLevel, nextBullet].SetDirection((target - transform.position).normalized);
        bulletList[currentPowerLevel, nextBullet].SetDirection(target);
        
        

        bulletList[currentPowerLevel, nextBullet].gameObject.SetActive(true);
    }


    private void InstantiateBullets(){
        bulletList = new Projectile[projectiles.Length, numberOfProjectiles];
        for(int i = 0; i < numberOfProjectiles; i++){
            for(int j = 0; j < projectiles.Length; j++){
                bulletList[j,i] = Instantiate(projectiles[j], new Vector3(-25,0,0), Quaternion.identity);
                bulletList[j,i].transform.parent = parentProjectile.transform;
                bulletList[j,i].gameObject.SetActive(false);
            }
        }
    }

    private void GetAvailable(){
        for(int i = 0; i < bulletList.Length; i++){
            if(!bulletList[currentPowerLevel, i].gameObject.activeInHierarchy){
                nextBullet = i;
                return;
            }
        }
    }
}
