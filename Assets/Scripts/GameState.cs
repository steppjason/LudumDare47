using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [SerializeField] Game game;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(game.GetPauseState()){
            if(Input.GetButtonDown("Jump")){
                SceneManager.LoadScene("Level");
            }
        }
    }
}
