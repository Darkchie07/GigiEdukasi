using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    public ParticleSystem bubble;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bacteri")
        {
            CreateBubble();
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Bacteri")
        {
            StopBubble();      
        }
    }

    void CreateBubble()
    {
        bubble.Play();
    }

    void StopBubble()
    {
        bubble.Stop();
    }
}
