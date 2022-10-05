using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    static public int video;
    public void PindahScene(string _path)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_path);
    }

    public void SetVideo(int _num)
    {
        video = _num;
    }
}
