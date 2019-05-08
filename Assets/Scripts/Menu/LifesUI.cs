using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifesUI : MonoBehaviour
{
    Text lifesText;
    // Start is called before the first frame update
    void Start()
    {
        lifesText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lifesText.text = "Vidas: " + GameManager.instance.playerStats.lifes;
    }
}
