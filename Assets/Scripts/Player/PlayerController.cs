using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{

    private bool eatAllowed;
    private GameObject currentFuit;

    // public SpriteRenderer spriteRenderer;

    void Start () 
    {
        GameManager.instance.spriteRenderer = GetComponent<SpriteRenderer>();
        GameManager.instance.acceptPlayerInput = true;
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(GameManager.instance.acceptPlayerInput){
            GetInput();
        } 
        GameManager.instance.spriteRenderer.color = Color.Lerp(GameManager.instance.spriteRenderer.color, Color.white, Time.deltaTime/1.5f);          
        StepSound();
    }


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void GetInput()
    {
        direction = Vector2.zero;

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

        if(Input.GetKey(KeyCode.Space) && eatAllowed) 
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
        /*
        else if(collision.gameObject.tag.Equals("Enemy")) 
        {
            Debug.Log("Choque con enemigo: debe cambiar de color");
        }
         */
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.Equals(currentFuit))
        {
            currentFuit = null;
            eatAllowed = false;
        }
    }

    IEnumerator StepSound()
    {
        while(rigidBody.velocity.x != 0 || rigidBody.velocity.y != 0)
        {
            GameManager.instance.PlaySound(SoundManager.instance.monckeyWalk);
            yield return new WaitForSeconds(0.5f);
        }
    }

}
