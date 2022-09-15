using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textElement;
    public void salah()
    {
        textElement.text = "SALAH";
    }
    public void benar()
    {
        textElement.text = "BENAR";
    }
}
