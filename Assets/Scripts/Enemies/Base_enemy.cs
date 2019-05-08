using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_enemy : Enemy { 


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
            collision.gameObject.GetComponent<PlayerStats>().ReduceHealth(5);
        }
    }
}
