using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private float speed = 500f;
    protected Vector2 direction;

    protected Animator animator;
    protected Rigidbody2D rigidBody;

    void Start()
    {
    }

    //FixedUpdate porque es mejor para movimientos
    protected virtual void FixedUpdate()
    {
        Move();
    }

    protected void Move()
    {
        //transform.Translate(direction * speed * Time.deltaTime);
        rigidBody.velocity = direction * speed * Time.deltaTime;
        AnimCharacter(direction);
    }

    public void AnimCharacter(Vector2 direction)
    {
        float xValue = (direction.y != 0) ? 0 : direction.x;
        animator.SetFloat("x", xValue);
        animator.SetFloat("y", direction.y);

        animator.SetBool("stop", direction == Vector2.zero);
    }
}
