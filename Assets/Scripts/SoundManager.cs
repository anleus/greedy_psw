using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip fruitEat;
    public AudioClip monkeyWalk;
    public AudioClip damage;
    public AudioClip explosion;


    public AudioSource[] audioSources;


    public void Awake()
    {
        MakeSingleton();
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioSource getAvailableAudioSource()
    {
        foreach (AudioSource asource in audioSources)
            if (!asource.isPlaying)
                return asource;

        return audioSources[0];
    }

    protected void MakeSingleton()
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
