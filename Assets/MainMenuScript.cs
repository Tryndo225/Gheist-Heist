using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    // Reference to story
    [SerializeField] private GameObject story;

    // Handless the dual functionality of the play button
    public void playButton()
    {
        if (MemoryScript.memoryScriptInstance.launched())
        {
            FindObjectOfType<SceneManagement>().goToLevelSelelect();
            MemoryScript.memoryScriptInstance.launch();
        }

        else
        {
            story.SetActive(true);
        }
    }
}