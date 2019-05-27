using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_manager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool menuPaused = false;
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuPaused) { 
                ActivatePauseMenu();

            }
            else {
                QuitPauseMenu();
            }
        }
    }
    
    public void ActivatePauseMenu()
    {
        Debug.Log("ActivatePauseMenu");
        menuPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0; 
    }

    public void QuitPauseMenu()
    {
        Debug.Log("QuitPauseMenu");
        menuPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
    }


    public void GuardarPartida()
    {
        Debug.Log("GAME WAS SAVED");
        GameManager.instance.saveGame();
    } 

    public void CargarPartida()
    {
        Debug.Log("GAME WAS RELOADED");
        GameManager.instance.loadGame();
    }

    public void VolverInicio()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}
