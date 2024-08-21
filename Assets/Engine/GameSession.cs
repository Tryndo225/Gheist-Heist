using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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

    // Start is called before the first frame update
    void Start()
    {
        escapedScript = FindObjectOfType<LevelEscaped>();
        overlayUiScript = FindObjectOfType<Overlay>();
        pauseScript = FindObjectOfType<GamePause>();
        gameOverScript = FindObjectOfType<GameOver>();

        pauseScript.gameObject.SetActive(false);
        gameOverScript.gameObject.SetActive(false);
        escapedScript.gameObject.SetActive(false);

        timeAlive = TimeSpan.FromSeconds(0);
        alive = true;

        escaped = false;
        collectablesPicked = 0;
    }

    public void setDead(bool state = false)
    {
        alive = state;
    }

    public void setPickUp()
    {
        collectablesPicked++;
    }

    private void pause()
    {
        pauseScript.Setup();
    }
    private void gameOver()
    {
        overlayUiScript.toggle();
        alive = true;
        gameOverScript.Setup(timeAlive);
    }

    public void justEscaped()
    {
        Debug.Log("escaped");
        escaped = true;
        MemoryScript.memoryScriptInstance.progressSaved(SceneManager.GetActiveScene().name);
        overlayUiScript.toggle();
        escapedScript.Setup(timeAlive, collectablesPicked);

    }

    // Update is called once per frame
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
