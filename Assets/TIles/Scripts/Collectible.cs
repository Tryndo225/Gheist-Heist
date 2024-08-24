using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script resposible for handling the collectible spawing and collection (Needs MemoryManager to operate)
public class Collectible : MonoBehaviour
{
    // Audio file variable (Sound clue when picked up clip)
    [SerializeField] private AudioClip soundEffect;

    // Called before first Update - Handles the dissabling of already collected collectables
    private void Start()
    {
        if (MemoryScript.memoryScriptInstance.isInList(SceneManager.GetActiveScene().name, this.transform.position))
        {
            this.gameObject.SetActive(false);
        }
    }

    // Runs when entering collision with player model - disables current collables and marks it as collected
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<GameSession>().setPickUp();
            MemoryScript.memoryScriptInstance.setCollected(this.transform.position);
            SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
            this.gameObject.SetActive(false);
        }
    }
}