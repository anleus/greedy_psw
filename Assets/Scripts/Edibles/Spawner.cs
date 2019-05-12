using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //Límites para mapa pequeño:
    //X[-5.5, 5.5]
    //Y[-3.5, 3.5]


    public GameObject vida;
    public GameObject effect;

    private float time;

    public Transform[] spawnpoints;

    private bool hasSpawned = false;

    void Start()
    {
        time = Random.Range(7f, 15f);
        Debug.Log("Next life coming in: " + time);
        if (!hasSpawned)
        {
            Invoke("spawnLife", time);
        }
    }

    public void spawnLife()
    {
        hasSpawned = true;
        int sp = Random.Range(0, spawnpoints.Length);
        GameManager.CreateEffect(effect, spawnpoints[sp].position);
        Instantiate(vida, spawnpoints[sp].position, Quaternion.identity);
    }

}
