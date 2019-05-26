using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrespassPU :  BasePowerup
{
    public GameObject powerupEffect;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PickUp(powerupEffect, other, 2);
        }
    }
}
