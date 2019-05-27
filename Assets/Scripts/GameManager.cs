using static System.DateTime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // Referencia a nuestro GameObject del mono para poder hacer con el lo que queramos en el futuro (se lo enchufamos desde unity arrastrando el mono
    public GameObject playerObject;
    public int timeLimitMap = 60;
    public float LifeSpawnCooldown;
    public SpriteRenderer spriteRenderer;
    public bool acceptPlayerInput;

    public PlayerStatsData[] playerRanking;

    // Para powerups
    public bool shielOn;
    public bool trespasserOn;


    public enum CurrentState
    {
        PLAYING = 1,
        WATCHING_UI = 2,
    }

    public CurrentState state;
    // Lo sacamos en awake del playerObject para no hacer getComponent tol rato
    public PlayerStats playerStats;
    public PlayerController playerController;
    public Animator anim;


    public int lifes { get; private set; }
    public int calories { get; private set; }
    public int damageReceived { get; private set; }
    public float timeLeft { get; private set; }

    private PlayerStatsData playerStatsCopy;


    //Para crear particle systems se usa esto
    public static GameObject CreateEffect(GameObject effect, Vector3 position, Transform parent)
    {
        Vector3 effectPosition = position;

        //Debug.Log("position: " + position + " effectposition: " + effectPosition);
        GameObject particleSystem = Instantiate(effect, effectPosition, Quaternion.identity, parent);
        if (parent != null)
            particleSystem.transform.localPosition = position;
        particleSystem.layer = 8; // Particles

        //Debug.Log("Creatin particles: " + effect.name + " in: " + effectPosition);

        return particleSystem;
    }

    public static GameObject CreateEntity(GameObject prefab, Vector3 position, Transform parent = null)
    {
        Vector3 entityPosition = (parent != null) ? parent.transform.position : position;

        GameObject entity = Instantiate(prefab, entityPosition, Quaternion.identity);

        if (parent != null)
        {
            entity.transform.parent = parent;
            entity.transform.position = position;
        }

        //Debug.Log("Created Entity: " + prefab.name + " in: " + entityPosition);

        return entity;
    }

    public void PlaySound(AudioClip sound)
    {
        SoundManager.instance.getAvailableAudioSource().PlayOneShot(sound, 1f);
    }

    public GameObject getPlayer()
    {
        if (playerObject == null)
            playerObject = GameObject.FindGameObjectWithTag("Player");

        return playerObject;
    }

    public PlayerStats getPlayerStats()
    {
        if (playerStats == null)
            playerStats = getPlayer().GetComponent<PlayerStats>();

        return playerStats;
    }

    public PlayerController getPlayerController()
    {
        if (playerController == null)
            playerController = getPlayer().GetComponent<PlayerController>();

        return playerController;
    }

    public Animator getAnim()
    {
        if (anim == null) 
            anim = GameObject.Find("CanvasBlackFade").GetComponent<Animator>();

        return  anim;
    }

    // Para spawnear al jugador
    public void spawnPlayer()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        GameObject spawnpoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length - 1)];

        getPlayer().transform.position = spawnpoint.transform.position;
        //Debug.Log("PLAYER HAS BEEN SPAWNED");

    }

    public void spawnPlayerFromLastSave()
    {
        PlayerData lastPlayerData = SaveSystem.LoadPlayerData();
        if (lastPlayerData == null)
            return;  // NO HAY NINGUNA PARTIDA GUARDADA

        getPlayerStats().LoadPlayerData(lastPlayerData);
    }

    public void spawnEdiblesFromLastSave()
    {
        EdibleData[] ediblesData = SaveSystem.LoadEdibles();
        if (ediblesData == null  || ediblesData.Length == 0)
            return;  // NO HAY NINGUNA PARTIDA GUARDADA

        foreach (EdibleData edibleData in ediblesData)
        {
            int PrefabIndex = edibleData.prefabIndex;
            Debug.Log("Index: " + PrefabIndex);

            Vector3 entPos = new Vector3(edibleData.currentPosition.x, edibleData.currentPosition.y, edibleData.currentPosition.z);
            GameObject edible = GameManager.CreateEntity(AssetManager.instance.fruitsVegetablesPrefabs[PrefabIndex], entPos);
            edible.GetComponent<BaseEdible>().copyData(edibleData);
        }
    }

    // Para spawnear una vida
    public GameObject spawnLife()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("Lifes_spawns");
        int length = spawnPoints.Length;

        if (length == 0)
            return null;

        GameObject spawnpoint = spawnPoints[Random.Range(0, length - 1)];

        GameObject lifeEntity = GameManager.CreateEntity(AssetManager.instance.LifeEntityPrefab, spawnpoint.transform.position);

        return lifeEntity;
    }

    public GameObject getRandomFreeSpawnpoint()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("Food_spawns");
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
        if (posInArray == -1)
            posInArray = Random.Range(0, AssetManager.instance.fruitsVegetablesPrefabs.Length);


        while(posInArray > (AssetManager.instance.fruitsVegetablesPrefabs.Length - 1))
        {
            posInArray = posInArray - AssetManager.instance.fruitsVegetablesPrefabs.Length;
        }
        // End Picking What Edible To Spawn


        GameObject edible = GameManager.CreateEntity(AssetManager.instance.fruitsVegetablesPrefabs[posInArray], spawnPoint.transform.position);
        edible.GetComponent<BaseEdible>().currentSpawnPoint = spawnPoint.GetComponent<SpawnPointLogic>();
        edible.GetComponent<BaseEdible>().prefabIndex = posInArray;
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

    private void Start()
    {
        timeLeft = GameManager.instance.timeLimitMap;

        playerRanking = SaveSystem.LoadRanking();
        Debug.Log("STARTING " + timeLeft);
        Debug.Log("Ranking");
        for (int i = 0; i < playerRanking.Length; i++)
        {
            if (playerRanking[i] != null)
                Debug.Log("Calories: " + playerRanking[i].calories);
        }

        Time.timeScale = 1f;
    }

    private void Update()
    {
        GameObject player = getPlayer();
        PlayerStats stats;

        timeLeft -= Time.deltaTime;

        if (player != null)
        {
            stats = getPlayerStats();
            if (stats.calories == 0 && (playerStatsCopy != null) && playerStatsCopy.calories > 0 && playerStatsCopy.lifes > 0)
            {
                stats.calories = playerStatsCopy.calories;
                stats.health = playerStatsCopy.health;
                stats.lifes = playerStatsCopy.lifes;
            }
            
            calories = stats.calories;
            damageReceived = stats.health;
            lifes = stats.lifes;

            if (state == CurrentState.PLAYING)
                stats.setCurrentLevel(SceneManager.GetActiveScene().buildIndex);
        }
   
         if (Input.GetKeyDown(KeyCode.F5)) saveGame();

        if (Input.GetKeyDown(KeyCode.F6)) loadGame(); 
    }

    public void onGamePaused() {
        if (Time.timeScale == 1) Time.timeScale = 0;
        else if (Time.timeScale == 0) Time.timeScale = 1;
    }


    private void startSpawningLifes()
    {
        spawnLife();
        Invoke("startSpawningLifes", LifeSpawnCooldown);
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
        Debug.Log("ChangeToGameOver");
        SaveCurrentMatch();

        SceneManager.LoadScene("Scenes/GameOver");
        state = CurrentState.WATCHING_UI;
    }

    private void SaveCurrentMatch()
    {
        PlayerStatsData currentData = new PlayerStatsData();
        currentData.calories = calories;
        currentData.time = System.DateTime.Now;

        int length = 0;
        for (int i = 0; i < 3; i++)
        {
            if (playerRanking[i] != null && playerRanking[i].calories > 0)
                length++;
        }

        if (length < 3)
        {
            Debug.Log("LENGTH IS " + length);
            playerRanking[length] = currentData;
        }
        else
        {
            Debug.Log("Length is 3 wtf");
            for (int i = 2; i <= 0; i--)
                if (playerRanking[i].calories < currentData.calories)
                {
                    playerRanking[i] = currentData;
                    break;
                }
        }
            

        SaveSystem.SaveRanking();
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
        storeStats ();
        DontDestroyOnLoad(playerObject);
        switch (SceneManager.GetActiveScene().buildIndex) {
            case 1 :  SceneManager.LoadScene(2); break;
            case 2 :  SceneManager.LoadScene(3); break;
            case 3 :  SceneManager.LoadScene(4); break;
            case 4 :  SceneManager.LoadScene(5); break;
            default : SceneManager.LoadScene("Scenes/YouWin"); state = CurrentState.WATCHING_UI; break;
        }
        restoreStats();
    }

    protected void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    protected void storeStats()
    {
        playerStatsCopy = new PlayerStatsData();

        playerStatsCopy.calories = playerStats.calories;
        playerStatsCopy.health = playerStats.health;
        playerStatsCopy.lifes = playerStats.lifes;
    }

    public void restoreStats()
    {
        playerStats = new PlayerStats();

        playerStats.IncreaseCalories(playerStatsCopy.calories);
        playerStats.IncreaseDamage(playerStatsCopy.health);
        playerStats.IncreaseLifes(playerStatsCopy.lifes);
    }

    public void resetStats()
    {
        playerStatsCopy = new PlayerStatsData();
        

        if (getPlayer() != null)
        {
            PlayerStats stats = getPlayerStats();
            stats.calories = 0;
            stats.health = 0;
            stats.lifes = 0;
        }

        timeLeft = GameManager.instance.timeLimitMap;
    }

    public void saveGame() {
            Debug.Log("GAME WAS SAVED");
            SaveSystem.SaveGame();

            GameObject pos = GameObject.FindGameObjectWithTag("textPos");
            
        
    }

    public void loadGame() {     
            Debug.Log("GAME WAS RELOADED");
            SaveSystem.LoadGame();
        
    }
}
