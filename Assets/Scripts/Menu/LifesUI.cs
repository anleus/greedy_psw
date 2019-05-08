using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifesUI : MonoBehaviour
{
    private List<Image> lifes;
    public GameObject vidaImage;
    // Start is called before the first frame update
    void Start()
    {
        lifes = new List<Image>();

        for (int i = 0; i < PlayerStats.MaxLifes; i++)
        {
            GameObject life = Instantiate(vidaImage, new Vector3(-150 + i * 45, 0, 0), Quaternion.identity);
            life.transform.SetParent(gameObject.transform, false);
            //life.transform.localScale = new Vector3(0.1f, 0.1f, 1);
            
            lifes.Add(life.GetComponent<Image>());
        }
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < lifes.Count; i++)
        {
            if (GameManager.instance.playerStats.lifes > i)
                lifes[i].color = new Color(256f, 256f, 256f);
            else
                lifes[i].color = new Color(30, 30, 30);
        }
    }
}
