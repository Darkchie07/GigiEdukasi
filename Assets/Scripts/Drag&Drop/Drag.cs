using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private Vector3 _start;
    private Vector3 _posisi;
    private bool isBeingHeld = false;
    public bool isPlaced = false;

    private void Start()
    {
        _start = this.transform.position;
    }

    void Update()
    {
        if(isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }
    }

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pencet");
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        if (!isPlaced)
        {
            this.transform.position = _start;
        }
        else
        {
            this.transform.position = _posisi;
        }

            isBeingHeld = false;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Kotak"))
        {
            var antri = col.GetComponent<Drop>().antri;
            isPlaced = true;
            _posisi = col.transform.position;
            if (antri <= 2)
            {
                col.GetComponent<Drop>().antri += 1;
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Kotak"))
        {
            var antri = col.GetComponent<Drop>().antri;
            isPlaced = false;
            if (antri > 0)
            {
                col.GetComponent<Drop>().antri += 1;
            }
        }
    }
}
