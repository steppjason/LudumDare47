using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 0f;
    [SerializeField] Vector3 direction = new Vector3(0,0,0);
    [SerializeField] int damage = 1;
   

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeInHierarchy && speed > 0){
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    public void SetDirection(Vector3 direction){
        this.direction = direction;
    }

    public void SetSpeed(float speed){
        this.speed = speed;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        gameObject.SetActive(false);

        if(other.gameObject.GetComponent<Enemy>()){
            other.gameObject.GetComponent<Enemy>().Damage(damage);
        }
    }
}
