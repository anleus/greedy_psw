using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public static int maxLifes = 5;

    public int lifes;
    public int calories;
    public int health;

    void Awake()
    {
        lifes = maxLifes;
        calories = 0;
        health = 100;
    }

    void Update()
    {
 
    }

    public void ReduceHealth(int quantity)
    {
        // Llamar antes a un método que controle que no te has muerto o que no te pasas de vida (cuando añadamos)
        health -= quantity;
    }
}


