using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Transactions;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

/* 
 * Enemy script
 * - Handles ghost movements
*/
public class Enemy : MonoBehaviour
{
    // Player body variable
    [SerializeField] private Transform playerBody;

    // Adjustable follow time
    [SerializeField] private float timeAfter;

    // Timer and position lists
    private List<float> timer;
    private List<Vector2> positions;


    // Adjustable variables for fine-tuning ghost movement
    [SerializeField] private float speed;
    [SerializeField] private float threshhold;
    [SerializeField] private float midTime;
    [SerializeField] private float maxTime;

    // Last position varaible - for determining next viable possition
    private Vector2 positionPoint;

    // Game object state check
    private bool started = false;


    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector2>();
        timer = new List<float>();
        this.gameObject.SetActive(false);
    }

    // Teleports ghost to starting possition
    void firstStart()
    {
        started = true;
        positionPoint = positions[0];
        this.transform.position = positionPoint;
        positions.RemoveAt(0);
        timer.RemoveAt(0);
    }

    // Finds viable position for ghost to move towards - skips sectors with minimal movement (optimilizes ghost movement ensuring game difficulty)
    void findViablePos()
    {
        while ((new Vector2(this.transform.position.x, this.transform.position.y) - positionPoint).magnitude < threshhold && positions.Count > 1)
        {
            timeAfter -= timer[0];
            timer.RemoveAt(0);
            positionPoint = positions[0];
            positions.RemoveAt(0);
        }
    }

    // Calculates diference in players and ghosts position - in sec
    float gapTime()
    {
        float timeDiff = 0;
        foreach (float i in timer)
        {
            timeDiff += i;
        }
        return timeDiff;
    }

    // FixedUpdate is called once per set time
    /*
     * 
     * 
    */
    void FixedUpdate()
    {
        // Adds current players possition
        positions.Add(playerBody.position);
        timer.Add(Time.deltaTime);

        float timeDiff = gapTime();

        // Variable for step distance
        var step = speed * Time.deltaTime;

        if (timeDiff > timeAfter)
        {
            if (!started)
            {
                firstStart();
            }
            findViablePos();

            // Dinamically changes the ghsot follow ofset based on 
            if (timeAfter + midTime <= maxTime)
            {
                timeAfter += midTime;
            }

            // Moves ghost towards new location
            this.transform.position = Vector3.MoveTowards(this.transform.position, positionPoint, step);
        }

        // Moves towards last viable position
        else if (started)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, positionPoint, step);
        }
    }
}
