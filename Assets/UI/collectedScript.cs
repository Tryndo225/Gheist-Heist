using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// Sript for table room
public class collectedScript : MonoBehaviour
{
    // Self-reference variables
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject image;
    [SerializeField] private GameObject button;

    // Start is called before the first frame update - Displays the amound of collected shards
    void Start()
    {
        text.text = ("Collected: " + MemoryScript.memoryScriptInstance.howMuch() + "/12");
        if (MemoryScript.memoryScriptInstance.howMuch() == 12)
        {
            image.SetActive(true);
            button.SetActive(true);
        }
        else
        {
            image.SetActive(false);
            button.SetActive(false);
        }
    }

    // Handles win button - temporary
    public void win()
    {
        if (MemoryScript.memoryScriptInstance.howMuch() == 12)
        {
            text.text = "You Win";
            Application.Quit();
        }
    }

    // Handles go back button
    public void back()
    {
        SceneManager.LoadScene("Level Select");
    }
}
