using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStatsData 
{
    public int lifes { get; set; }
    public int calories { get; set; }
    public int health { get; set; }
}
public class PlayerStats : MonoBehaviour
{
    public static int MaxLifes = 3;
    public static int MinDamage = 0;
    public static int MaxDamage = 100;

    private PlayerStatsData m_data;

    public int lifes
    {
        get { return m_data.lifes; }
        set { m_data.lifes = value; }
    }
    public int health
    {
        get { return m_data.health;}
        set { m_data.health = value;}
    }
    public int calories
    {
        get { return m_data.calories; }
        set { m_data.calories = value; }
    }

    

    public int currentLevel { get; set; }

    private GameObject Player;

    public PlayerStats()
    {
        this.m_data = new PlayerStatsData();
    }

    void Awake()
    {
        

        this.lifes = MaxLifes;
        this.health = MinDamage;
        this.calories = 0;

        this.Player = gameObject;

    }

    void Update()
    {
    }

    //Health Functions
    public void IncreaseDamage(int amount, bool withAnimation = true)
    {
        this.health = Mathf.Min(MaxDamage, health + amount); // Aumentar el daño pero no por encima de 100
        Debug.Log("Health reduced by " + amount + "\nRemaining lives: " + lifes);

        if (this.health == MaxDamage)
        {
            ReduceLifes(1);
            Debug.Log("Vida quitada");
            if(this.lifes != 0) {
                GameManager.instance.spawnPlayer();
            }
            this.health = MinDamage;
        }
    }

    public void DecreaseDamage(int amount)
    {
        this.health = Mathf.Max(MinDamage, this.health - amount); // Reducir el daño pero no por debajo de 0
    }


    //Lifes Functions
    public void ReduceLifes(int amount, bool withAnimation = true)
    {
        this.lifes = Mathf.Max(0, lifes - amount); // Reducir las lifes pero no por debajo de cero.
        Debug.Log("Life reduced by " + amount + "\nRemaining lives: " + this.lifes);

        if (withAnimation)
            GameManager.CreateEffect(AssetManager.instance.BrokenHeartEffect, new Vector3(2,-1.5f,0), Player.transform);
        
        if (this.lifes == 0)
        {
            //Player.SetActive(false);
            // Cambio a Game Over
            GameManager.instance.PlaySound(SoundManager.instance.monkeyDeath);
            //GameManager.instance.StopMapMusic();
            GameManager.instance.acceptPlayerInput = false;
            GameManager.instance.GameOver();
        }
    }

    public void IncreaseLifes(int amount)
    {
        this.lifes = Mathf.Min(MaxLifes, this.lifes + amount); // Aumentar las lifes pero no por encima de MaxLifes.
        Debug.Log("Number of lifes increased: " + this.lifes);
    }


    //Calories Functions
    public void ReduceCalories(int amount)
    {
        this.calories = Mathf.Max(0, this.calories - amount); // Reducir las calories pero no por debajo de cero.
    }

    public void IncreaseCalories(int amount)
    {
        this.calories = this.calories + amount; // Aumentar las calories
    }

    public void setCurrentLevel(int level)
    {
        this.currentLevel = level;
    }

    public void LoadPlayerData(PlayerData data) {
        currentLevel = data.level;
        calories = data.calories;
        health = data.health;
        lifes = data.lifes;

        Vector2 position;    
        position.x = data.position.x;
        position.y = data.position.y;    

        transform.position = position;
    }

    public override string ToString()
    {
        return "PlayerStats:  calories: " + calories + " health: " + health + " lifes: " + lifes; 
    }
}


