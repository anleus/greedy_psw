using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPU :  BasePowerup
{
    public GameObject powerupEffect;

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision entered");
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player entered");
            PickUp(powerupEffect, other, 1);
        }
    }
}
