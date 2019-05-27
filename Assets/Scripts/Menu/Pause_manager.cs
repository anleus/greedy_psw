using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_manager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gameManager = GameManager.instance;
    //public Canvas menuPause;
    public GameObject pauseMenuUI;
    //public bool menuPaused = false;

    /*
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.onGamePaused();
            //menuPause.enabled = !menuPause.enabled;
        }
    }
     */

    public void QuitPauseMenu()
    {
        pauseMenuUI.SetActive(false);
        //menuPaused = false;
        //gameManager.onGamePaused();
        //menuPause.enabled = !menuPause.enabled;
    }

    public void ActivatePauseMenu()
    {
        pauseMenuUI.SetActive(true);
        //menuPaused = true;
    }

    public void GuardarPartida()
    {
        Debug.Log("GAME WAS SAVED");
        gameManager.saveGame();
    } 

    public void CargarPartida()
    {
        Debug.Log("GAME WAS RELOADED");
        gameManager.loadGame();
    }

    public void VolverInicio()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}
