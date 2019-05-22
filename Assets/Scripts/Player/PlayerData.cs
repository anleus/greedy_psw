using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class PlayerData
{
    public int level;
    public int health, lifes, calories;
    public Vector3Ser position;

    // Falta obtener el level
    public PlayerData(PlayerStats ps)
    {
        health = ps.health;
        lifes = ps.lifes;
        calories = ps.calories;

        position = new Vector3Ser(ps.transform.position);
    }
}
