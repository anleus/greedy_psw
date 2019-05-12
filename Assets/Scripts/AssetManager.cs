using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : MonoBehaviour
{
    public static AssetManager instance;

    public GameObject BrokenHeartEffect;
    public GameObject HeartPickupEffect;
    public GameObject PurpleDeathExplosionEffect;
    public GameObject PoofEffect;
    public GameObject StarEffect;
    public GameObject ResurrectionLightEffect;
    public GameObject StarHitEffect;



    public GameObject LifeEntityPrefab;

    public GameObject[] fruitsPrefabs;
    public GameObject[] badEntitiesPrefabs;

    

    void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
