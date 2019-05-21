using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static int MaxLifes = 3;
    public static int MinDamage = 0;
    public static int MaxDamage = 100;

    public int level; // Falta ponerlo al nivel de mapa en el que está

    public int lifes { get; private set; }
    public int calories { get; private set; }
    public int health { get; private set; }

    private GameObject Player;

    void Awake()
    {
        lifes = MaxLifes;
        health = MinDamage;
        calories = 0;

        Player = gameObject;

    }

    void Update()
    {
    }

    //Health Functions
    public void IncreaseDamage(int amount, bool withAnimation = true)
    {
        health = Mathf.Min(MaxDamage, health + amount); // Aumentar el daño pero no por encima de 100
        Debug.Log("Health reduced by " + amount + "\nRemaining lives: " + lifes);

        if (health == MaxDamage)
        {
            ReduceLifes(1);
            Debug.Log("Vida quitada");
            if(lifes != 0) {
                GameManager.instance.spawnPlayer();
            }
            health = MinDamage;
        }
    }

    public void DecreaseDamage(int amount)
    {
        health = Mathf.Max(MinDamage, health - amount); // Reducir el daño pero no por debajo de 0
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
            //Player.SetActive(false);
            GameManager.instance.acceptPlayerInput = false;
            GameManager.instance.GameOver();
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


    // Falta salvar posiciones de objetos y enemigos + usar/asignar estos métodos de abajo donde toca
    public void SavePlayer() {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer() {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        calories = data.calories;
        health = data.health;
        lifes = data.lifes;

        Vector2 position;    
        position.x = data.position[0];
        position.y = data.position[1];    
        transform.position = position;
    }
}


