using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class PlayerControl : MonoBehaviour {

    private const float minWaitTime = 0.01f;   //Min time the player has to rest after a 'full' run //WAS 3f!!
    private const float jumpStrength = 20f;
    private const float playerRunSpeed = 30f; // was 30f, set up for debugging purposes!
    private const float playerWalkSpeed = 20f;
    private const float playerSneakSpeed = 10f;
    private const float gravityBoost = 3.5f;
	private const int slowWalking = 0;
	private const int speedWalking = 1;


    public Transform mainCamera;

    // Beverages
    private bool hasVodka;
    private bool drankVodka;
    private bool hadVodka;
    private bool ableToDoubleJump;

    private CharacterController characterController;

    private Vector3 gravity;
    private Vector3 alternativeMoveTo;

    private float playerSpeed;
    private float pastTime;
    private float maxRunTime;
    private float jumps;

    private bool jumping;
    private bool run;
    private bool runable;
    private bool sneak;

	AudioManager audioManager;

	// Use this for initialization
	void Awake () {
        characterController = GetComponent<CharacterController>();
		audioManager = GetComponent<AudioManager>();   
        gravity = Vector3.zero;
        alternativeMoveTo = Vector3.zero;

        playerSpeed = playerWalkSpeed;
        pastTime = 0f;
        maxRunTime = 6f;
        jumps = 0;

        jumping = false;
        run = false;
        runable = true;
        sneak = false;


        hadVodka = false;
        hasVodka = false;
        drankVodka = false;
        ableToDoubleJump = false;
	}
	
	// Update is called once per frame
	void Update () {
		move ();
	}

    //Moves the Player depending on the Inputs
    void move()
    {
        setNotJumpable();
        setJumpCondition();
        setRunCondition();
        setSneakCondition();
        setWalkCondition();
        setPlayerMovement();
    }

    private void setPlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (drankVodka)
        {
            horizontal *= -1;
            vertical *= -1;
        }

        Vector3 moveTo = new Vector3(horizontal, 0f, vertical);

        setGravity();
        setupMoveToVector(ref moveTo);

        if (horizontal != 0 || vertical != 0) {
            playWalkingSound();
			alternativeMoveTo = moveTo;
            rotateInCameraView();
            animation.Play("Armature|Eberhardt_Walk");
            animation["Armature|Eberhardt_Walk"].speed = 1.0f;

		} else if (jumping && horizontal == 0 && vertical == 0) {
			characterController.Move (alternativeMoveTo * Time.deltaTime);
			audioManager.handleWalkingSound(false);
		} else if (horizontal != 0 || vertical != 0) {
			audioManager.handleWalkingSound(false);
        }
        else if (jumping)
        {
            audioManager.handleWalkingSound(false);
        }
        else
        {
            animation.Stop();
        }

        characterController.Move(moveTo * Time.deltaTime);

    }

    void rotateInCameraView()
    {
        Quaternion playerRotation = new Quaternion(mainCamera.localRotation.x, 0f, mainCamera.localRotation.z, 0f);
        characterController.transform.localRotation = playerRotation;
        characterController.transform.Rotate(180f, 0, 0);
    }

    //Checks if sneak key is pressed
    void setSneakCondition()
    {
        sneak = OnKeyFunctions.OnKeyDownNegative("Run/Sneak");

        if (sneak)
        {
            playerSpeed = playerSneakSpeed;
            animation.Play("Armature|Eberhardt_Walk");
            animation["Armature|Eberhardt_Walk"].speed = 0.5f;
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
			audioManager.handleSpeedWalkingSound(speedWalking);
            animation.Play("Armature|Eberhardt_Walk");
            animation["Armature|Eberhardt_Walk"].speed = 2f;

        }
        else
        {
            runRest();
			audioManager.handleSpeedWalkingSound(slowWalking);
        }
    }

    //Checks if the player has rest enough or has to rest any longer to be able to run
    void runRest()
    {
        if (pastTime > 0)
        {
            pastTime -= Time.deltaTime;
        }
        if (maxRunTime - pastTime >= minWaitTime)
        {
            runable = true;
        }
    }

    //Counts the period of time the player runs and sets the player's run permission
    void countRunTime()
    {
        pastTime += Time.deltaTime;

        if (maxRunTime - pastTime <= 0)
        {
            runable = false;
        }
    }

    void setJumpCondition()
    {
        if (ableToDoubleJump)
        {
            if (Input.GetButtonDown("Jump") && jumps < Time.deltaTime * 2)
             {
                jumping = true;
                gravity.y = jumpStrength;
                jumps += Time.deltaTime;
             }
        }else
        {
             if (Input.GetButtonDown("Jump") || Input.GetAxis("Jump") > 0)
                    {
                        jumping = true;
                    }
        }
    }

    void setNotJumpable()
    {
        if (characterController.collisionFlags == CollisionFlags.Below || characterController.isGrounded)
        {
            jumping = false;
            jumps = 0;
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

	void playWalkingSound(){
		if (!AudioManager.isWalkingSoundPlaying) {
			audioManager.handleWalkingSound(true);	
		}
	}

	public float sprintTimeStatus {
        get { return maxRunTime; }
        set { maxRunTime *= value; }
	}

    public bool ableToDoubleJumpStatus
    {
        get { return ableToDoubleJump; }
        set { ableToDoubleJump = value; }
    }

    public bool vodkaStatus
    {
        get { return hasVodka; }
        set { hasVodka = value; }
    }

    public bool drankStatus
    {
        get { return drankVodka; }
        set { drankVodka = value; }
    }

    public bool hadVodkaOnce
    {
        get { return hadVodka; }
        set { hadVodka = value; }
    }

    public float getPlayerSpeed
    {
        get { return playerSpeed; }
    }
}
