using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Script for Overlay timer
public class Overlay : MonoBehaviour
{
    // Variable to locate text field
    [SerializeField] private TMP_Text text;

    // Changes textbox content
    public void stringChange(string myString)
    {
        text.text = myString;
    }

    // Turns on gameObject
    public void toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}