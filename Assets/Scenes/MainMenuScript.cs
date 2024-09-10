using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class MainMenuScript : MonoBehaviour
{
    // Reference to story
    [SerializeField] private GameObject story;

    private GameObject devSettings;

    private void Awake()
    {
        devSettings = FindObjectOfType<DevScript>().gameObject;
        devSettings.SetActive(false);
    }

    // Handless the dual functionality of the play button
    public void playButton()
    {
        if (MemoryScript.memoryScriptInstance.launched())
        {
            FindObjectOfType<SceneManagement>().goToLevelSelelect();
        }

        else
        {
            story.SetActive(true);
            MemoryScript.memoryScriptInstance.launch();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !devSettings.activeSelf) 
        {
            devSettings.SetActive(true);
        }
    }

}