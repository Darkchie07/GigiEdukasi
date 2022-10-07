using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio Instance;
    public AudioSource audioSource;


    public AudioClip clipHome;

    public AudioClip clipGameDragDrop;

    public AudioClip clipGameToothBrush;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
        PlayHomeBgm();
    }

    public void PlayMusic()
    {
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void PlayDragnDropBgm()
    {
        audioSource.clip = clipGameDragDrop;
        PlayMusic();
    }

    public void PlayToothBrushBgm()
    {
        audioSource.clip = clipGameToothBrush;
        PlayMusic();
    }

    public void PlayHomeBgm()
    {
        audioSource.clip = clipHome;
        PlayMusic();
    }
}
