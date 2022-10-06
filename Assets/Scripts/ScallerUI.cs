using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScallerUI : MonoBehaviour
{
    public float normalScale;
    public float smallScale1;
    public float smallScale2;
    private void Awake()
    {
        float _ratio = Screen.height / Screen.width;

        if (_ratio > 0.5f && _ratio <= 0.6f)
            transform.localScale = Vector2.one * smallScale1;
        else if (_ratio >= 0.6f)
            transform.localScale = Vector2.one * smallScale2;
        else
            transform.localScale = Vector2.one * normalScale;

    }
}
