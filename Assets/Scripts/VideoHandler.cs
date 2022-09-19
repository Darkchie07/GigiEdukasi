using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoHandler : MonoBehaviour
{
    public VideoPlayer _Video;

    public CanvasScaler _Canvas;
    public Image rotateP;
    public Image rotateL;

    public void btn_sentuh(int id)
    {
        if (id == 0)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            rotateP.gameObject.SetActive(true);
            rotateL.gameObject.SetActive(false);
        }
        else if (id == 1)
        {
            Screen.orientation = ScreenOrientation.Portrait;
            rotateL.gameObject.SetActive(true);
            rotateP.gameObject.SetActive(false);
        }
        else if (id == 2)
        {
            _Video.Play();
        }
        else if (id == 3)
        {
            _Video.Pause();
        }
        else if (id == 4)
        {
            _Video.frame = 0;
            _Video.Play();
        }
        else if (id == 5)
        {
            _Video.frame = _Video.frame + 300;
            _Video.Play();
        }
        else if (id == 6)
        {
            _Video.frame = _Video.frame - 300;
            _Video.Play();
        }
    }
}
