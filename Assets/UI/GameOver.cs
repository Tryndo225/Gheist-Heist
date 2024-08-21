using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TMP_Text timeSurvided;
    private SceneManagement sceneManager;

    public void Start()
    {
        sceneManager = FindObjectOfType<SceneManagement>();
    }
    public void Setup(TimeSpan time)
    {
        gameObject.SetActive(true);
        timeSurvided.text = "Total Time: " + time.ToString("m\\:ss\\.fff");
        Time.timeScale = 0;
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
