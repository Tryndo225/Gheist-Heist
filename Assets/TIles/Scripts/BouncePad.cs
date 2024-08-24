using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    // Mono mode bounce strenght variable
    [SerializeField] private float bounceStrenght;

    // Mode selection check
    [SerializeField] private bool directionModeCheck;

    // Direction mode variables
    [SerializeField] private float bounceStrenghtRight;
    [SerializeField] private float bounceStrenghtLeft;
    [SerializeField] private Vector2 bounceDirectionRight;
    [SerializeField] private Vector2 bounceDirectionLeft;

    // Player reference
    [SerializeField] private Rigidbody2D playerBody;

    // Sound effect file
    [SerializeField] private AudioClip soundEffect;

    // Responsible for the main fuctioning of the bouncepad where both directions are streated equally
    void monoMode()
    {
        playerBody.velocity = new Vector2(playerBody.velocity.x, bounceStrenght);
        SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
    }

    // Resposible for directional operation of bouncepad (different strenghts and angles based on the direction of movement when entering collision)
    void directionMode()
    {
        if (playerBody.velocity.x > 0)
        {
            playerBody.velocity = bounceDirectionRight * bounceStrenghtRight;
        }

        else if (playerBody.velocity.x < 0)
        {
            playerBody.velocity = bounceDirectionLeft * bounceStrenghtLeft;
        }

        else
        {
            playerBody.velocity = Vector2.up * (bounceStrenghtRight + bounceStrenghtLeft) / 2;
        }

        SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
    }

    // Runs unpon player entering collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (directionModeCheck)
            {
                directionMode();
            }

            else
            {
                monoMode();
            }

        }
    }
}