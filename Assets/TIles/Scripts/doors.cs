using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the escape doors
public class doors : MonoBehaviour
{
    // Check for player collision and triggers escape screen
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Leaving");
            FindObjectOfType<GameSession>().justEscaped();
        }
    }
}
