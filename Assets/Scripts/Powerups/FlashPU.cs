using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashPU : BasePowerup
{
    public GameObject powerupEffect;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            PickUp(powerupEffect, other, 1);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
