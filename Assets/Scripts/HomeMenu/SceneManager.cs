using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void PindahScene(string _path)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_path);
    }
}
