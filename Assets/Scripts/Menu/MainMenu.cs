using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI caloriesText;

    public void Start()
    {

    }
    public void Update()
    {
        if (GameManager.instance != null && caloriesText != null)
            caloriesText.text = "Calorias Conseguidas: " + GameManager.instance.calories;
    }
    // Nota: este script se empleará para todas las pantallas que tengan menu
    // (la principal, la de game over, etc)
    public void PlayGame()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.resetStats();
            GameManager.instance.state = GameManager.CurrentState.PLAYING;
        }

        SceneManager.LoadScene("Scenes/mapas_definitivos/Map_01");
    }

     public void QuitGame()
    {
        Application.Quit();
    }
}
