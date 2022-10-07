using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer _video;
    public VideoClip[] listVideo;

    void Start()
    {
        _video.clip = listVideo[Helper.videoMateriIndx];
        _video.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ClickBackToMateri();
    }

    public void ClickBackToMateri() => Helper.GoToMateri();
}
