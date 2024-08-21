using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelEscaped : MonoBehaviour
{
    [SerializeField] private TMP_Text timeSurvided;
    [SerializeField] private TMP_Text pointsCollected;

    private SceneManagement sceneManager;

    public void Start()
    {
        sceneManager = FindObjectOfType<SceneManagement>();
    }
    public void Setup(TimeSpan time, int points)
    {
        Debug.Log("on the screen");
        this.gameObject.SetActive(true);
        timeSurvided.text = "Total Time: " + time.ToString("m\\:ss\\.fff");
        pointsCollected.text = "Total Collected: " + points;
        Time.timeScale = 0;
    }
    public void toLevelSelect()
    {
        sceneManager.goToLevelSelelect();
    }

    public void toMainMenu()
    {
        sceneManager.goToMain();
    }


}
