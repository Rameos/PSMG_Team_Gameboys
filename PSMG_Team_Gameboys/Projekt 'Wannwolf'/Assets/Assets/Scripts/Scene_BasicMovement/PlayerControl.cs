using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class PlayerControl : MonoBehaviour {

    private const float minTime = 3f;   //Min time the player has to rest after a 'full' run
    private const float maxTime = 6f;   //Max time the player is able to run
    private const float jumpStrength = 25f;
    private const float playerRunSpeed = 60f;
    private const float playerWalkSpeed = 40f;
    private const float playerSneakSpeed = 20f;
    private const float gravityBoost = 3f;

    public Transform mainCamera;

    private CharacterController characterController;
    private GameObject playerEmpty;

    private Vector3 gravity;

    private float playerSpeed;
    private float pastTime;

    private bool jumping;
    private bool run;
    private bool runable;
    private bool sneak;

	// Use this for initialization
	void Awake () {
        characterController = GetComponent<CharacterController>();
        playerEmpty = GameObject.FindGameObjectWithTag("PlayerEmpty");
        
        gravity = Vector3.zero;

        playerSpeed = playerWalkSpeed;
        pastTime = 0f;

        jumping = false;
        run = false;
        runable = true;
        sneak = false;
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}

    //Moves the Player depending on the Inputs
    void move()
    {
        setRunCondition();
        setSneakCondition();
        setWalkCondition();
        setJumpCondition();

        setPlayerMovement();
    }

    private void setPlayerMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical")*-1;

        Vector3 move = new Vector3(h, 0f, v);
        move.Normalize();
        move = characterController.transform.TransformDirection(move);
        move *= playerSpeed;

        setGravity();

        move += gravity;

        Quaternion emptyRotation = new Quaternion(mainCamera.localRotation.x, 0, mainCamera.localRotation.z, 0);
        
        playerEmpty.transform.rotation = emptyRotation;

        if (h != 0 || v != 0)
        {
            characterController.transform.rotation = emptyRotation;
        }

        characterController.Move(move * Time.deltaTime);
    }

    //Checks if sneak key is pressed
    void setSneakCondition()
    {
        sneak = OnKeyFunctions.OnKeyDownNegative("Run/Sneak");

        if (sneak)
        {
            playerSpeed = playerSneakSpeed;
        }
    }

    //Checks if player's neither sneaking nor running
    void setWalkCondition()
    {
        if (!sneak && (!run || !runable))
        {
            playerSpeed = playerWalkSpeed;
        }
    }

    //Checks if run key is pressed
    void setRunCondition()
    {
        run = OnKeyFunctions.OnKeyDownPositive("Run/Sneak");
        if (run && runable && !jumping)
        {
            countRunTime();
            playerSpeed = playerRunSpeed;
        }
        else
        {
            runRest();
        }
    }

    //Checks if the player has rest enough or has to rest any longer to be able to run
    void runRest()
    {
        if (pastTime > 0)
        {
            pastTime -= Time.deltaTime;
        }
        if (maxTime - pastTime >= minTime)
        {
            runable = true;
        }
    }

    //Counts the period of time the player runs and sets the player's run permission
    void countRunTime()
    {
        pastTime += Time.deltaTime;

        if (maxTime - pastTime <= 0)
        {
            runable = false;
        }
    }

    void setJumpCondition()
    {
        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            jumping = true;
        }
    }

    void setGravity()
    {
        if (!characterController.isGrounded)
        {
            gravity += Physics.gravity * Time.deltaTime * gravityBoost;
        }
        else
        {
            gravity = Vector3.zero;
            if (jumping)
            {
                jumping = false;
                gravity.y = jumpStrength;
            }
        }
    }
}
