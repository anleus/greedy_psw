using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 currentPosition;
    private bool isEnemy;
    private Rigidbody2D rb;
    private Vector2 oldPosition;

    private float maxMoveTimer;
    private float moveTimer;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        oldPosition = transform.position;
        speed = 1000;
    }

    void Update()
    {
        currentPosition = transform.position;
        Controller();  

        limitDistance();
    }

    private void Controller()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) rb.AddForce(Vector2.right * speed);
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) rb.AddForce(Vector2.left * speed);
        else if (Input.GetKeyDown(KeyCode.UpArrow)) rb.AddForce(Vector2.up * speed);
        else if (Input.GetKeyDown(KeyCode.DownArrow)) rb.AddForce(Vector2.down * speed);
    }

    //No acaba de funcionar
    private void limitDistance()
    {
        if (transform.position.x == oldPosition.x + 1f) rb.velocity = Vector3.zero;
        else if (transform.position.x == oldPosition.x - 1f) rb.velocity = Vector3.zero;
        else if (transform.position.y == oldPosition.y + 1f) rb.velocity = Vector3.zero;
        else if (transform.position.y == oldPosition.y - 1f) rb.velocity = Vector3.zero;

        oldPosition = currentPosition;
    }
}
