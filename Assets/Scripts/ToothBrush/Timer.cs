using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;
using UnityEngine.Video;

public class Timer : MonoBehaviour
{
    Image timerBar;
    float timeLeft;
    public float maxTime = 20f;
    public GameObject timesUp;
    public GameObject successVideo;
    public GameObject videoOutput;
    public GameObject resetButton;
    public GameObject brushTooth;
    public GameObject video;

    [SerializeField] Text countDown;

    void Start()
    {
        videoOutput.GetComponent<RawImage>().enabled = false;
        timesUp.SetActive(false);
        resetButton.SetActive(false);
        if (successVideo != null)
            successVideo.SetActive(false);

        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            if (GameObject.FindGameObjectsWithTag("Bacteri").Length > 0)
            {
                timeLeft -= Time.deltaTime;
                timerBar.fillAmount = timeLeft / maxTime;
                countDown.text = timeLeft.ToString("0");
            }
            else
            {
                videoOutput.GetComponent<RawImage>().enabled = true;
                successVideo.SetActive(true);
                brushTooth.GetComponent<Drag>().enabled = false;
                successVideo.GetComponent<VideoPlayer>().Play();
                video.GetComponent<VideoPlayer>().Pause();

                if (UnitySceneManager.GetActiveScene().name == "Level 4")
                {
                    StartCoroutine(ChangeAfter5SecondsCoroutine());
                }
                else
                {
                    StartCoroutine(ChangeAfter4SecondsCoroutine());
                }
            }
        }
        else
        {
            brushTooth.GetComponent<Drag>().enabled = false;
            resetButton.SetActive(true);
            timesUp.SetActive(true);
            video.GetComponent<VideoPlayer>().Pause();
        }
    }

    IEnumerator ChangeAfter4SecondsCoroutine()
    {
        yield return new WaitForSeconds(4);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator ChangeAfter5SecondsCoroutine()
    {
        yield return new WaitForSeconds(5);
        UnityEngine.SceneManagement.SceneManager.LoadScene("HomeMenu");
    }
}
