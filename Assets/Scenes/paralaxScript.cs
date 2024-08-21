using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scrip for background - when paralax effect is turned on
public class paralaxScript : MonoBehaviour
{
    private Vector3 startPossition;
    [SerializeField] private Transform cameraBody;

    // Start is called before the first frame update
    void Start()
    {
        // Sets default position
        startPossition = this.transform.position;
    }

    // Update is called once per frame - handles the paralax
    void FixedUpdate()
    {
        this.transform.position = startPossition + (cameraBody.position - startPossition) / 2;
    }
}
