using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class PlayerData
{
    public int level;
    public int health, lifes, calories;
    public float[] position;

    // Falta obtener el level
    public PlayerData(PlayerStats ps)
    {
        health = ps.health;
        lifes = ps.lifes;
        calories = ps.calories;

        position = new float[3];
        position[0] = ps.transform.position.x;
        position[1] = ps.transform.position.y;
        //position[2] = ps.transform.position.z;
    }
}
