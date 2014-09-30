using UnityEngine;
using System.Collections;

public class PLayerMovement : MonoBehaviour {

    private const float gravityBoost = 3.5f;
    private const float jumpStrength = 25f;
    public int hasPieces;

    public Transform treeTrunk;

    private CharacterController characterController;

    private bool jumping;
    private Vector3 gravity;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();

        gravity = Vector3.zero;
        jumping = true;
    }

	// Update is called once per frame
	void Update () {
        moveHorizontal();
        setJumpCondition();
        setGravity();
        characterController.Move(gravity * Time.deltaTime);
        notJumping();
	}

    void moveHorizontal()
    {
        treeTrunk.Rotate(new Vector3(0f, 0f, 1f), Input.GetAxis("Horizontal") * 2);
    }

    void setJumpCondition()
    {
        if (Input.GetButtonDown("Jump") || Input.GetAxis("Jump") > 0)
        {
            jumping = true; 
        }
    }

    void notJumping()
    {
        if (characterController.isGrounded)
        {
            jumping = false;
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
}
