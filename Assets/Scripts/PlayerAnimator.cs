using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    
    [SerializeField] Animator animator;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetInteger("Direction", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Get normalized direction vector and move the player
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);        
        direction.Normalize();
        animator.SetInteger("Direction", GetDirection());
    }

    private int GetDirection(){
        
        if(direction.y == -1){
            return 0;
        } else if(direction.y == 1){
            return 4;
        } else if(direction.x == -1){
            return 2;
        } else if(direction.x == 1){
            return 6;
        } else if(direction.y < 0 && direction.x < 0){
            return 1;
        } else if(direction.y > 0 && direction.x < 0){
            return 3;
        } else if(direction.y > 0 && direction.x > 0){
            return 5;
        } else if(direction.y < 0 && direction.x > 0){
            return 7;
        } else {
            return 8;
        }
        
    }
}
