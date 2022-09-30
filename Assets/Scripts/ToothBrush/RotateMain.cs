using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMain : MonoBehaviour
{
    SpriteRenderer Sprite;

    private void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Vector3 brushScale = transform.localScale;
        if (collider.tag == "LeftFlip")
        {
            brushScale.x = -0.5f;
        }
        else if (collider.tag == "RightFlip")
        {
            brushScale.x = 0.5f;
        }
        transform.localScale = brushScale;
    }
}
