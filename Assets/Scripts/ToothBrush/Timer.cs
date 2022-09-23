using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Image timerBar;
    float timeLeft;
    public float maxTime = 10f;
    public GameObject timesUp;
    public GameObject success;
    public GameObject resetButton;
    public GameObject sikat;

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
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
            countDown.text = timeLeft.ToString("0");
            
            if(GameObject.FindGameObjectsWithTag("Bacteri").Length <= 0)            
            {
                Time.timeScale = 0;
                success.SetActive(true);
            }
        
        }
        else
        {
            sikat.GetComponent<Cleaner>().enabled = false;

            if(GameObject.FindGameObjectsWithTag("Bacteri").Length <= 0)            
            {
                success.SetActive(true);
            }
            else
            {
                resetButton.SetActive(true);
                timesUp.SetActive(true);
            }
        }
    }
}
