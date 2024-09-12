using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Sound Clips
    [SerializeField] private AudioClip[] jumpSounds;
    [SerializeField] private AudioClip[] landSounds;
    [SerializeField] private AudioClip ghostDeath;
    [SerializeField] private AudioClip laserDeath;

    // Exal Drag
    [SerializeField] private float exalDrag;

    // Ground Drag
    [SerializeField] private float groundDrag;

    // Box Projection Ground Parameters 
    [SerializeField] private float distanceGround;
    [SerializeField] private Vector3 boxSizeGround;

    // Box Projection Wall Parameters 
    [SerializeField] private float distanceWall;
    [SerializeField] private Vector3 boxSizeWall;

    // Box Drawing
    [SerializeField] private bool boxDraw;

    // Jump Parameters
    [SerializeField] private float jumpHeight;
    [SerializeField] private float bunnyHopWindow;
    [SerializeField] private float wallJumpHeight;
    [SerializeField] private float wallJumpBounce;

    // Movement Parameters
    [SerializeField] private float maxGroundSpeed;
    [SerializeField] private float groundSpeed;
    [SerializeField] private float airSpeed;
    [SerializeField] private float maxAirSpeed;

    // Physics Bodies
    [SerializeField] private Rigidbody2D myBody;
    [SerializeField] private Transform myTransform;

    // Layer for Ground
    [SerializeField] private LayerMask layerGround;
    [SerializeField] private LayerMask layerWall;

    // Movement Stopping Checks
    private bool checkRight;
    private bool checkLeft;

    // Jump Int
    private int wallJumpInt;

    // Colision Detection
    GameSession targetScript;

    private bool facingRight;
    private bool inAirCheck;

    // Function checks whether the object is grounded
    private bool isGrounded(float offset = 0)
    {
        if (Physics2D.BoxCast(myTransform.position, boxSizeGround, 0, -Vector2.up, distanceGround + offset, layerGround))
        {
            if (offset == 0 && inAirCheck)
            {
                landSound();
            }
            inAirCheck = false;
            return true;
        }
        inAirCheck = true;
        return false;

    }

    // Function check for wall touches for wall-jumping
    private int wallJump()
    {
        if (Physics2D.BoxCast(myTransform.position, boxSizeWall, 0, -Vector2.right, distanceWall, layerWall))
        { return 1; }

        else if (Physics2D.BoxCast(myTransform.position, boxSizeWall, 0, Vector2.right, distanceWall, layerWall))
        { return -1; }

        return 0;
    }

    // Collider Boxes - draws collider boxes for better visualization when testing using gizmos
    private void OnDrawGizmos()
    {
        if (boxDraw)
        {
            // ground box 
            Gizmos.color = Color.yellow;
            Gizmos.DrawCube(myTransform.position - Vector3.up * distanceGround, boxSizeGround);

            // bunnyhop box
            Gizmos.color = Color.blue;
            Gizmos.DrawCube(myTransform.position - new Vector3(0, distanceGround + bunnyHopWindow, 0), boxSizeGround);

            // side boxes
            Gizmos.color = Color.red;
            Gizmos.DrawCube(myTransform.position + Vector3.right * distanceWall, boxSizeWall);
            Gizmos.DrawCube(myTransform.position - Vector3.right * distanceWall, boxSizeWall);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        targetScript = GameObject.Find("Game Session").GetComponent<GameSession>();
    }

    // Plays jump sounds
    void jumpSound()
    {
        SoundFXManager.soundFXManagerInstance.playRandomSoundFXClip(jumpSounds, myTransform);
    }

    // Plays landing sounds
    void landSound()
    {
        SoundFXManager.soundFXManagerInstance.playRandomSoundFXClip(landSounds, myTransform);
    }

    // Handles response when jumping
    void jump()
    {
        wallJumpInt = wallJump();
        if (isGrounded(bunnyHopWindow))
        {
            myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight);
            jumpSound();
        }

        else if (wallJumpInt != 0)
        {
            myBody.velocity = new Vector2(wallJumpInt * wallJumpBounce, wallJumpHeight);
            jumpSound();
        }
    }

    // Gives player downwards Y-axis movement
    void fastFall()
    {
        myBody.velocity += Vector2.down * airSpeed;
    }

    // Handles Left input
    void left()
    {
        if (isGrounded())
        {
            if (Mathf.Abs(myBody.velocity.x - (Vector2.right * groundSpeed).magnitude) <= maxGroundSpeed || Mathf.Abs(myBody.velocity.x) > Mathf.Abs(myBody.velocity.x - (Vector2.right * groundSpeed).magnitude))
            {
                myBody.velocity -= new Vector2(groundSpeed, 0);
            }

            else if (Mathf.Abs(myBody.velocity.x - (Vector2.right * groundSpeed).magnitude) > maxGroundSpeed && myBody.velocity.magnitude <= maxGroundSpeed)
            {
                myBody.velocity = new Vector2(-maxGroundSpeed, myBody.velocity.y);
            }

        }

        else if (Mathf.Abs(myBody.velocity.x - (Vector2.right * airSpeed).magnitude) <= maxAirSpeed || Mathf.Abs(myBody.velocity.x) > Mathf.Abs(myBody.velocity.x - (Vector2.right * airSpeed).magnitude))
        {
            myBody.velocity -= Vector2.right * airSpeed;
        }
    }

    // Handles Right input
    void right()
    {
        if (isGrounded())
        {
            if (Mathf.Abs(myBody.velocity.x + (Vector2.right * groundSpeed).magnitude) <= maxGroundSpeed || Mathf.Abs(myBody.velocity.x) > Mathf.Abs(myBody.velocity.x + (Vector2.right * groundSpeed).magnitude))
            {
                myBody.velocity += new Vector2(groundSpeed, 0);
            }

            else if (Mathf.Abs(myBody.velocity.x + (Vector2.right * groundSpeed).magnitude) > maxGroundSpeed && myBody.velocity.magnitude <= maxGroundSpeed)
            {
                myBody.velocity = new Vector2(maxGroundSpeed, myBody.velocity.y);
            }
        }

        else if (Mathf.Abs(myBody.velocity.x + (Vector2.right * airSpeed).magnitude) <= maxAirSpeed || Mathf.Abs(myBody.velocity.x) > Mathf.Abs(myBody.velocity.x + (Vector2.right * airSpeed).magnitude))
        {
            myBody.velocity += Vector2.right * airSpeed;
        }
    }

    // Flips the player model
    private void flip()
    {
        myTransform.localScale = new Vector2(-1 * myTransform.localScale.x, myTransform.localScale.y);
        facingRight = !facingRight;
    }

    //Jump input
    private void Update()
    {
        // Handles Jumping input
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            jump();
        }
    }

    // Update is called once per frame
    /* 
     * Update method is used for checking for player inputs and subsiquent implementions of those movements
    */
    void FixedUpdate()
    {
        // necessary checks
        checkRight = false;
        checkLeft = false;

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            fastFall();
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            left();
        }
        else
        {
            checkLeft = true;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            right();
        }
        else
        {
            checkRight = true;
        }

        // Created artificial drag
        if (checkRight && checkLeft)
        {
            if (isGrounded())
            {
                myBody.velocity = new Vector2(groundDrag * myBody.velocity.x, myBody.velocity.y);
            }

            else
            {
                myBody.velocity = new Vector2(myBody.velocity.x - (exalDrag) * myBody.velocity.x, myBody.velocity.y);
            }
        }

        if (checkLeft && !checkRight)
        {
            if (facingRight)
            {
                flip();
            }
        }
        else if (!checkLeft && checkRight)
        {
            if (!facingRight)
            {
                flip();
            }
        }
        /*
        // Animator purposes
        float movementX = myBody.velocity.x;
        float movementY = myBody.velocity.y;
        this.gameObject.GetComponent<Animator>().SetFloat("MovementX", movementX);
        this.gameObject.GetComponent<Animator>().SetFloat("MovementY", movementY);
        */
    }

    // Handles death when colliding with game objects tagged as Enemy/Laser - Using Unity Trigger System
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            SoundFXManager.soundFXManagerInstance.playSoundFXClip(ghostDeath, myTransform);
            Debug.Log("Contact ghost");
            targetScript.setDead();
        }

        else if (other.gameObject.tag == "Laser")
        {
            SoundFXManager.soundFXManagerInstance.playSoundFXClip(laserDeath, myTransform);
            Debug.Log("Contact laser");
            targetScript.setDead();
        }
    }
}
