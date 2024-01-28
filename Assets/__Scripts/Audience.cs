using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

// make sure to finish adding these
const string[] types = [
    "crude",
    "political",
    "pun",
    "satire"
];


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
    // purely visual, derived from preferences
    private int[] ageBracket;
    // represents how inpactful each joke is on the laughometer (goes for both decreases and increases); has to do with how diverse the crowd is
    // low propensity = lower impact on laughometer
    // high probensity = higher impact on laughometer
    // should only be 0.5-1
    private float propensity;
    // how high the happiness is at the moment
    // 0-100
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

// audience level is an int from 1-5
public audience * audienceFactory(int audienceLevel){
    Dictionary<string, float> preferences;

    for (string type in types){
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
    return new audience(preferences_in, ageBracket, propensity, laughingness, members, wealth);
} 

public class NormalDistribution {
    private double m_factor;

    public NormalDistribution(double mean, double sigma)
    {
        Mean = mean;
        Sigma = sigma;
        Variance = sigma * sigma;
    }

    public double Mean { get; private set; }

    public double Variance { get; private set; }

    public double Sigma { get; private set; }

    private bool m_useLast;

    private double m_y2;

    /// summary
    /// Sample a value from distribution for a given random varible.
    /// /summary
    /// param name="rnd">Generator for a random varible between 0-1 (inculsive)/param
    /// returns A value from the distribution/returns
    public double Sample()
    {
        System.Random rnd = new System.Random();
        double x1, x2, w, y1;

        if (m_useLast)
        {
            y1 = m_y2;
            m_useLast = false;
        }
        else
        {
            do
            {
                x1 = 2.0 * rnd.NextDouble() - 1.0;
                x2 = 2.0 * rnd.NextDouble() - 1.0;
                w = x1 * x1 + x2 * x2;
            }
            while (w >= 1.0);

            w = Math.Sqrt(-2.0 * Math.Log(w) / w);
            y1 = x1 * w;
            m_y2 = x2 * w;
            m_useLast = true;
        }

        return Mean + y1 * Sigma;
    }
}