using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrespassPU :  BasePowerup
{
    public GameObject powerupEffect;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            PickUp(powerupEffect, other, 2);
            //GetComponent<SpriteRenderer>().enabled = false;
            //GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
