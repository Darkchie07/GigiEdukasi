using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public static MusicControl instance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

// STOP MUSIC ON SCENE
// using UnityEngine.SceneManagement;

// public class StopMusic : MonoBehaviour
// {
//     void Update()
//     {
//        if(SceneManager.GetActiveScene().name == "Level 4")
//             {
//                 Music.instance.GetComponent<AudioSource>().Stop();
//             }
//     }
// }
