﻿using System.Collections;
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

    private GameObject Player;

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
            ReduceLifes(1);
            Debug.Log("Vida quitada");
            GameManager.instance.spawnPlayer();
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
            GameManager.CreateEffect(AssetManager.instance.BrokenHeartEffect, new Vector3(0,0,0), Player.transform);
        
        if (lifes == 0)
        {
            Player.SetActive(false);
            // No sé cómo cambiar de escena, no me deja si el player está inactivo
            GameManager.instance.GameOver();
            //Debug.Log("HAS MUERTO");
            //GameManager.instance.MainMenu.GameOver();
            //main.GameOver();
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


