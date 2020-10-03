using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get normalized direction vector and move the player
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);        
        direction.Normalize();

        transform.position += direction * moveSpeed * Time.deltaTime; 

        if(transform.position.x >= 20){
            transform.position = new Vector3(0f, transform.position.y, 0f);
        } else if(transform.position.x <= -20){
            transform.position = new Vector3(0f, transform.position.y, 0f);
        } 

        if(transform.position.y >= 15f){
            transform.position = new Vector3(transform.position.x, 0f, 0f);
        } else if(transform.position.y <= -15f){
            transform.position = new Vector3(transform.position.x, 0f, 0f);
        } 
    }

    
}
