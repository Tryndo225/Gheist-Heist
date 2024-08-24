using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Game engine script handles UI 
public class GameSession : MonoBehaviour
{
    private bool alive;
    private TimeSpan timeAlive;

    private bool escaped;
    private int collectablesPicked;

    private Overlay overlayUiScript;
    private GameOver gameOverScript;
    private GamePause pauseScript;
    private LevelEscaped escapedScript;

    // Start is called before the first frame update - Locates necessary game objects
    void Start()
    {
        escapedScript = FindObjectOfType<LevelEscaped>();
        overlayUiScript = FindObjectOfType<Overlay>();
        pauseScript = FindObjectOfType<GamePause>();
        gameOverScript = FindObjectOfType<GameOver>();

        // Disables game objects after finding them
        pauseScript.gameObject.SetActive(false);
        gameOverScript.gameObject.SetActive(false);
        escapedScript.gameObject.SetActive(false);

        // Sets starting variables to default
        timeAlive = TimeSpan.FromSeconds(0);
        alive = true;
        escaped = false;
        collectablesPicked = 0;
    }

    // Tags player as dead
    public void setDead(bool state = false)
    {
        alive = state;
    }

    // Counts collected item for UI purposes
    public void setPickUp()
    {
        collectablesPicked++;
    }

    // Calls pause script to open pause menu
    private void pause()
    {
        pauseScript.Setup();
    }

    // Calls game over script to oper game over menu
    private void gameOver()
    {
        overlayUiScript.toggle();
        alive = true;
        MemoryScript.memoryScriptInstance.addTime(timeAlive);
        MemoryScript.memoryScriptInstance.addDeath();
        gameOverScript.Setup(timeAlive);
    }

    // Hadles player escaping sector
    public void justEscaped()
    {
        Debug.Log("escaped");
        escaped = true;
        MemoryScript.memoryScriptInstance.progressSaved(SceneManager.GetActiveScene().name);
        overlayUiScript.toggle();
        MemoryScript.memoryScriptInstance.addTime(timeAlive);
        escapedScript.Setup(timeAlive, collectablesPicked);

    }

    // Update is called once per frame - Sets alive time and checks if player died
    void Update()
    {

        if (!escaped)
        {
            if (alive)
            {
                timeAlive += TimeSpan.FromSeconds(Time.deltaTime);
                overlayUiScript.stringChange("Time Survived : " + timeAlive.ToString("m\\:ss\\.fff"));
            }

            else
            {
                gameOver();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pause();
            }
        }
    }
}
