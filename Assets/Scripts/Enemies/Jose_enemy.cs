﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jose_enemy : Enemy { 


    void Awake()
    {
        damageInflicted = 1;
        speed = 175f;
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
            Vector3 effectPosition = new Vector3(2f, -2f, 0f);
            GameManager.CreateEffect(AssetManager.instance.StarHitEffect, collision.gameObject.transform.position + effectPosition, null);
        }
    }
}
