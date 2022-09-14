using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject drag1, drag2, drag3, drag4, drag5, drag6, drag7, drag8, drop1, drop2, drop3, drop4, drop5, drop6, drop7, drop8;

    Vector2 drag1InitialPos, drag2InitialPos, drag3InitialPos, drag4InitialPos, drag5InitialPos, drag6InitialPos, drag7InitialPos, drag8InitialPos;

    void Start()
    {
        drag1InitialPos = drag1.transform.position;
        drag2InitialPos = drag2.transform.position;
        drag3InitialPos = drag3.transform.position;
        drag4InitialPos = drag4.transform.position;
        drag5InitialPos = drag5.transform.position;
        drag6InitialPos = drag6.transform.position;
        drag7InitialPos = drag7.transform.position;
        drag8InitialPos = drag8.transform.position;
    }

    public void Drag1()
    {
        drag1.transform.position = Input.mousePosition;
    }
    public void Drag2()
    {
        drag2.transform.position = Input.mousePosition;
    }
    public void Drag3()
    {
        drag3.transform.position = Input.mousePosition;
    }
    public void Drag4()
    {
        drag4.transform.position = Input.mousePosition;
    }
    public void Drag5()
    {
        drag5.transform.position = Input.mousePosition;
    }
    public void Drag6()
    {
        drag6.transform.position = Input.mousePosition;
    }
    public void Drag7()
    {
        drag7.transform.position = Input.mousePosition;
    }
    public void Drag8()
    {
        drag8.transform.position = Input.mousePosition;
    }

    public void Drop1()
    {
        float Distance = Vector3.Distance(drag1.transform.position, drop1.transform.position);
        if(Distance< 100)
        {
            drag1.transform.position = drop1.transform.position;
        }
        else
        {
            drag1.transform.position = drag1InitialPos;
        }
    }
    public void Drop2()
    {
        float Distance = Vector3.Distance(drag2.transform.position, drop2.transform.position);
        if (Distance < 100)
        {
            drag2.transform.position = drop2.transform.position;
        }
        else
        {
            drag2.transform.position = drag2InitialPos;
        }
    }
    public void Drop3()
    {
        float Distance = Vector3.Distance(drag3.transform.position, drop3.transform.position);
        if (Distance < 100)
        {
            drag3.transform.position = drop3.transform.position;
        }
        else
        {
            drag3.transform.position = drag3InitialPos;
        }
    }
    public void Drop4()
    {
        float Distance = Vector3.Distance(drag4.transform.position, drop4.transform.position);
        if (Distance < 100)
        {
            drag4.transform.position = drop4.transform.position;
        }
        else
        {
            drag4.transform.position = drag4InitialPos;
        }
    }
    public void Drop5()
    {
        float Distance = Vector3.Distance(drag5.transform.position, drop5.transform.position);
        if (Distance < 100)
        {
            drag5.transform.position = drop5.transform.position;
        }
        else
        {
            drag5.transform.position = drag5InitialPos;
        }
    }

    public void Drop6()
    {
        float Distance = Vector3.Distance(drag6.transform.position, drop6.transform.position);
        if (Distance < 100)
        {
            drag6.transform.position = drop6.transform.position;
        }
        else
        {
            drag6.transform.position = drag6InitialPos;
        }
    }

    public void Drop7()
    {
        float Distance = Vector3.Distance(drag7.transform.position, drop7.transform.position);
        if (Distance < 100)
        {
            drag7.transform.position = drop7.transform.position;
        }
        else
        {
            drag7.transform.position = drag7InitialPos;
        }
    }

    public void Drop8()
    {
        float Distance = Vector3.Distance(drag8.transform.position, drop8.transform.position);
        if (Distance < 100)
        {
            drag8.transform.position = drop8.transform.position;
        }
        else
        {
            drag8.transform.position = drag8InitialPos;
        }
    }
}
