using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.SearchService;
using UnityEngine;

public class VictoryCollectableScript : MonoBehaviour
{
    // Collection sound clue file
    [SerializeField] private AudioClip soundEffect;

    // Pointer prefab reference
    [SerializeField] private GameObject pointerPrefab;

    // Runs before first update - generates pointer
    private void Start()
    {
        GameObject pointer = Instantiate(pointerPrefab);
        pointer.GetComponent<PointerScript>().setup(this.gameObject);
    }



    // Runs when collected
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
            FindObjectOfType<GameSession>().winCollected();
            this.gameObject.SetActive(false);
            FindAnyObjectByType<SceneManagement>().goToVictoryScreen();
        }
    }
}
