using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject playerObject; 
    public float LifeSpawnCooldown;

    public enum CurrentState
    {
        PLAYING = 1,
        WATCHING_UI = 2,
    }

    public CurrentState state;
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

    public GameObject getPlayer()
    {
        if (playerObject == null)
            return GameObject.FindGameObjectWithTag("Player");
        else
            return playerObject;
    }

    public PlayerStats getPlayerStats()
    {
        if (playerStats == null)
            return getPlayer().GetComponent<PlayerStats>();
        else
            return playerStats;
    }

    // Para spawnear al jugador
    public void spawnPlayer()
    {
        getPlayerStats().IncreaseHealth(PlayerStats.MaxHealth);
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        GameObject spawnpoint = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];


        getPlayer().transform.position = spawnpoint.transform.position;
        Debug.Log("PLAYER HAS BEEN SPAWNED");
    }


    // Para spawnear una vida
    public GameObject spawnLife()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("EntitySpawnPoint");
        int length = spawnPoints.Length;

        if (length == 0)
            return null;

        GameObject spawnpoint = spawnPoints[Random.Range(0, length - 1)];

        GameObject lifeEntity = GameManager.CreateEntity(AssetManager.instance.LifeEntityPrefab, spawnpoint.transform.position);
        //GameManager.CreateEffect(AssetManager.instance.ResurrectionLightEffect, spawnpoint.transform.position);
        
        return lifeEntity;
    }

    void Awake()
    {
        MakeSingleton();
        playerStats = getPlayer().GetComponent<PlayerStats>();

        Invoke("startSpawningLifes", LifeSpawnCooldown);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime < nextUpdate) return;
        nextUpdate += 2f;

        if (state == CurrentState.PLAYING)
            getPlayerStats().IncreaseCalories(15);
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
        state = CurrentState.WATCHING_UI;
    }    

    public void EatFruit(GameObject fruit)
    {
        GoodFruit realFuit = fruit.GetComponent<GoodFruit>();
        realFuit.onEat(getPlayer());
        // Destroy(fruit);
    }
}
