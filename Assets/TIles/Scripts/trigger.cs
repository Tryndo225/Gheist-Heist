using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    private bool triggered;
    private GameObject enemyObject;

    private void Awake()
    {
        enemyObject = FindObjectOfType<Enemy>().gameObject;
    }
    private void Start()
    {
        triggered = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !triggered)
        {
            triggered = true;
            enemyObject.gameObject.SetActive(true);
        }
    }
}