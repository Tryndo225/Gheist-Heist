using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    [SerializeField] private AudioClip soundEffect;
    private SceneManagement sceneManager;

    private void Start()
    {
        sceneManager = FindObjectOfType<SceneManagement>();
    }

    public void Setup()
    {
        if (Time.timeScale != 0)
        {
            SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
            gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void resume()
    {
        SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void restart()
    {
        sceneManager.restart();
    }

    public void toMainMenu()
    {
        sceneManager.goToMain();
    }
}
