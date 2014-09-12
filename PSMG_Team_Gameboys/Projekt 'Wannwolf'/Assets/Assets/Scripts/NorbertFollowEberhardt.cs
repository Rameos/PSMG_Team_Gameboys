using UnityEngine;
using System.Collections;

public class NorbertFollowEberhardt : MonoBehaviour
{

    CharacterController controller;
    Transform player; //norberts target
    float moveSpeed; //move speed
    float rotationSpeed = 5; //speed of turning
    float stop = 12f;
    float gravityBoost = 3.5f;
    Vector3 gravity;
    PlayerControl control;
    Transform norbert; //current transform data of this enemy
    RaycastHit hit;

    void Awake()
    {
        norbert = transform; //cache transform data for easy access/performance
    }

    void Start()
    {
        gravity = Vector3.zero;
        controller = norbert.GetComponent<CharacterController>();
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER).transform; //target the player
        control = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<PlayerControl>();
        moveSpeed = control.getPlayerSpeed;
       
    }

    void Update()
    {
        setGravity();
        // Distance to the Player
        float distance = Vector3.Distance(norbert.position, player.position);
        //var rotation = new Quaternion(norbert.rotation.x, norbert.rotation.y, norbert.rotation.z, norbert.rotation.w);
        controller.transform.rotation = Quaternion.Slerp(norbert.rotation,
                Quaternion.LookRotation(player.position - controller.transform.position), rotationSpeed * Time.deltaTime);
        
       
               
        if (distance > stop)
        {
            Vector3 moveTo = Vector3.forward;
            setupMoveToVector(ref moveTo);

            norbert.position = Vector3.MoveTowards(norbert.position, player.position, moveSpeed * Time.deltaTime);
            animation.Play("Norbert_Kopf|Norbert_Walk");
        }

        else if(distance <= stop)
		{
            
            animation.Play("Norbert_Kopf|Norbert_Walk");
		}

    }

    void LateUpdate()
    {
        moveSpeed = control.getPlayerSpeed;
        /**if (animation["Gehen"].enabled == false)
        {
            animation.Play("Gehen");
        }*/
    }

	void rotateNorbert() 
	{
		float currentX = norbert.eulerAngles.x;
		float currentY = norbert.eulerAngles.y;
		//float currentZ = norbert.eulerAngles.z;
		controller.transform.localEulerAngles = new Vector3 (currentX - 270, currentY - 90, 0);
	}

    void setupMoveToVector(ref Vector3 moveToVector)
    {
        moveToVector.Normalize();
        moveToVector = controller.transform.TransformDirection(moveToVector);
        moveToVector *= moveSpeed;
        moveToVector += gravity;
    }

    void setGravity()
    {
        if (!controller.isGrounded)
        {
            gravity += Physics.gravity * Time.deltaTime * gravityBoost;
        }
        else
        {
            gravity = Vector3.zero;
        }
    }
}