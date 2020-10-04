using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotSpeed = 3f;
    [SerializeField] Rigidbody2D body;

    [SerializeField] Animator animator;

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
        direction.Normalize();
        animator.SetInteger("Direction", GetDirection());

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

        var splatter = SplatterController.GetAvailble();
        splatter.gameObject.SetActive(true);
        splatter.gameObject.transform.position = transform.position;
    }


    private int GetDirection(){
        
        if(direction.y <= -0.95){
            return 5;
        } else if(direction.y >= 0.95){
            return 1;
        } else if(direction.x <= -0.95){
            return 7;
        } else if(direction.x >= 0.95){
            return 3;
        } else if(direction.y < 0 && direction.x < 0){
            return 6;
        } else if(direction.y > 0 && direction.x < 0){
            return 8;
        } else if(direction.y > 0 && direction.x > 0){
            return 2;
        } else if(direction.y < 0 && direction.x > 0){
            return 4;
        } else {
            return 0;
        }
        
    }

    
}
