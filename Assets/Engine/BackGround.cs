using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    //Variables able to be set from Unity
    [SerializeField] private Transform cameraBody;
    [SerializeField] private float xDistance;
    [SerializeField] private float yDistance;
    [SerializeField] private float xJumpDistance;
    [SerializeField] private float yJumpDistance;

    // Update is called once per frame
    //Ensures the movemnt of BackGround graphics when using static background mode
    void Update()
    {
        if (Mathf.Abs(cameraBody.position.x - this.transform.position.x) > xDistance)
        {
            if (cameraBody.position.x - this.transform.position.x < 0)
            {
                this.transform.position = new Vector2(this.transform.position.x - xJumpDistance, this.transform.position.y);
            }

            else
            {
                this.transform.position = new Vector2(this.transform.position.x + xJumpDistance, this.transform.position.y);
            }
        }

        if (Mathf.Abs(cameraBody.position.y - this.transform.position.y) > yDistance)
        {
            if (cameraBody.position.y - this.transform.position.y < 0)
            {
                this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - yJumpDistance);
            }

            else
            {
                this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + yJumpDistance);
            }
        }
    }
}
