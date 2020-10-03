using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Rigidbody2D body;

    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));        
        direction.Normalize();
 
        if(transform.position.x > 10){
            transform.position = new Vector3(-10f, transform.position.y, 0f);
        } else if(transform.position.x < -10){
            transform.position = new Vector3(10f, transform.position.y, 0f);
        } 

        if(transform.position.y > 7.5f){
            transform.position = new Vector3(transform.position.x, -7.5f, 0f);
        } else if(transform.position.y < -7.5f){
            transform.position = new Vector3(transform.position.x, 7.5f, 0f);
        }
    }

    private void FixedUpdate() {
        body.MovePosition(body.position + direction * moveSpeed * Time.deltaTime);
    }
}
