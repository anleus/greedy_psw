using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public static int maxLifes = 5;

    public int lifes;
    private int score;

    public Text lifeScore;


    void Awake()
    {
        lifes = maxLifes;
        score = 0;

        LifeManagement();
        LifeCounter();
    }

    void Update()
    {
        LifeManagement();
        LifeCounter();
    }

    private void LifeManagement()
    {
        if (lifes > 5) lifes = 5;
        if (lifes < 0) lifes = 0;
    }

    private void LifeCounter()
    {
        lifeScore.text = "" + lifes;
    }
}


