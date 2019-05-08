using System.Collections;
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
    
    void Start() {

        CargarPuntos();

        transform.position = waypoints[waypointIndex].transform.position;

    }
    
    void Update()
    {
        Move();
    }

    void Move() {
        transform.position = Vector2.MoveTowards(transform.position,
                                               waypoints[waypointIndex].transform.position,
                                               moveSpeed * Time.deltaTime);
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
