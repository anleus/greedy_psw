﻿using System.Collections;
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
        bool diagonal_right = (dir.x < 0.4 && dir.x >= 0);
        bool diagonal_left = (dir.x > -0.4 && dir.x <= 0);

        //Debug.Log("Dirección perro: x = " + dir.x + "   y = " + dir.y);

        dogo.SetBool("face_left", dir.x < 0);
        dogo.SetBool("face_right", dir.x > 0);
        dogo.SetBool("face_up", dir.y > 0 && (diagonal_right || diagonal_left) );
        dogo.SetBool("face_down", dir.y < 0 && (diagonal_right || diagonal_left) );
    }
}
