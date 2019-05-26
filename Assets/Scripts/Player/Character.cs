using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private float speed = 500f;

    // Con powerup de velocidad, setealo a 0.15
    public float stepSoundCooldown = 0.25f;
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

        // animator.SetBool("stop", (rigidBody.velocity == Vector2.zero));
        animator.SetBool("stop", (Input.anyKey == false) && (direction == Vector2.zero));
    }

    // Para powerups
    public void SetPlayerSpeed(float vel) // Speed base = 500f
    {
        if(vel > 500f) {
            stepSoundCooldown = 0.15f;
        } else {
            stepSoundCooldown = 0.25f;
        }
        speed = vel;
    }
}
