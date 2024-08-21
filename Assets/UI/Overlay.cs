using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Overlay : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    public void stringChange(string myString)
    {
        text.text = myString;
    }

    public void toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}