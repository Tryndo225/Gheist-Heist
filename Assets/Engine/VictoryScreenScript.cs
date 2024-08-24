using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Script to enable changing pages on victory screen
public class VictoryScreenScript : MonoBehaviour
{
    // Next and previous canvas references
    [SerializeField] private GameObject nextScreen;
    [SerializeField] private GameObject prevScreen;

    // Audio effect file
    [SerializeField] private AudioClip soundEffect;

    // Turns on next canvas and disabless current one
    public void turnNext()
    {
        nextScreen.SetActive(true);
        SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
        this.gameObject.SetActive(false);
    }

    // Turns on previous canvas and disables current one
    public void turnPrev()
    {
        prevScreen.SetActive(true);
        SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
        this.gameObject.SetActive(false);
    }

}
