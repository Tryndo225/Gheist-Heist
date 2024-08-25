using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class StatPageScript : MonoBehaviour
{
    private TMP_Text time;
    private TMP_Text deaths;

    private bool runCheck = false;

    //Sets up time survived and no. deaths texts
    void setup()
    {
        // Gets references
        deaths = this.transform.Find("Deaths").GetComponent <TMP_Text>();
        time = this.transform.Find("Time Survived").GetComponent <TMP_Text>();

        // Changes text
        deaths.text = "Number of Deaths: " + MemoryScript.memoryScriptInstance.numberOfDeaths().ToString();
        time.text = "Time Alive: " + MemoryScript.memoryScriptInstance.tellTime().ToString("m\\:ss\\.fff");
    }

    // Checks for turnging on of game object
    void FixedUpdate()
    {
        if (this.gameObject.activeSelf && !runCheck)
        {
            setup();
        }
    }
}
