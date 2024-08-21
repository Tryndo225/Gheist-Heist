using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    [SerializeField] private AudioClip soundEffect;

    private void Start()
    {
        if (MemoryScript.memoryScriptInstance.isInList(SceneManager.GetActiveScene().name, this.transform.position))
        {
            this.gameObject.SetActive(false);
        }
    }

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