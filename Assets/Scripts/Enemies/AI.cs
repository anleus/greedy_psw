﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float speed;
    public float stopDistance;

    private Transform target;
    //private Base_enemy baseEnemy;

    void Awake()
    {
        //speed = baseEnemy.speed;
    }

    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("enemy");
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
}
