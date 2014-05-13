using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    private const float minTime = 3f;   //Min time the player has to rest after a 'full' run
    private const float maxTime = 6f;   //Max time the player is able to run
    private const float jumpStrength = 0.6f;
    private const float playerRunSpeed = 0.8f;
    private const float playerWalkSpeed = 0.3f;
    private const float playerSneakSpeed = 0.1f;

    public Transform cameraOne;

    private GameObject player;

    private float playerSpeed;
    private float jumpDecay;
    private float pastTime;

    private bool jumping;
    private bool run;
    private bool runable;
    private bool sneak;

	// Use this for initialization
	void Start () {
        player = gameObject;
        
        playerSpeed = playerWalkSpeed;
        jumpDecay = 0.1f;
        pastTime = 0f;

        jumping = false;
        run = false;
        runable = true;
        sneak = false;
	}
	
	// Update is called once per frame
	void Update () {
        move();
        jump();
	}

    //LateUpdate is called once per frame after Update()
    void LateUpdate()
    {
        setJumpCondition();
    }

    //Moves the Player depending on the Inputs
    void move()
    {
        setRunCondition();
        setSneakCondition();
        setWalkCondition();

        setPlayerMovement();
    }

    private void setPlayerMovement()
    {
        float h = Input.GetAxis("Horizontal") * playerSpeed;
        float v = Input.GetAxis("Vertical") * playerSpeed;

        Vector3 sidewards = h * player.transform.TransformDirection(Vector3.left) * -1.0f;
        Vector3 forward = v * player.transform.TransformDirection(Vector3.forward) * -1.0f;
        Quaternion playerRotation = new Quaternion(cameraOne.rotation.x, 0, cameraOne.rotation.z, 0);
        player.transform.rotation = playerRotation;
        player.transform.position += sidewards;
        player.transform.position += forward;
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
        if (run && runable)
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

    //Let the Player jump
    void jump()
    {
        if (jumping)
        {
            player.transform.position += new Vector3(0, jumpStrength - jumpDecay, 0);
            jumpDecay += 0.009f;
        }
    }

    //Checks if jump key is hit
    void setJumpCondition()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (!jumping)
            {
                jumping = true;
                jumpDecay = 0.1f;
            }   
        }
    }

    //Checks and sets the player's jump permission
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Floor")
        {
            jumping = false;
        }
    }
}
