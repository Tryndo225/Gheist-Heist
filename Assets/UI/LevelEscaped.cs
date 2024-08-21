using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Escape Doors Script - Handles escaping the level
public class LevelEscaped : MonoBehaviour
{
    // Variable for escape sceen info
    [SerializeField] private TMP_Text timeSurvided;
    [SerializeField] private TMP_Text pointsCollected;

    private SceneManagement sceneManager;

    //Start is called before the first frame update - Finds SceneManager object for further interations
    public void Start()
    {
        sceneManager = FindObjectOfType<SceneManagement>();
    }

    // Handles showing the escape screen
    public void Setup(TimeSpan time, int points)
    {
        Debug.Log("on the screen");
        this.gameObject.SetActive(true);
        timeSurvided.text = "Total Time: " + time.ToString("m\\:ss\\.fff");
        pointsCollected.text = "Total Collected: " + points;
        Time.timeScale = 0;
    }

    // LevelSelection button function
    public void toLevelSelect()
    {
        sceneManager.goToLevelSelelect();
    }

    // MainMenu button function
    public void toMainMenu()
    {
        sceneManager.goToMain();
    }


}
