using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //Límites para mapa pequeño:
    //X[-5.5, 5.5]
    //Y[-3.5, 3.5]


    public GameObject vida;
    private float time;
    public Transform[] spawnpoints;

    void Start()
    {
        time = Random.Range(7f, 15f);
        Debug.Log("Next life coming in: " + time);
        Invoke("spawnLife", time);
    }

    public void spawnLife()
    {
        int sp = Random.Range(0, spawnpoints.Length);
        Instantiate(vida, spawnpoints[sp].position, Quaternion.identity);
    }

}
