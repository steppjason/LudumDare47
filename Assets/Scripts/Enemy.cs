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
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }

    private void FixedUpdate() {
        Move();
    }

    public void Move(){

        if(player.activeInHierarchy){
            target = player.transform.position;
            direction = (target - transform.position).normalized;
        }

        body.MovePosition(body.position + direction.normalized * moveSpeed * Time.deltaTime);
    }

    public void Damage(int damage){
        gameObject.SetActive(false);
    }
}
