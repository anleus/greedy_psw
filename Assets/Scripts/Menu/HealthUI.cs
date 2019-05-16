using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthUI : MonoBehaviour
{
    //Text healthText;
    // Start is called before the first frame update

    public Image damage;

    void Start()
    {
        //healthText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //healthText.text = "Salud: " + GameManager.instance.health + "%";

        damage.fillAmount = GameManager.instance.health / 100f;
    }

}
