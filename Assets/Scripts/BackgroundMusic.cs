using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource Music { get; private set; }


    public static BackgroundMusic Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Music = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("Music", 1) == 1)
        {
            Music.Play();
        }
        else
        {
            Music.Stop();
        }
    }
}
