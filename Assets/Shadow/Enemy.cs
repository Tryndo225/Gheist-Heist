using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Transactions;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform playerBody;

    [SerializeField] private float timeAfter;

    [SerializeField] private float timeDiff;
    private List<float> timer;
    private List<Vector2> positions;

    [SerializeField] private float speed;
    [SerializeField] private float threshhold;
    [SerializeField] private float midTime;
    [SerializeField] private float maxTime;

    private Vector2 positionPoint;
    private bool started = false;




    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector2>();
        timer = new List<float>();
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        positions.Add(playerBody.position);
        timer.Add(Time.deltaTime);

        timeDiff = 0;
        foreach (float i in timer)
        {
            timeDiff += i;
        }

        var step = speed * Time.deltaTime;

        if (timeDiff > timeAfter)
        {
            if (!started)
            {
                started = true;
                positionPoint = positions[0];
                this.transform.position = positionPoint;
                positions.RemoveAt(0);
                timer.RemoveAt(0);
            }

            while ((new Vector2(this.transform.position.x, this.transform.position.y) - positionPoint).magnitude < threshhold && positions.Count > 1)
            {
                timeAfter -= timer[0];
                timer.RemoveAt(0);
                positionPoint = positions[0];
                positions.RemoveAt(0);
            }


            if (timeAfter + midTime <= maxTime)
            {
                timeAfter += midTime;
            }

            //this.transform.position = positions[0];
            //listPoint = Random.Range(0, positions.Count - 1);

            this.transform.position = Vector3.MoveTowards(this.transform.position, positionPoint, step);
        }

        else if (started)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, positionPoint, step);
        }
    }
}
