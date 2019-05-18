using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointLogic : MonoBehaviour
{
    public bool isBeingUsed = false;
    public GameObject currentObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool UseSpawnPoint(GameObject newGameobject)
    {
        if (isBeingUsed) return false;

        isBeingUsed = true;
        currentObject = newGameobject;

        return true;
    }

    public void FreeSpawnPoint()
    {
        isBeingUsed = false;
    }
}
