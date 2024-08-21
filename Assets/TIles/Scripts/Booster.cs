using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] private float boostStrenghtHorizontal;
    [SerializeField] private float boostStrenghtVertical;
    [SerializeField] private Rigidbody2D playerBody;

    [SerializeField] private AudioClip soundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x * boostStrenghtHorizontal,  playerBody.velocity.y * boostStrenghtVertical);
            SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
        }
    }
}
