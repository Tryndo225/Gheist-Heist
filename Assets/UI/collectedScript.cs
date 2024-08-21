using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class collectedScript : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject image;
    [SerializeField] private GameObject button;

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void win()
    {
        if (MemoryScript.memoryScriptInstance.howMuch()==12)
        {
            text.text = "You Win";
            Application.Quit();
        }
    }

    public void back()
    {
        SceneManager.LoadScene("Level Select");
    }
}
