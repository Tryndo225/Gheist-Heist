using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorDButtonScript : MonoBehaviour
{
    // Start is called before the first frame update - Turns doors of if glasses not equiped
    void Start()
    {
        if (!MemoryScript.memoryScriptInstance.isEquiped())
        {
            this.gameObject.SetActive(false);
        }
    }
}
