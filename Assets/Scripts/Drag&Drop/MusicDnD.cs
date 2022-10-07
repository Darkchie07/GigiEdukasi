using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class MusicDnD : MonoBehaviour
{
    private void Awake()
    {
        Audio.Instance.PlayDragnDropBgm();
    }
}



