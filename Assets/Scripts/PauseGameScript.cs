using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class PauseGameScript : MonoBehaviour
{
    public bool pause = false;
    public static PauseGameScript Instance;
    public GameObject panelPause;
    private List<VideoPlayer> video;
    private void Awake()
    {
        Instance = this;
        pause = false;
        panelPause.SetActive(false);
        video = FindObjectsOfType<VideoPlayer>().ToList();
    }

    private void Update()
    {
        if (pause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClosePause();
        }
    }

    public void ClosePause()
    {
        pause = !pause;

        panelPause.SetActive((pause) ? true : false);

        if (video == null)
            return;
        if (pause)
            foreach (var a in video)
            {
                if (a.gameObject.activeSelf)
                {
                    a.playbackSpeed = 0;
                }
            }
        else
            foreach (var a in video)
            {
                if (a.gameObject.activeSelf)
                {
                    a.playbackSpeed = 1;
                }
            }
    }

    public void BackToHome()
    {
        Helper.GoToHomeMenu();
    }
}
