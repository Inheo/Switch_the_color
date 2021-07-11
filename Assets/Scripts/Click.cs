using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    private AudioSource click;


    public static Click Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        click = GetComponent<AudioSource>();   
    }

    public void Play()
    {
        if(PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            click.Play();
        }
    }
}
