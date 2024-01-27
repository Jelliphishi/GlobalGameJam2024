using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class audience
{
    // all types, the float representing how much they like it
    private Dictionary<string, float> preferences;
    private int[] ageBracket;
    // represents how inpactful each joke is on the laughometer
    // low propensity = lower impact on laughometer
    // high probensity = higher impact on laughometer
    // should only be 0-1
    private float propensity;
    // how high the happiness is at the moment
    private int laughingness;
    // has to do with how much reputation you get for winning
    private int members;
    // 0-100
    // has to do with how much you are paid and what types of jokes they like
    private int wealth;
    public audience(Dictionary<string, float> preferences_in, int [] ageBracket_in, float propensity_in, int laughingness_in, int members_in, int wealth_in)
    {
        preferences = preferences_in;
        ageBracket = ageBracket_in;
        propensity = propensity_in;
        laughingness = laughingness_in;
        members = members_in;
        wealth = wealth_in;
    }
    public Dictionary<string, float> getPreferences()
    {
        return preferences;
    }
    public int[] getAgeBracket()
    {
        return ageBracket;
    }
    public float getPropensity()
    {
        return propensity;
    }
    public int getLaughingness()
    {
        return laughingness;
    }
    public void incrementLaughingness(int changeAmt)
    {
        laughingness += changeAmt;
    }
    public int getNumMembers()
    {
        return members;
    }
}
