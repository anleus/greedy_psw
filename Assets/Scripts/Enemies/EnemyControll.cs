﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyControll : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float moveSpeed = 2f;

    float difficulty;
    float realSpeed;

    int waypointIndex = 0;

    public GameObject path;
    private Waypoint[] puntos;

    private int numPuntos;

    private JoseAnimator jose;
    public Vector2 dir;

    void Start() {

        CargarPuntos();
        
        GetDifficulty();

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

        realSpeed = Mathf.Min(0.08f, Mathf.Round(difficulty * moveSpeed * Time.deltaTime * 100f) / 100f);
        
        transform.position = Vector2.MoveTowards(ini, fin, realSpeed);

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

    void GetDifficulty() {
        difficulty = (SceneManager.GetActiveScene().buildIndex + 1) / 2f;
        Debug.Log("Level: " + SceneManager.GetActiveScene().name + "\nDifficulty of level: " + difficulty);
    }
}
