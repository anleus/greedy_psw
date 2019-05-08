using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int _calories;
    private int _lifes;
    private int _lifeBar;

    public bool playerDied;
    float nextUpdate = 0f;
    float currentTime = 0f;

    void Awake()
    {
        MakeSingleton();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime < nextUpdate) return;

        nextUpdate += 2f;
        addCalories(5);
    }


    public int getCalories()
    {
        return _calories;
    }

    public void setCalories(int amount)
    {
        _calories = amount;
    }

    public void addCalories(int amount)
    {
        _calories += amount;
    }

    public void takeCalories(int amount)
    {
        _calories = Mathf.Max(0, _calories - amount);
    }

    public int getLifes()
    {
        return _lifes;
    }

    public void setLives(int amount)
    {
        _lifes = amount;
    }

    public void addLifes(int amount)
    {
        _lifes += amount;
    }

    public void takeLifes(int amount)
    {
        _lifes = Mathf.Max(0, _calories - amount);
    }

    private void MakeSingleton()
    {
        if (instance != null) { 
            Destroy(gameObject);
        }
        else { 
            instance = this;
            DontDestroyOnLoad(gameObject);
        }      
    }
}
