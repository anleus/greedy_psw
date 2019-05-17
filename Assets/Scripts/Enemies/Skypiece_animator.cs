using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skypiece_animator : MonoBehaviour
{
    private Animator dogo;

    void Start()
    {
        dogo = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Facing(Vector2 dir)
    {
        if (dir.x < 0 && dir.y == 0)
        {
            //Debug.Log("FacingLeft");
            dogo.SetBool("face_left", true);
            dogo.SetBool("face_right", false);
            dogo.SetBool("face_up", false);
            dogo.SetBool("face_down", false);
        }
        else if (dir.x > 0 && dir.y == 0)
        {
            // Debug.Log("FacingRight");
            dogo.SetBool("face_left", true);
            dogo.SetBool("face_right", false);
            dogo.SetBool("face_up", false);
            dogo.SetBool("face_down", false);
        }
        else if (dir.y > 0 && dir.x == 0)
        {
            //Debug.Log("FacingUp");
            dogo.SetBool("face_left", true);
            dogo.SetBool("face_right", false);
            dogo.SetBool("face_up", false);
            dogo.SetBool("face_down", false);
        }
        else if (dir.y < 0 && dir.x == 0)
        {
            //Debug.Log("FacingDown");
            dogo.SetBool("face_left", true);
            dogo.SetBool("face_right", false);
            dogo.SetBool("face_up", false);
            dogo.SetBool("face_down", false);
        }
    }
}
