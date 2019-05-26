using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_manager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gameManager;
    public Canvas menuPause;

    void Start()
    {
        gameManager = GameManager.instance;
        menuPause.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.onGamePaused();
            menuPause.enabled = !menuPause.enabled;
        }
    }

    public void Continuar()
    {
        menuPause.enabled = !menuPause.enabled;
    }

    public void GuardarPartida()
    {
        Debug.Log("GAME WAS SAVED");
        SaveSystem.SaveGame();
    } 

    public void CargarPartida()
    {
        Debug.Log("GAME WAS RELOADED");
        SaveSystem.LoadGame();
    }

    public void VolverInicio()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}
