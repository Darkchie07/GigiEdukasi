using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class MusicDnD : MonoBehaviour
{
    public static MusicDnD instance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (UnitySceneManager.GetActiveScene().name == "Level 1")
        {
            Destroy(gameObject);
        }
    }
}



