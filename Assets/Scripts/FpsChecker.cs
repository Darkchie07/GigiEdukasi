using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class FpsChecker : MonoBehaviour
{
    private int lastFromIndex;
    private float[] frameDeltaTimeArray;
    public TextMeshProUGUI txtFps;

    public bool needToShow;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        frameDeltaTimeArray = new float[50];
    }

    private void Update()
    {
        if (!needToShow)
        {
            txtFps.gameObject.SetActive(false);
        }
        else
        {
            txtFps.gameObject.SetActive(true);
        }

        frameDeltaTimeArray[lastFromIndex] = Time.deltaTime;
        lastFromIndex = (lastFromIndex + 1) % frameDeltaTimeArray.Length;

        txtFps.text = $"Current Fps : {Mathf.RoundToInt(CalculateFps()).ToString()}";
    }

    float CalculateFps()
    {
        float total = 0f;
        foreach (var deltaTime in frameDeltaTimeArray)
        {
            total += deltaTime;
        }

        return frameDeltaTimeArray.Length / total;
    }
}
