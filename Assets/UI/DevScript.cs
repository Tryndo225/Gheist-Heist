using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class DevScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> inputs;
    [SerializeField] private List<GameObject> placeholders;

    [SerializeField] private List<GameObject> volumeInputs;
    [SerializeField] private List<GameObject> volumePlaceholders;



    // Start is called before the first frame update - Sets up placeholders with last values
    void Start()
    {
        foreach (GameObject item in placeholders)
        {
            string map = item.name.Split('-')[0];
            int amount = MemoryScript.memoryScriptInstance.collectedOnMap(map);
            item.GetComponent<TMP_Text>().text = amount.ToString();
        }

        for (int i = 0; i < volumePlaceholders.Count; i++)
        {
            float volume = SoundFXManager.soundFXManagerInstance.get()[i];
            volumePlaceholders[i].GetComponent<TMP_Text>().text = volume.ToString();
        }
    }

    // Kills the menu and sets the values
    public void quit()
    {
        for (int i = 0; i < inputs.Count; i++)
        {
            GameObject item = inputs[i];
            string map = item.name.Split('-')[0];

            float? amount = parser(item.GetComponent<TMP_InputField>().text);
            if (amount.HasValue)
            {
                MemoryScript.memoryScriptInstance.collectedOnMapSet(map, amount.Value);
            }
            else
            {
                Debug.Log("Keeping old value for " + map);
            }
        }

        List<float?> list = new List<float?>();
        for (int i = 0; i < volumeInputs.Count; i++)
        {
            float? volume = parser(volumeInputs[i].GetComponent<TMP_InputField>().text);
            list.Add(volume);
        }
        SoundFXManager.soundFXManagerInstance.set(list[0], list[1]);

        this.gameObject.SetActive(false);
    }

    // Parses string to float
    private float? parser(string text)
    {
        float num;
        if (float.TryParse(text, out num))
        {
            float.TryParse(text, out num);
            Debug.Log("Successful parse: " + text);
            return num;
        }

        else
        {
            Debug.Log("Couldn't parse - not valid input: " + text);
            return null;
        }
    }

    // Finds gameobject with same name in list
    private GameObject finder(string name, List<GameObject> list)
    {
        foreach(GameObject item in list)
        {
            if (item.name.Split('-')[0] == name)
            {
                return item;
            }
        }
        return null;
    }
}

