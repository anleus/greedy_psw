using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool isEnemy;
    private Rigidbody2D rb;

    private float maxMoveTimer;
    private float moveTimer;

    public Grid ground;
    //public Tilemap obstacles;

    public float moveTime = .1f;
    public float inverseMoveTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inverseMoveTime = 1f / moveTime;
    }

    void Update()
    {
        int horizontal = 0;
        int vertical = 0;

        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        vertical = (int)(Input.GetAxisRaw("Vertical"));

        if ( horizontal != 0 ) vertical = 0;

        if (horizontal != 0 || vertical != 0)
        {
          //StartCoroutine(Controller(horizontal, vertical));
          Controller(horizontal, vertical);
          }
    }

    private void Controller(int x, int y)
    {
      Vector2 startC = transform.position;
      Vector2 endC = startC + new Vector2(x, y);

      float remaining = (startC - endC).sqrMagnitude;
      while (remaining > float.Epsilon)
      {
        Vector2 newV = Vector2.MoveTowards(rb.position, endC, inverseMoveTime * Time.deltaTime);
        rb.MovePosition(newV);
        remaining = (startC - endC).sqrMagnitude;
        //yield return null;
      }

        // if (Input.GetKeyDown(KeyCode.RightArrow)) rb.velocity = new Vector2(speed, 0);
        // else if (Input.GetKeyDown(KeyCode.LeftArrow)) rb.velocity = new Vector2(speed * -1f, 0);
        // else if (Input.GetKeyDown(KeyCode.UpArrow)) rb.velocity = new Vector2(0, speed);
        // else if (Input.GetKeyDown(KeyCode.DownArrow)) rb.velocity = new Vector2(0, speed * -1);
    }
}
