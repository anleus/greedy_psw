using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RankingGUI : MonoBehaviour
{
    public TextMeshProUGUI r1;
    public TextMeshProUGUI r2;
    public TextMeshProUGUI r3;
    // Start is called before the first frame update
    void Start()
    {
        r1 = transform.Find("R1").GetComponent<TextMeshProUGUI>();
        r2 = transform.Find("R2").GetComponent<TextMeshProUGUI>();
        r3 = transform.Find("R3").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerStatsData[] ranking = GameManager.instance.playerRanking;

        if (ranking[0].calories > 0)
            r1.text = "#1 (" + ranking[0].time.ToString("yyyy-MM-dd HH:mm:ss") + ") : " + ranking[0].calories + " cal.";
        else
            r1.text = "";

        if (ranking[1].calories > 0)
            r2.text = "#2 (" + ranking[1].time.ToString("yyyy-MM-dd HH:mm:ss") + ") : " + ranking[1].calories + " cal.";
        else
            r2.text = "";

        if (ranking[2].calories > 0)
            r3.text = "#3 (" + ranking[2].time.ToString("yyyy-MM-dd HH:mm:ss") + ") : " + ranking[2].calories + " cal.";
        else
            r3.text = "";
    }
}
