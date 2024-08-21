using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for overlay pause screen - UI
public class GamePause : MonoBehaviour
{
    // Click sound
    [SerializeField] private AudioClip soundEffect;

    // SceneManager reference
    private SceneManagement sceneManager;

    private void Start()
    {
        // Locates SceneManager
        sceneManager = FindObjectOfType<SceneManagement>();
    }

    // Turns on the pause menu
    public void Setup()
    {
        if (Time.timeScale != 0)
        {
            SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
            gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    // Handles resume button
    public void resume()
    {
        SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
        gameObject.SetActive(false);
        Time.timeScale = 1;
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
