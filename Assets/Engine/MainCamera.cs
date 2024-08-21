using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform playerBody;
    public Transform cameraBody;

    // Start is called before the first frame update
    void Start()
    {
        cameraBody.position = new Vector3(0, 10, -10);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerBody.position.x > 0)
        {
            cameraBody.position = new Vector3(playerBody.position.x, 10, -10);
        }
    }
}
