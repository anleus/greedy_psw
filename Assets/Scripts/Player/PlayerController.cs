using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    void Start () 
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInput();
    }


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void GetInput()
    {
        direction = Vector2.zero;
        // Arriba
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector2.up;
        }

        // Abajo
        if(Input.GetKey(KeyCode.S)  || Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector2.down;
        }

        // Izquierda
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector2.left;
        }

        // Derecha
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;
        }
    }


}
