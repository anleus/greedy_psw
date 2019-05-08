using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int MaxLifes = 5;
    public static int MaxHealth = 100;


    public int lifes { get; private set; }
    public int calories { get; private set; }
    public int health { get; private set; }

    void Awake()
    {
        lifes = MaxLifes;
        health = MaxHealth;
        calories = 0;
    }

    void Update()
    {
 
    }

    //Health Functions
    public void ReduceHealth(int amount)
    {
        health = Mathf.Max(0, health - amount); // Reducir la vida pero no por debajo de cero.
    }

    public void IncreaseHealth(int amount)
    {
        health = Mathf.Max(MaxHealth, health + amount); // Aumentar la vida pero no por encima de MaxHealth.
    }


    //Lifes Functions
    public void ReduceLifes(int amount)
    {
        lifes = Mathf.Max(0, lifes - amount); // Reducir las lifes pero no por debajo de cero.
    }

    public void IncreaseLifes(int amount)
    {
        lifes = Mathf.Max(MaxLifes, lifes + amount); // Aumentar las lifes pero no por encima de MaxLifes.
    }


    //Calories Functions
    public void ReduceCalories(int amount)
    {
        calories = Mathf.Max(0, calories - amount); // Reducir las calories pero no por debajo de cero.
    }

    public void IncreaseCalories(int amount)
    {
        calories = calories + amount; // Aumentar las calories
    }
}


