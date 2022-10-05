using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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

    void Update()
    {
       if(SceneManager.GetActiveScene().name == "Done")
            {
                instance.GetComponent<AudioSource>().Pause();
            }
    }

}