using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Enemy : MonoBehaviour
{
    protected GameManager gameManager;
    private Rigidbody2D rb;

    public int damageInflicted; //cuantas vidas quitará de golpe el enemigo
    public float speed;

    void Awake()
    {
        gameManager = GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Movement() { }
   
}
