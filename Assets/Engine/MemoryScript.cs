using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 
 * Script used to remember necessary gamedata between scenes
 * - Implemented using sigleton object
 * - 
*/
public class MemoryScript : MonoBehaviour
{
    public static MemoryScript memoryScriptInstance;

    // Main data dictionary
    private Dictionary<string, List<Vector2>> collectiblesCollected = new Dictionary<string, List<Vector2>>();

    // Number of collected shards
    private Dictionary<string, int> collectiblesAmount = new Dictionary<string, int>();

    // Remembers total time spend escaping
    private TimeSpan totalTimeRunning;

    // Remembers number of deaths
    private int deathCounter;

    // Remembers the state of glasses
    private bool equiped = false;

    // Remembers if story was alredy read
    private bool launchCheck = false;

    // Runs upon script initialization
    private void Awake()
    {
        // Ensures singleton properties
        if (memoryScriptInstance == null)
        {
            memoryScriptInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        // Creates list for each sector
        collectiblesCollected.Add("Sector A", new List<Vector2>());
        collectiblesCollected.Add("Sector B", new List<Vector2>());
        collectiblesCollected.Add("Sector C", new List<Vector2>());
        collectiblesCollected.Add("Sector D", new List<Vector2>());

        collectiblesAmount.Add("Sector A", 0);
        collectiblesAmount.Add("Sector B", 0);
        collectiblesAmount.Add("Sector C", 0);
        collectiblesAmount.Add("Sector D", 0);
    }

    // Temporary list to hold temporary data
    private List<Vector2> temporaryList = new List<Vector2>();

    // Remembers last scene script ran from
    private string lastScene;

    // Sets story to read
    public void launch()
    {
        launchCheck = true;
    }

    // Returns whether the story was dispalyed
    public bool launched()
    {
        return launchCheck;
    }

    // Adds another death to the tally
    public void addDeath()
    {
        deathCounter++;
    }

    // Returns the number of deaths 
    public int numberOfDeaths()
    {
        return deathCounter;
    }

    // Equips glasses
    public void justEquiped()
    {
        equiped = true;
    }

    // Returns the state of glasses
    public bool isEquiped()
    {
        return equiped;
    }    

    // Adds time to total time
    public void addTime(TimeSpan time)
    {
        totalTimeRunning += time;
    }

    // Returns total running time
    public TimeSpan tellTime()
    {
        return totalTimeRunning;
    }

    // Taggs colletible as collected 
    public void setCollected(Vector2 id)
    {
        temporaryList.Add(id);
    }

    // Informs other scrips of the amount of collected items
    public int howMuch()
    {
        int totalAmount = 0;
        foreach(int entry in collectiblesAmount.Values)
        {
            totalAmount += entry;
        }
        return totalAmount;
    }

    // Keeps the amount of collected shards on a map
    public int collectedOnMap(string map)
    {
        return collectiblesAmount[map];
    }

    // Sets the amount of collected collectables on a map - dev option
    public void collectedOnMapSet(string map, float number)
    {
        int amount = Mathf.RoundToInt(number);
        if (amount < 0)
        {
            amount = 0;
        }
        else if (amount > 4)
        {
            amount = 4;
        }
        collectiblesAmount[map] = amount;
    }

    // Checks for item in list
    public bool isInList(string map, Vector2 id)
    {
        return collectiblesCollected[map].Contains(id);
    }

    // Deletes temporary data on death
    public void progressLost()
    {
        temporaryList = new List<Vector2>();
    }

    // Saves progress (data) upon escaping level
    public void progressSaved(string map)
    {
        foreach (Vector2 id in temporaryList)
        {
            if (!isInList(map, id))
            { 
                collectiblesCollected[map].Add(id);
                if (collectiblesAmount[map] < 4)
                {
                    collectiblesAmount[map]++;
                }
            }
        }
        temporaryList = new List<Vector2>();
    }
    public void FixedUpdate()
    {
        if (lastScene != SceneManager.GetActiveScene().name)
        {
            lastScene = SceneManager.GetActiveScene().name;
        }
    }
}
