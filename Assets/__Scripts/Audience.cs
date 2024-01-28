using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class Audience : MonoBehaviour
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


    string[] types = {
    "crude",
    "political",
    "pun",
    "satire"
    };
    public Audience(Dictionary<string, float> preferences_in, int [] ageBracket_in, float propensity_in, int laughingness_in, int members_in, int wealth_in)
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
            }else{
                do
                {
                x1 = 2.0 * rnd.NextDouble() - 1.0;
                x2 = 2.0 * rnd.NextDouble() - 1.0;
                w = x1 * x1 + x2 * x2;
                } while (w >= 1.0);

                w = Math.Sqrt(-2.0 * Math.Log(w) / w);
                y1 = x1 * w;
                m_y2 = x2 * w;
                m_useLast = true;
            }
                return Mean + y1 * Sigma;
        }
    }
}
