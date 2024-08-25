using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Android.Types;
using Unity.VisualScripting;
using UnityEngine;

// Pointer Script that shows the direction of ghost if not on screen
public class PointerScript : MonoBehaviour
{
    private Transform player;
    private Transform target;
    private Transform cameraPos;

    private GameObject mySpriteRenderer;
    private GameObject myArrow;

    [SerializeField] private float distanceX;
    [SerializeField] private float distanceY;

    [SerializeField] private float floatingDistance;
    [SerializeField] private float arrowFloat;

    [SerializeField] private float sizeMax;
    [SerializeField] private float sizeMin;


    public void setup(GameObject target)
    {
        this.target = target.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            player = FindObjectOfType<PlayerMovement>().gameObject.transform;
            Debug.Log("Pointer - Player found");
        }

        catch
        {
            Debug.LogError("Pointer - No player to anchor to");
        }

        try
        {
            cameraPos = FindObjectOfType<VirtualCamera>().gameObject.transform;
            Debug.Log("Pointer - Camera found");
        }

        catch
        {
            Debug.LogError("Pointer - No Camera to calculate with");
        }

        mySpriteRenderer = this.transform.Find("Sprite").gameObject;
        myArrow = this.transform.Find("Arrow").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && target != null && cameraPos != null)
        {
            if (Mathf.Abs(cameraPos.position.x - target.position.x) > distanceX || (Mathf.Abs(player.position.y - target.position.y) > distanceY))
            {
                float scale = 0;
                scale += 16/(target.position - cameraPos.position).magnitude;

                if (scale > sizeMax)
                {
                    scale = sizeMax;
                }

                else if (scale < sizeMin)
                {
                    scale = sizeMin;
                }

                this.transform.localScale = scale*Vector3.one;

                mySpriteRenderer.SetActive(true);
                myArrow.SetActive(true);
            }

            else
            {
                mySpriteRenderer.SetActive(false);
                myArrow.SetActive(false);
            }

            Vector2 size = target.position - player.position;

            this.transform.position = player.position + floatingDistance * (target.position - player.position) / (target.position - player.position).magnitude;
        }

        if (myArrow.activeSelf)
        {
            myArrow.transform.position = this.transform.position + arrowFloat * (this.transform.position - player.position) / (this.transform.position - player.position).magnitude;

            if (myArrow.transform.position.x - player.transform.position.x < 0)
            {
                myArrow.transform.rotation = Quaternion.Euler(0, 0, Vector3.Angle(this.transform.position - player.position, Vector3.up));
            }
            else
            {
                myArrow.transform.rotation = Quaternion.Euler(0, 0, Vector3.Angle(this.transform.position - player.position, Vector3.up) * -1);
            }
        }
    }
}