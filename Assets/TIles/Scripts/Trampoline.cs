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

    private int time;

    // Variable for player reference
    [SerializeField] private Rigidbody2D playerBody;

    // Variable for sound effect
    [SerializeField] private AudioClip soundEffect;


    // Main part of the script it is excecuted when player enters collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Variable to check whether sound adn animation should play
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

            // Sound and animation check
            if (action)
            {
                SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
                time = 1;
                this.gameObject.GetComponent<Animator>().SetBool("Used", true);
            }
        }
    }

    // Animator puposes
    private void Update()
    {
        if (time != 0 && time < 2)
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

