﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skypiece_enemy : Enemy
{
    // Start is called before the first frame update
    void Awake()
    {
        damageInflicted = 1;
        speed = 87.5f;
    }


    protected override void Movement()
    {
        base.Movement(); //de momento
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<PlayerStats>().ReduceHealth(PlayerStats.MaxHealth); // Reducimos toda su vida, por lo que le matamos
            collision.gameObject.GetComponent<PlayerStats>().IncreaseDamage(PlayerStats.MaxDamage);

            GameManager.instance.PlaySound(SoundManager.instance.damage);
            Vector3 effectPosition = transform.position + new Vector3(0f, 1f, 0f);
            GameManager.CreateEffect(AssetManager.instance.StarHitEffect, effectPosition, null);
        }
    }
}
