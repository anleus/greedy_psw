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

    void Awake()
    {
        MakeSingleton();
        playerStats = playerObject.GetComponent<PlayerStats>();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime < nextUpdate) return;
        nextUpdate += 2f;

        playerStats.IncreaseCalories(15);
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
