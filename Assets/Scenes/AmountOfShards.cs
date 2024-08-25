using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmountOfShards : MonoBehaviour
{
    // Start is called before the first frame update - Sets amount of shards text
    void Start()
    {
        string myMap = this.gameObject.name;
        int amount = MemoryScript.memoryScriptInstance.collectedOnMap(myMap);
        GameObject myText = this.transform.Find("Text (TMP)").gameObject;
        myText.GetComponent<TMP_Text>().text = amount + "/4 ";
    }
}
