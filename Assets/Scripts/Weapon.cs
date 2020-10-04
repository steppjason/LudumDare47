using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Projectile[] projectiles;
    [SerializeField] int numberOfProjectiles = 20;
    [SerializeField] GameObject parentProjectile;
    [SerializeField] int currentPowerLevel = 0;
    [SerializeField] AudioClip clip;

    [SerializeField] Game game;

    private AudioManager audio;

    private Projectile[,] bulletList;
    private int nextBullet = 0;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateBullets();
        audio = game.GetComponent<AudioManager>();
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
        bulletList[currentPowerLevel, nextBullet].transform.position = transform.position;
        bulletList[currentPowerLevel, nextBullet].SetDirection(target);
        bulletList[currentPowerLevel, nextBullet].gameObject.SetActive(true);
        audio.PlaySFX(clip);
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
