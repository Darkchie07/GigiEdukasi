using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Image timerBar;
    public float maxTime = 10f;
    float timeLeft;
    public GameObject timesUp;
    public GameObject success;

    [SerializeField] Text countDown;

    void Start()
    {
        timesUp.SetActive(false);
        success.SetActive(false);
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    void Update()
    {
        if(timeLeft > 0) 
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
            countDown.text = timeLeft.ToString("0");
        }
        else
        {
            Time.timeScale = 0;

            if(GameObject.FindGameObjectsWithTag("Bacteri").Length <= 0)            
            {
                success.SetActive(true);
            }
            else
            {
                timesUp.SetActive(true);
            }
        }
    }

}
