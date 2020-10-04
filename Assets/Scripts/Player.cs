using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Rigidbody2D body;

    [SerializeField] Text speechBubble;
    [SerializeField] int speechDelay;
    
    [SerializeField] GameObject gun;
    

    private Vector2 direction;

    private bool firstLoop = true;
    private float speechTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speechBubble.transform.position = transform.position + new Vector3(0, 1.4f, 0);

        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));        
        direction.Normalize();
 
        if(transform.position.x > 10){
            transform.position = new Vector3(-10f, transform.position.y, 0f);
            Loop();
        } else if(transform.position.x < -10){
            transform.position = new Vector3(10f, transform.position.y, 0f);
            Loop();
        } 

        if(transform.position.y > 7.5f){
            transform.position = new Vector3(transform.position.x, -7.5f, 0f);
            Loop();
        } else if(transform.position.y < -7.5f){
            transform.position = new Vector3(transform.position.x, 7.5f, 0f);
            Loop();
        }

        
        

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);

        Aim();
        CountSpeechTime();
    }

    private void FixedUpdate() {
        body.MovePosition(body.position + direction * moveSpeed * Time.deltaTime);
    }

    private void Aim(){

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gun.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - gun.transform.position + new Vector3(0,0,90));

        if(gun.transform.rotation.eulerAngles.z >= 0 && gun.transform.rotation.eulerAngles.z < 180){
            gun.GetComponent<SpriteRenderer>().flipX = false;
        } else if(gun.transform.rotation.eulerAngles.z > 180){
            gun.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void Loop(){
        
        if(firstLoop){
            SetSpeech("Wha- What just happened?");
            firstLoop = false;
        } else {
            SayRandom();
        }
        
    }

    private void SayRandom(){
        
    }

    private void EraseText(){
        speechBubble.text = "";
    }

    public void SetSpeech(string str){
        speechBubble.text = str;
        speechTimer = 0;
    }

    private void CountSpeechTime(){
        speechTimer += Time.deltaTime;
        if(speechTimer > speechDelay){
            EraseText();
            speechTimer = 0;
        }
    }
}
