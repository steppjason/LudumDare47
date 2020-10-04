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
        int pos = Random.Range(1, 100);

        switch(pos){
            case 8:
                SetSpeech("This is making me dizzy");
                return;
            case 23:
                SetSpeech("Hey, that looks like me");
                return;
            case 54:
                SetSpeech("What is going on here?");
                return;
            case 73:
                SetSpeech("Is there anyone out there?");
                return;
            case 90:
                SetSpeech("I'm running in circles");
                return;
            case 41:
                SetSpeech("Haven't I been here before?");
                return;
            case 81:
                SetSpeech("What do they say about doing the same thing over and over...?");
                return;
            default:
                SetSpeech("");
                return;
        }
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
