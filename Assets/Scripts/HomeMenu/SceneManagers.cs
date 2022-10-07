using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagers : MonoBehaviour
{
    public Button[] listButtonMateri;

    private void Awake()
    {
        if (listButtonMateri == null)
            return;
        if (listButtonMateri.Length == 0)
            return;

        listButtonMateri[0].onClick.AddListener(() => ChangeScene(0));
        listButtonMateri[1].onClick.AddListener(() => ChangeScene(1));
        listButtonMateri[2].onClick.AddListener(() => ChangeScene(2));
        listButtonMateri[3].onClick.AddListener(() => ChangeScene(3));
    }

    void ChangeScene(int i)
    {
        Helper.videoMateriIndx = i;
        Helper.GoToVideoMateri();
    }

    public void PindahScene(string _path)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_path);
    }

    //public void SetVideo(int _num)
    //{
    //    Helper.videoMateriIndx = _num;
    //}
}
