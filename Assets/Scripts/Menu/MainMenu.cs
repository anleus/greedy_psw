using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Nota: este script se empleará para todas las pantallas que tengan menu
    // (la principal, la de game over, etc)
    public void PlayGame()
    {
        if (GameManager.instance != null)
            GameManager.instance.state = GameManager.CurrentState.PLAYING;

        SceneManager.LoadScene("Scenes/Map01_update");
    }

     public void QuitGame()
    {
        Application.Quit();
    }
}
