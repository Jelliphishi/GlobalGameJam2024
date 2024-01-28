// Manages the state of the game
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    // When game starts, go to first state
    /*
    void Start() => ChangeState(GameState.Starting);

    public void ChangeState(GameState newState){
        
        State = newState;
        switch (newState){
            case GameState.Starting:
                HandleStarting();
                break;
            case GameState.BeginTurn:
                break;
            case GameState.PlayCard:
                break;
            case GameState.EndPlaying:
                break;
        }
    }
    */

    private void HandleStarting(){
        // spawn audience, cards, background

        int levelofAudience = 0;
        //TODO; map audience level to something
        Audience currentAud = audienceFactory.create(levelofAudience);

        ChangeState();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

public class audienceFactor{
    // audience level is an int from 1-5
    public Audience create(int audienceLevel){
        Dictionary<string, float> preferences;

        foreach(string type in types){
            preferences[type] = (Random.Range(0,15)/15.0);
        }
        // calculate age bracket
        int [] ageBracket;
        if(preferences["crude"] > 13.0/15){
            ageBracket[0] = 12;
            ageBracket[1] = 18;
        }else if(preferences["risky"] > 13.0/15){
            ageBracket[0] = 19;
            ageBracket[1] = 25;
        }else if(preferences["political"] > 13.0/15){
            ageBracket[0] = 26;
            ageBracket[1] = 35;
        }else if(preferences["satire"] > 13.0/15){
            ageBracket[0] = 36;
            ageBracket[1] = 50;
        }else{
            preferences["pun"] = Random.Range(13,15);
            ageBracket[0] = 51;
            ageBracket[1] = 100;
        }
        // propensity is random
        // Maybe can show "diversity of crowd"
        int propensity = Random.Range(0.5,1);
        // start at the middle
        int laughingness = 50;
        int members;
        int mean = 10*audienceLevel;
        /*
        if(audienceLevel == 1){
        mean = 10


        }else if(audienceLevel == 2){
        mean = 20;
        }else if(audienceLevel == 3){
        mean = 30;
        }else if(audienceLevel == 4){
        mean = 40;
        }
        */
        NormalDistribution audDistribution = NormalDistribution(mean, mean*.4);
        members = static_cast<int>(audDistribution.Sample());
        int wealth;
        if(preferences["crude"] > 10.0){
            wealth = 1;
        }else if(preferences["physical"] > 10.0){
            wealth = 5;
        }else if(preferences["one liner"] > 10.0){
            wealth = 4;
        }else if(preferences["nerdy"] > 10.0){
            wealth = 3;
        }else{
            preferences["political"] = Random.Range(10, 15.0);
        }
        return new Audience(preferences_in, ageBracket, propensity, laughingness, members, wealth);
    }
}