using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    [SerializeField] private float bounceStrenght;
    //[SerializeField] private float bounceStrenghtRight;
    //[SerializeField] private float bounceStrenghtLeft;
    //[SerializeField] private Vector2 bounceDirectionRight;
    //[SerializeField] private Vector2 bounceDirectionLeft;
    [SerializeField] private Rigidbody2D playerBody;

    [SerializeField] private AudioClip soundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            /*
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
                playerBody.velocity = Vector2.up * (bounceStrenghtRight + bounceStrenghtLeft)/2;
            }
            */
            playerBody.velocity = new Vector2(playerBody.velocity.x, bounceStrenght);
            SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
        }
    }
}
