using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer _video;
    void Start()
    {
        if (SceneManagers.video == 1)
        {
            _video.url = "Assets/Video/Video 6.mp4";
        }else if (SceneManagers.video == 2)
        {
            _video.url = "Assets/Video/Video 7.mp4";
        }else if (SceneManagers.video == 3)
        {
            _video.url = "Assets/Video/Video 8.mp4";
        }else if (SceneManagers.video == 4)
        {
            _video.url = "Assets/Video/Video 9.mp4";
        }
    }
}
