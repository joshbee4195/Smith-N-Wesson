using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public GameObject mesh;
    public bool hasDive = true;
    public float diveForce;

    public GameObject straw;


    // assign the player's camera (will fall back to Camera.main if left empty)
    public Transform playerCamera;
    public float minAimAngle = 14f; // degrees
    public float maxAimAngle = 70f; // degrees
    public float aimSmoothing = 10f; // higher = snappier

    public float longestBarrierPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;

        // fallback to main camera if none assigned
        if (playerCamera == null && Camera.main != null)
        {
            playerCamera = Camera.main.transform;
        }
        //need to rotate in direction of movement if in TS scene

        //movement

        //run, jump, flop forward - like a dive?
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
        {
            rb.drag = groundDrag;
        }

        else
        {
            rb.drag = 0;
        }

        if (!grounded)
        {
            if (Input.GetKeyDown(jumpKey))
            {
                //dive

                if (hasDive)
                {
                    Dive();
                    hasDive = false;
                }
            }
        }

       // Aiming();


        if (transform.position.z > longestBarrierPos)
        {
            longestBarrierPos = transform.position.z;
        }

        if (transform.position.z < longestBarrierPos)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, longestBarrierPos);
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
          // gen.points += 500;
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Time.timeScale = 0;

            gen.gameOver = true;
        }
    }


    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void Aiming2()
    {
        //rotate straw within bounds - 14-70
    }

    public void Aiming()
    {
        if (straw == null || playerCamera == null)
            return;

        // get camera forward and calculate pitch (angle above horizon)
        Vector3 camForward = playerCamera.forward;
        float pitch = Mathf.Asin(camForward.y) * Mathf.Rad2Deg; // -90..90

        // keep up/down sign, but enforce magnitude within min/max
        float clampedPitch = Mathf.Sign(pitch) * Mathf.Clamp(Mathf.Abs(pitch), minAimAngle, maxAimAngle);

        // Depending on the straw model orientation you may need to invert the pitch sign.
        // If the straw tips the wrong way, flip the sign on clampedPitch below.
        float finalPitch = -clampedPitch; // negate to match most Unity model conventions (adjust if needed)

        // preserve current local Y/Z rotations
        Vector3 currentLocalEuler = straw.transform.localEulerAngles;
        Quaternion targetLocal = Quaternion.Euler(currentLocalEuler.x, currentLocalEuler.y, finalPitch);

        // smooth rotate
        straw.transform.localRotation = Quaternion.Slerp(straw.transform.localRotation, targetLocal, Time.deltaTime * aimSmoothing);
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKeyDown(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        //moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        moveDirection = orientation.right * horizontalInput;


        // on ground
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

            hasDive = true;
        }

        // in air
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

          //  Debug.Log("in air");
        }

        Anim();
    }

    public void Anim()
    {
        if (grounded)
        {
            if (moveDirection != Vector3.zero)
            {
                //make box move / simulate physics


            }

            else
            {
                //lower box to ground


            }
        }

        else
        {
            //lower box to ground


        }
    }

    public void Dive()
    {
        //launch player forward
        //rotate model sideways

        //need to add short dive recovery phase


        //launch

        rb.AddForce(transform.forward * diveForce, ForceMode.Force);

        Debug.Log("Dive");
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }


  
}