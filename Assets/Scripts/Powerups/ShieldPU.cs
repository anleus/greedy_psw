﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPU :  BasePowerup
{
    public GameObject powerupEffect;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player encountered the shield PU");
            PickUp(powerupEffect, other, 0);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
