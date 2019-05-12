using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator anim;
    // Nota: este script se empleará para todas las pantallas que tengan menu
    // (la principal, la de game over, etc)
    public void PlayGame()
    {
        SceneManager.LoadScene("Scenes/Map01_update");
    }

     public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        anim.SetTrigger("gameOver");
        Invoke("ChangeToGameOver", 2f);
        //Debug.Log("Game Over, waiting 2 seconds until I switch scenes");
        //StartCoroutine("waitTwoSeconds");
        //Debug.Log("Switching...");
    }

    void ChangeToGameOver()
    {
        SceneManager.LoadScene("Scenes/GameOver");
    }
}
