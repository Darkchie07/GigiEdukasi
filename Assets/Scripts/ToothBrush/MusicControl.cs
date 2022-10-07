using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;


public class MusicControl : MonoBehaviour
{
    private void Awake()
    {
        Audio.Instance.PlayToothBrushBgm();
    }
}