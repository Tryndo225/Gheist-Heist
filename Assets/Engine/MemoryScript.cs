using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MemoryScript : MonoBehaviour
{
    public static MemoryScript memoryScriptInstance;

    private Dictionary<string, List<Vector2>> collectiblesCollected = new Dictionary<string, List<Vector2>>();

    private int allShards = 0;

    private void Awake()
    {
        if (memoryScriptInstance == null)
        {
            memoryScriptInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        collectiblesCollected.Add("Sector A", new List<Vector2>());
        collectiblesCollected.Add("Sector B", new List<Vector2>());
        collectiblesCollected.Add("Sector C", new List<Vector2>());
        collectiblesCollected.Add("Sector D", new List<Vector2>());
    }

    private List<Vector2> temporaryList = new List<Vector2>();

    private string lastScene;

    public void setCollected(Vector2 id)
    {
        temporaryList.Add(id);
    }

    public int howMuch()
    {
        return allShards;
    }

    public bool isInList(string map, Vector2 id)
    {
        return collectiblesCollected[map].Contains(id);
    }

    public void progressLost()
    {
        temporaryList = new List<Vector2>();
    }

    public void progressSaved(string map)
    {
        foreach (Vector2 id in temporaryList)
        {
            if (!collectiblesCollected[map].Contains(id))
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
