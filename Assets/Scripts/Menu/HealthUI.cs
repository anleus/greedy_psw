using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthUI : MonoBehaviour
{
    //Text healthText;
    // Start is called before the first frame update

    private GameObject damageBar;
    private Image damageBarImage;
    public TextMeshProUGUI damageText;

    void Start()
    {
        damageBar = transform.Find("DamageBar").gameObject;

        damageBarImage = damageBar.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        damageBarImage.fillAmount = GameManager.instance.damageReceived / 100f;
        damageText.text = "DAÑO: " + GameManager.instance.damageReceived + " %";
        //Debug.Log("fillAmount");
        //Debug.Log(damageText);
        
    }

}
