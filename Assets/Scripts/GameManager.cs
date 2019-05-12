using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject playerObject; // Referencia a nuestro GameObject del mono para poder hacer con el lo que queramos en el futuro (se lo enchufamos desde unity arrastrando el mono)


    public PlayerStats playerStats; // Lo sacamos en awake del playerObject para no hacer getComponent tol rato

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
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("EntitySpawnPoint");
        GameObject spawnpoint = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];


        GameObject lifeEntity = GameManager.CreateEntity(AssetManager.instance.LifeEntityPrefab, spawnpoint.transform.position);
        //GameManager.CreateEffect(AssetManager.instance.ResurrectionLightEffect, spawnpoint.transform.position);
        
        return lifeEntity;
    }

    void Awake()
    {
        MakeSingleton();
        playerStats = playerObject.GetComponent<PlayerStats>();

        //startSpawningLifes();
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
        Invoke("startSpawningLifes", 2f);
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



    
}
