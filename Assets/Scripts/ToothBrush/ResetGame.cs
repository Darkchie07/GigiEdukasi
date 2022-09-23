using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public string _path;
    public void RestartGame()
    {
        SceneManager.LoadScene(_path);
    }

}
