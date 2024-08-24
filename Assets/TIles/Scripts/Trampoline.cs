using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    // Variebles to select the angle of the trampoline
    [SerializeField] private bool up;
    [SerializeField] private bool down;
    [SerializeField] private bool left;
    [SerializeField] private bool right;


    // Variable for player reference
    [SerializeField] private Rigidbody2D playerBody;

    // Variable for sound effect
    [SerializeField] private AudioClip soundEffect;


    // Main part of the script it is excecuted when player enters collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Variable to check whether sound should play
            bool action = true;

            // All options in angle increments of 45°
            if ((up ^ down) && (!left && !right))
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x, playerBody.velocity.y * -1);
            }

            else if ((left ^ right) && (!up && !down))
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x * -1, playerBody.velocity.y);
            }

            else if ((up && left && !down && !right) || (!up && !left && down && right))
            {
                playerBody.velocity = new Vector2(playerBody.velocity.y, playerBody.velocity.x);
            }

            else if ((down && left && !up && !right) || (!down && !left && up && right))
            {
                playerBody.velocity = new Vector2(playerBody.velocity.y * -1, playerBody.velocity.x * -1);
            }

            else
            {
                action = false;
            }

            // Sound check
            if (action)
            {
                SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
            }
        }
    }
}

