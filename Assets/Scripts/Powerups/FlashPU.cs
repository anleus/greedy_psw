using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashPU : BasePowerup
{
    public GameObject powerupEffect;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PickUp(powerupEffect, other, 0);
        }
    }
}
