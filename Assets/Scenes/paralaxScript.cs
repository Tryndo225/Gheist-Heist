using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralaxScript : MonoBehaviour
{
    private Vector3 startPossition;
    [SerializeField] private Transform cameraBody;
    // Start is called before the first frame update
    void Start()
    {
        startPossition = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = startPossition + (cameraBody.position - startPossition)/2;
    }
}
