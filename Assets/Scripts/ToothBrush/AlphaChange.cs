using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaChange : MonoBehaviour
{
    SpriteRenderer Sprite;
    Color currCol;

    private void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "brush")
        {
            currCol = Sprite.color;

            if (currCol.a > 0)
            {
                Color newCol = new Color(currCol.r, currCol.g, currCol.b, currCol.a - 0.1f);
                Sprite.color = newCol;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
