using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{

    private bool eatAllowed;
    private GameObject currentFuit;

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
        } else if(Input.GetKey(KeyCode.S)  || Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector2.down;
        } else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector2.left;
        } else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;
        }

        if(Input.GetKey(KeyCode.C) && eatAllowed) 
        {
            EatFruit();
        }
    }

    private void EatFruit()
    {
        if(currentFuit != null)
        {
            GameManager.instance.EatFruit(currentFuit);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Eatable"))
        {
            currentFuit = collision.gameObject;
            eatAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.Equals(currentFuit))
        {
            currentFuit = null;
            eatAllowed = false;
        }
    }

}
