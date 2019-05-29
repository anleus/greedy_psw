using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float speed;
    public float stopDistance;

    public Vector2 dir;

    private Transform target;
    private Skypiece_animator dogo;

    void Awake()
    {
        //speed = baseEnemy.speed;
        dogo = GetComponent<Skypiece_animator>();
    }

    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        Vector2 ini = transform.position;
        Vector2 fin = target.position;

        dir = fin - ini;
        dir.Normalize();

        dogo.Facing(dir);

        if (Vector2.Distance(transform.position, target.position) < stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
}
