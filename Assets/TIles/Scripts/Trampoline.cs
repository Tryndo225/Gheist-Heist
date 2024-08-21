using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private bool up;
    [SerializeField] private bool down;
    [SerializeField] private bool left;
    [SerializeField] private bool right;

    [SerializeField] private Rigidbody2D playerBody;

    [SerializeField] private AudioClip soundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

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
            SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
        }
    }
}

