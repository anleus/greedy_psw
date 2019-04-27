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

    [Range(1f, 100f)]
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        oldPosition = transform.position;
    }

    void Update()
    {
        currentPosition = transform.position;
        Controller();  

        //limitDistance();
    }

    private void Controller()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) rb.velocity = new Vector2(speed, 0);
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) rb.velocity = new Vector2(speed * -1f, 0);
        else if (Input.GetKeyDown(KeyCode.UpArrow)) rb.velocity = new Vector2(0, speed);
        else if (Input.GetKeyDown(KeyCode.DownArrow)) rb.velocity = new Vector2(0, speed * -1);
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
