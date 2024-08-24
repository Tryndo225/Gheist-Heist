using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryCollectableScript : MonoBehaviour
{
    // Collection sound clue file
    [SerializeField] private AudioClip soundEffect;

    // Runs when collected
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
            FindObjectOfType<GameSession>().winCollected();
            this.gameObject.SetActive(false);
            SceneManager.LoadScene("Victory Screen");
        }
    }
}
