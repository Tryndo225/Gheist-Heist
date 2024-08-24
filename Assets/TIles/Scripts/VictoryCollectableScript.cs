using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryCollectableScript : MonoBehaviour
{
    // Collection sound clue file
    [SerializeField] private AudioClip soundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
            this.gameObject.SetActive(false);
            SceneManager.LoadScene("Victory Screen");
        }
    }
}
