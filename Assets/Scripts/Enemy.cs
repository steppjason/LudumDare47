using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotSpeed = 3f;
    [SerializeField] Rigidbody2D body;

    private GameObject player;
    private Vector3 target;

    private Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        target = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move(){

        if(player.activeInHierarchy){

            //Get the player's current position
            target = player.transform.position;
            direction = (target - transform.position).normalized;

            Debug.Log(direction.normalized);


            //Use Slerp to rotate towards the player's position
            /*transform.rotation = Quaternion.Slerp(
                    transform.rotation, 
                    Quaternion.Euler(new Vector3(0, 0, 
                        Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x) * Mathf.Rad2Deg)), 
                    rotSpeed * Time.deltaTime);*/
        }

        //transform.position += transform.position + direction.normalized * moveSpeed * Time.deltaTime;

        body.MovePosition(body.position + direction.normalized * moveSpeed * Time.deltaTime);
    }

    public void Damage(int damage){

    }
}
