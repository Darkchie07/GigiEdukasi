using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    Image timerBar;
    float timeLeft;
    public float maxTime = 20f;
    public GameObject timesUp;
    public GameObject success;
    public GameObject resetButton;
    public GameObject brushTooth;

    [SerializeField] Text countDown;

    void Start()
    {
        timesUp.SetActive(false);
        success.SetActive(false);
        resetButton.SetActive(false);

        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    void Update()
    {
        if(timeLeft > 0) 
        {            
            if(GameObject.FindGameObjectsWithTag("Bacteri").Length > 0)            
            {
                timeLeft -= Time.deltaTime;
                timerBar.fillAmount = timeLeft / maxTime;
                countDown.text = timeLeft.ToString("0");
            }
            else
            {
                brushTooth.GetComponent<Cleaner>().enabled = false;
                success.SetActive(true);

                StartCoroutine(ChangeAfter3SecondsCoroutine());
            }
        }
        else
        {
            brushTooth.GetComponent<Cleaner>().enabled = false;
            resetButton.SetActive(true);
            timesUp.SetActive(true);
        }
    }

    IEnumerator ChangeAfter3SecondsCoroutine()
    {
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}
