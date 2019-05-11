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
        SceneManager.LoadScene("Scenes/Map02");
    }

     public void QuitGame()
    {
        Debug.Log("Has salido del juego");
        Application.Quit();
    }

    public void Dep()
    {
        StartCoroutine(Death());            //No funciona
    }

    IEnumerator Death()
    {
        Debug.Log("Starting coroutine");
        yield return new WaitForSeconds(2f);
        Debug.Log("Finished waiting for seconds, changing scene to GAME OVER");
        SceneManager.LoadScene(2);
        //SceneManager.LoadScene("GameOver");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
