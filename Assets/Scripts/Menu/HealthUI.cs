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

    
    public TextMeshProUGUI damageText;
    public float DamageFillSpeedPerSecond = 80f;

    private GameObject damageBar;
    private Image damageBarImage;

    private float objectiveFillAmount = 0f;
    void Start()
    {
        damageBar = transform.Find("DamageBar").gameObject;

        damageBarImage = damageBar.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        objectiveFillAmount = GameManager.instance.damageReceived / 100f;
        float maxDelta = DamageFillSpeedPerSecond / 100 * Time.deltaTime;

        float delta = objectiveFillAmount - damageBarImage.fillAmount;
        if (delta > 0)
            delta = Mathf.Min(maxDelta, delta);
        else if (delta < 0)
            delta = Mathf.Max(-maxDelta, delta);

        damageBarImage.fillAmount += delta;
        damageText.text = "DAÑO: " + Mathf.Round(damageBarImage.fillAmount*100) + " %";
        //Debug.Log("fillAmount");
        //Debug.Log(damageText);
        
    }

}
