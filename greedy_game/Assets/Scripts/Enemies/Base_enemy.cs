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
        if (collision.gameObject.tag == "greedy")
        {
            collision.gameObject.GetComponent<Stats>().lifes -= damageInflicted;
            Debug.Log("joder que daño");
        }
    }
}
