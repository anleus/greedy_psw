using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    // Start is called before the first frame update

    public int numOfEdibles = 15;


    void Start()
    {
        Invoke("spawnEdibles", 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnEdibles()
    {
        GameManager.instance.spawnEdibles(numOfEdibles);
    }
}
