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
        //main = GetComponent<MainMenu>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R");
            //StartCoroutine(Death());
            Player.SetActive(false);
        }
    }

    //Health Functions
    public void ReduceHealth(int amount, bool withAnimation = true)
    {
        Debug.Log("Health reduced by " + amount);
        health = Mathf.Max(0, health - amount); // Reducir la vida pero no por debajo de cero.

        if (health == 0)
        {
            Player.transform.position = new Vector3(0.5f,0.5f,0f);
            ReduceLifes(1);
        }
    }

    public void IncreaseHealth(int amount)
    {
        health = Mathf.Max(MaxHealth, health + amount); // Aumentar la vida pero no por encima de MaxHealth.
    }


    //Lifes Functions
    public void ReduceLifes(int amount, bool withAnimation = true)
    {
        Debug.Log("Life reduced by " + amount);
        lifes = Mathf.Max(0, lifes - amount); // Reducir las lifes pero no por debajo de cero.

        if (withAnimation)
            GameManager.CreateEffect(myPrefab, new Vector3(0,0,0), Player.transform);
        
        if (lifes == 0)
        {
            Player.SetActive(false);
            Debug.Log("HAS MUERTO");
            main.Dep();                 //No funciona
        }
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


