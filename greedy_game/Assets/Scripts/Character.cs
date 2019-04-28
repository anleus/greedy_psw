using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    protected Vector2 direction;

    protected Animator animator;

    void Start()
    {
        
    }

    protected virtual void Update()
    {
        Move();
    }

    protected void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        AnimCharacter(direction);
    }

    public void AnimCharacter(Vector2 direction) 
    {
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);        
        animator.SetBool("stop", (direction.x == 0f && direction.y == 0f));        
    }
}
