using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static int MaxLifes = 5;
    public static int MaxHealth = 100;

    public int lifes { get; private set; }
    public int calories { get; private set; }
    public int health { get; private set; }

    public GameObject myPrefab;

    private GameObject Player;

    private MainMenu main;


    void Awake()
    {
        lifes = MaxLifes;
        health = MaxHealth;
        calories = 0;

        Player = gameObject;
    }

    void Update()
    {
    }

    //Health Functions
    public void ReduceHealth(int amount, bool withAnimation = true)
    {
        health = Mathf.Max(0, health - amount); // Reducir la vida pero no por debajo de cero.
        Debug.Log("Health reduced by " + amount + "\nRemaining lives: " + lifes);

        if (health == 0)
        {
            Player.transform.position = new Vector3(0.5f,0.5f,0f);
            ReduceLifes(1);
        }
    }

    public void IncreaseHealth(int amount)
    {
        health = Mathf.Min(MaxHealth, health + amount); // Aumentar la vida pero no por encima de MaxHealth.
    }


    //Lifes Functions
    public void ReduceLifes(int amount, bool withAnimation = true)
    {
        lifes = Mathf.Max(0, lifes - amount); // Reducir las lifes pero no por debajo de cero.
        Debug.Log("Life reduced by " + amount + "\nRemaining lives: " + lifes);

        if (withAnimation)
            GameManager.CreateEffect(myPrefab, new Vector3(0,0,0), Player.transform);
        
        if (lifes == 0)
        {
            Player.SetActive(false);
            //main.GameOver();          -- No sé cómo cambiar de escena, no me deja si el player está inactivo
            Debug.Log("HAS MUERTO");
        }
    }

    public void IncreaseLifes(int amount)
    {
        lifes = Mathf.Min(MaxLifes, lifes + amount); // Aumentar las lifes pero no por encima de MaxLifes.
        Debug.Log("Number of lifes increased: " + lifes);
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


