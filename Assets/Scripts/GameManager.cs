﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
<<<<<<< HEAD
    // Referencia a nuestro GameObject del mono para poder hacer con el lo que queramos en el futuro (se lo enchufamos desde unity arrastrando el mono
    public GameObject playerObject; 
=======
    public float LifeSpawnCooldown;
    public GameObject playerObject; // Referencia a nuestro GameObject del mono para poder hacer con el lo que queramos en el futuro (se lo enchufamos desde unity arrastrando el mono)
>>>>>>> 56b7d99d3d34a9d975640ee6db419e0bf90ffe35

    // Lo sacamos en awake del playerObject para no hacer getComponent tol rato
    public PlayerStats playerStats; 

    float nextUpdate = 0f;
    float currentTime = 0f;


    //Para crear particle systems se usa esto
    public static GameObject CreateEffect(GameObject effect, Vector3 position, Transform parent = null)
    {
        Vector3 effectPosition = (parent != null) ? parent.transform.position : position;

        GameObject particleSystem = Instantiate(effect, effectPosition, Quaternion.identity);
        particleSystem.layer = 8; // Particles

        //Debug.Log(parent);
        if (parent != null)
        {
            particleSystem.transform.parent = parent;
            particleSystem.transform.position = position;

            Debug.Log("SHOULD BE PARENT!");
        }

        Debug.Log("Creatin particles: " + effect.name + " in: " + effectPosition);

        return particleSystem;
    }

    public static GameObject CreateEntity(GameObject prefab, Vector3 position, Transform parent = null)
    {
        Vector3 entityPosition = (parent != null) ? parent.transform.position : position;

        GameObject entity = Instantiate(prefab, entityPosition, Quaternion.identity);

        //Debug.Log(parent);
        if (parent != null)
        {
            entity.transform.parent = parent;
            entity.transform.position = position;
        }

        Debug.Log("Created Entity: " + prefab.name + " in: " + entityPosition);

        return entity;
    }

    // Para spawnear al jugador
    public void spawnPlayer()
    {
        playerStats.IncreaseHealth(PlayerStats.MaxHealth);
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        GameObject spawnpoint = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];


        playerObject.transform.position = spawnpoint.transform.position;
        Debug.Log("PLAYER HAS BEEN SPAWNED");
    }


    // Para spawnear una vida
    public GameObject spawnLife()
    {
        Debug.Log("Spawning Life");
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("EntitySpawnPoint");
        GameObject spawnpoint = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];
        Debug.Log("spawnpoint: " + spawnpoint);


        Debug.Log("prefab");
        Debug.Log(AssetManager.instance.NoVa);
        GameObject lifeEntity = GameManager.CreateEntity(AssetManager.instance.NoVa, spawnpoint.transform.position);
        //GameManager.CreateEffect(AssetManager.instance.ResurrectionLightEffect, spawnpoint.transform.position);
        
        return lifeEntity;
    }

    void Awake()
    {
        MakeSingleton();
        playerStats = playerObject.GetComponent<PlayerStats>();

        Invoke("startSpawningLifes", LifeSpawnCooldown);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime < nextUpdate) return;
        nextUpdate += 2f;

        playerStats.IncreaseCalories(15);
    }

    private void startSpawningLifes()
    {
        spawnLife();
        Invoke("startSpawningLifes", LifeSpawnCooldown);
    }

    private void MakeSingleton()
    {
        if (instance != null) { 
            Destroy(gameObject);
        }
        else { 
            instance = this;
            DontDestroyOnLoad(gameObject);
        }      
    }

    public void GameOver()
    {
        // anim.SetTrigger("gameOver");
        Invoke("ChangeToGameOver", 2f);
        //Debug.Log("Game Over, waiting 2 seconds until I switch scenes");
        //StartCoroutine("waitTwoSeconds");
        //Debug.Log("Switching...");
    }

    private void ChangeToGameOver()
    {
        SceneManager.LoadScene("Scenes/GameOver");
    }    

    public void EatFruit(GameObject fruit)
    {
        GoodFruit realFuit = fruit.GetComponent<GoodFruit>();
        realFuit.onEat(playerObject);
        // Destroy(fruit);
    }
}
