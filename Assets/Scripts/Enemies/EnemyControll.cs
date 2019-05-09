﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float moveSpeed = 2f;

    int waypointIndex = 0;

    public GameObject path;
    private Waypoint[] puntos;

    private int numPuntos;

    private JoseAnimator jose;
    public Vector2 dir;

    void Start() {

        CargarPuntos();

        transform.position = waypoints[waypointIndex].transform.position;

        jose = GetComponent<JoseAnimator>();

    }
    
    void Update()
    {
        Move();
    }

    void Move() {
        Vector2 ini = transform.position;
        Vector2 fin = waypoints[waypointIndex].transform.position;

        dir = fin - ini;
        dir.Normalize();

        jose.Facing(dir);

        Debug.Log(dir);

        transform.position = Vector2.MoveTowards(ini, fin, moveSpeed * Time.deltaTime);

        if (transform.position == waypoints[waypointIndex].transform.position) {
            waypointIndex += 1;
        }

        if (waypointIndex == waypoints.Length)
            waypointIndex = 0;
    }

    void CargarPuntos()
    {
        puntos = path.GetComponentsInChildren<Waypoint>();
        numPuntos = puntos.Length;

        waypoints = new Transform[numPuntos];

        int i = 0;

        foreach (Waypoint p in puntos) {
            waypoints[i] = p.transform;
            i++;
        }

    }
}
