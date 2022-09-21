using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    private Vector3 _kotak;
    [SerializeField]private Collider2D _jawaban;

    private void Start()
    {
        _kotak = this.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Benar"))
        {
            if (_jawaban == null)
            {
                _jawaban = col;
                col.GetComponent<Drag>().isPlaced = true;
                col.GetComponent<Drag>()._posisi = this.transform.position;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (_jawaban != col)
        {
            return;
        }
        Debug.Log(_jawaban);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col == _jawaban)
        {
            if (col.gameObject.CompareTag("Benar"))
            {
                if(_jawaban != null){
                    _jawaban = null;
                }
                col.GetComponent<Drag>().isPlaced = false;
            }
        }
        
    }
}
