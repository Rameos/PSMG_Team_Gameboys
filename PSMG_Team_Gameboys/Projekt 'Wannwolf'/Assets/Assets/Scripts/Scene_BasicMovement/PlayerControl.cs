using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class PlayerControl : MonoBehaviour {

    private const float minTime = 3f;   //Min time the player has to rest after a 'full' run
    private const float maxTime = 6f;   //Max time the player is able to run
    private const float jumpStrength = 20f;
    private const float playerRunSpeed = 30f;
    private const float playerWalkSpeed = 20f;
    private const float playerSneakSpeed = 10f;
    private const float gravityBoost = 3.5f;

    public Transform mainCamera;

    private CharacterController characterController;

    private Vector3 gravity;
    private Vector3 alternativeMoveTo;

    private float playerSpeed;
    private float pastTime;

    private bool jumping;
    private bool run;
    private bool runable;
    private bool sneak;

    MoneyManagement money; // Money Management

	// Use this for initialization
	void Awake () {
        characterController = GetComponent<CharacterController>();
        
        gravity = Vector3.zero;
        alternativeMoveTo = Vector3.zero;

        playerSpeed = playerWalkSpeed;
        pastTime = 0f;

        jumping = false;
        run = false;
        runable = true;
        sneak = false;

        money = GetComponent<MoneyManagement>();
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
        setNotJumpable();
    }

    private void setPlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveTo = new Vector3(horizontal, 0f, vertical * -1);

        setGravity();
        setupMoveToVector(ref moveTo);
        
        if (horizontal != 0 || vertical != 0)
        {
            alternativeMoveTo = moveTo;
            Quaternion playerRotation = new Quaternion(mainCamera.localRotation.x, 0f, mainCamera.localRotation.z, 0f);
            characterController.transform.rotation = playerRotation;
        }else if (jumping && horizontal == 0 && vertical == 0)
             {
                 characterController.Move(alternativeMoveTo * Time.deltaTime);
             }

        characterController.Move(moveTo * Time.deltaTime);
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
        if (Input.GetAxis("Jump") > 0 && !jumping)
        {
            jumping = true;
        }
    }

    void setNotJumpable()
    {
        if (characterController.collisionFlags == CollisionFlags.Below || characterController.isGrounded)
        {
            jumping = false;
            alternativeMoveTo = Vector3.zero;
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
                gravity.y = jumpStrength;
            }
        }
    }

    void setupMoveToVector(ref Vector3 moveToVector)
    {
        moveToVector.Normalize();
        moveToVector = characterController.transform.TransformDirection(moveToVector);
        moveToVector *= playerSpeed;
        moveToVector += gravity;
    }
}
