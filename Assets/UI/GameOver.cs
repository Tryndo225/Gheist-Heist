using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Script for game over overlay screen - UI
public class GameOver : MonoBehaviour
{
    [SerializeField] private TMP_Text timeSurvided;
    private SceneManagement sceneManager;

    public void Start()
    {
        // Locates SceneManager
        sceneManager = FindObjectOfType<SceneManagement>();
    }

    // Turns on game over overlay
    public void Setup(TimeSpan time)
    {
        gameObject.SetActive(true);
        timeSurvided.text = "Total Time: " + time.ToString("m\\:ss\\.fff");
        Time.timeScale = 0;
    }

    // Handles restart button 
    public void restart()
    {
        sceneManager.restart();
    }

    // Handles main menu button 
    public void toMainMenu()
    {
        sceneManager.goToMain();
    }
}
