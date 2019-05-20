using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // Referencia a nuestro GameObject del mono para poder hacer con el lo que queramos en el futuro (se lo enchufamos desde unity arrastrando el mono
    public GameObject playerObject; 
    public float LifeSpawnCooldown;
    public SpriteRenderer spriteRenderer;
    public bool acceptPlayerInput;

    public enum CurrentState
    {
        PLAYING = 1,
        WATCHING_UI = 2,
    }

    public CurrentState state;
    // Lo sacamos en awake del playerObject para no hacer getComponent tol rato
    public PlayerStats playerStats; 
    public Animator anim;

    public int lifes { get; private set; }
    public int calories { get; private set; }
    public int damageReceived { get; private set; }


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

    public void PlaySound(AudioClip sound)
    {
        SoundManager.instance.getAvailableAudioSource().PlayOneShot(sound, 1f);
    }

    public GameObject getPlayer()
    {
        if (playerObject == null)
        {
            playerObject = GameObject.FindGameObjectWithTag("Player");
            return playerObject;
        }
        else
            return playerObject;
    }

    public PlayerStats getPlayerStats()
    {
        if (playerStats == null)
        {
            if (getPlayer() != null)
                return getPlayer().GetComponent<PlayerStats>();
            else
                return null;
        }
        else
            return playerStats;
    }

    public Animator getAnim()
    {
        if (anim == null)
        {
            anim = GameObject.Find("CanvasBlackFade").GetComponent<Animator>();
        }

        return anim;
    }

    // Para spawnear al jugador
    public void spawnPlayer()
    {
        //getPlayerStats().DecreaseDamage(PlayerStats.MinDamage);
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

        return lifeEntity;
    }

    public GameObject getRandomFreeSpawnpoint()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("EntitySpawnPoint");
        if (spawnPoints.Length == 0)
            return null;

        GameObject spawnpoint = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];
        int attempts = 0;
        while (spawnpoint.GetComponent<SpawnPointLogic>().isBeingUsed)
        {
            spawnpoint = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];
            if ((attempts++) > spawnPoints.Length)
                return null;  // RETURN NULL CAUSE THERE ARE NO FREE SPAWNPOINTS
        }

        return spawnpoint;
    }


    // Para spawnear una fruta o verdura
    public GameObject spawnRandomEdible(int posInArray = -1)
    {

        GameObject spawnPoint = getRandomFreeSpawnpoint();   
        if (spawnPoint == null)
            return null;  // NO FREE SPAWNPOINTS

        // Start Picking What Edible To Spawn
        Debug.Log("PosInArray: " + posInArray);
        if (posInArray == -1)
            posInArray = Random.Range(0, AssetManager.instance.fruitsVegetablesPrefabs.Length);

        
        while(posInArray > (AssetManager.instance.fruitsVegetablesPrefabs.Length - 1))
        {
            posInArray = posInArray - AssetManager.instance.fruitsVegetablesPrefabs.Length;
        }
        // End Picking What Edible To Spawn


        GameObject edible = GameManager.CreateEntity(AssetManager.instance.fruitsVegetablesPrefabs[posInArray], spawnPoint.transform.position);
        edible.GetComponent<BaseEdible>().currentSpawnPoint = spawnPoint.GetComponent<SpawnPointLogic>();
        spawnPoint.GetComponent<SpawnPointLogic>().UseSpawnPoint(edible);
        //Set the Parent of the Edible
        edible.transform.SetParent(GameObject.Find("Edibles").transform);

        return edible;
    }

    public void spawnEdibles(int amount)
    {
        for (int i = 0; i < amount; i++)
            spawnRandomEdible(i);
    }

    void Awake()
    {
        MakeSingleton();
        playerStats = getPlayer().GetComponent<PlayerStats>();

        Invoke("startSpawningLifes", LifeSpawnCooldown);
    }

    private void Update()
    {
        PlayerStats stats = getPlayerStats();
        if (stats != null)
        {
            calories = stats.calories;
            damageReceived = stats.health;
            lifes = stats.lifes;
        }
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
        //Si no os funciona, coged el animator del Canvas que tiene BlackFade
        //y arrastradlo a GameManager
        Animator playerAnimator = getPlayer().GetComponent<Animator>();
        playerAnimator.SetBool("isDead", true);
        //getAnim().SetTrigger("gameOver");
        Invoke("ChangeToGameOver", 2f);
    }

    private void ChangeToGameOver()
    {
        SceneManager.LoadScene("Scenes/GameOver");
        state = CurrentState.WATCHING_UI;
    }    

    public void EatFruit(GameObject o)
    {
        GoodVegetable vegetable;
        GoodFruit fruit;

        BaseEdible edible = o.GetComponent<BaseEdible>();

        if (edible is GoodVegetable)
        {
            vegetable = (GoodVegetable)edible;
            vegetable.onEat(getPlayer());
        }
        else if (edible is GoodFruit)
        {
            fruit = (GoodFruit)edible;
            fruit.onEat(getPlayer());
        }

        GameObject[] fruitsList = GameObject.FindGameObjectsWithTag("Eatable");

        if (fruitsList.Length == 1)
        {
            Win();
        }
    }

    public void Win()
    {
        //Si no os funciona, coged el animator del Canvas que tiene BlackFade
        //y arrastradlo a GameManager
        getAnim().SetTrigger("gameOver");
        Invoke("ChangeToWin", 1f);
    }

    private void ChangeToWin()
    {
        DontDestroyOnLoad(playerObject);
        SceneManager.LoadScene("Scenes/YouWin");
        state = CurrentState.WATCHING_UI;
    }
}
