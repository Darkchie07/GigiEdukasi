using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    private Vector3 _kotak;
    public int antri = 0;

    private void Start()
    {
        _kotak = this.transform.position;
    }

    private void Update()
    {
        if (antri == 2)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            // antri -= 1;
        }else if(antri == 0)
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
        Debug.Log(antri);
    }
}
