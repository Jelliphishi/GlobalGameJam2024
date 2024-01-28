// Manages the state of the game
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardManager;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    // When game starts, go to first state
    void Start() => ChangeState(GameState.Starting);

    public void ChangeState(GameState newState){
        
        State = newState;
        switch (newState){
            case GameState.Starting:
                HandleStarting();
                break;
            case GameState.BeginTurn:
                break;
            case GameState.PlayCard;
                break;
            case GameState.EndPlaying:
                break;
        }
    }

    private void HandleStarting(){
        // spawn audience, cards, background

        audience * currentAud = audienceFactory();
        
        
        if()

        ChangeState();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
