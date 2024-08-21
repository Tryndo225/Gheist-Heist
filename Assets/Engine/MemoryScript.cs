using System.Collections;
using System.Collections.Generic;
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

    private int allShards = 0;

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
    }

    // Temporary list to hold temporary data
    private List<Vector2> temporaryList = new List<Vector2>();

    private string lastScene;

    // Taggs colletible as collected 
    public void setCollected(Vector2 id)
    {
        temporaryList.Add(id);
    }

    // Informs other scrips of the amount of collected items
    public int howMuch()
    {
        return allShards;
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
                allShards++;
                collectiblesCollected[map].Add(id);
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
