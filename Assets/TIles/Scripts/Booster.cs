using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script handling the booster block behavior
public class Booster : MonoBehaviour
{
    // Variables for setting booster strenght
    [SerializeField] private float boostStrenghtHorizontal;
    [SerializeField] private float boostStrenghtVertical;

    // Player reference
    [SerializeField] private Rigidbody2D playerBody;

    // Audio clip file
    [SerializeField] private AudioClip soundEffect;

    // Animator purposes
    private int time;

    // Runns when establishing collision with the player speeding the player up by a factor 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<Animator>().SetBool("Used", true);
            time = 1;
            playerBody.velocity = new Vector2(playerBody.velocity.x * boostStrenghtHorizontal,  playerBody.velocity.y * boostStrenghtVertical);
            SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
        }
    }

    // For animator purposes
    private void Update()
    {
        if (time < 2 && time != 0)
        {
            time++;
        }

        else if (time >= 2)
        {
            time = 0;
            this.gameObject.GetComponent<Animator>().SetBool("Used", false);
        }
    }
}
