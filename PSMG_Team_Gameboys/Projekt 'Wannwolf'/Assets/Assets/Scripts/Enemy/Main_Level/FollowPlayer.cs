using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{

    CharacterController controller;
    Transform player; //the pizza's target
    float moveSpeed = 20; //move speed
    float rotationSpeed = 5; //speed of turning
    float attentionRange = 40f;
    float attackRange = 20f;
    float stop = 10f;
    float gravityBoost = 3.5f;
    Vector3 gravity;
    Transform pizza; //current transform data of this enemy
    public bool isFollowing;

    void Awake()
    {
        pizza = transform; //cache transform data for easy access/performance
        isFollowing = false;
    }

    void Start()
    {
        gravity = Vector3.zero;
        controller = pizza.GetComponent<CharacterController>();
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER).transform; //target the player

    }

    void Update()
    {
        //rotate to look at the player
        float distance = Vector3.Distance(pizza.position, player.position);

        if (distance <= attackRange && distance >= attentionRange)
        {
            controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation,
            Quaternion.LookRotation(player.position - controller.transform.position), rotationSpeed * Time.deltaTime);
        }
        else
            if (distance <= attentionRange && distance > stop)
            {
                setGravity();
                Vector3 moveTo = Vector3.forward;
                setupMoveToVector(ref moveTo);
                //move towards the player
                controller.transform.rotation = Quaternion.Slerp(pizza.rotation,
                Quaternion.LookRotation(player.position - controller.transform.position), rotationSpeed * Time.deltaTime);
                controller.Move(moveTo * Time.deltaTime);
                controller.transform.Rotate(0, Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, Space.World);
                isFollowing = true;
            }
            else
                if (distance <= stop)
                {
                    controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation,
                    Quaternion.LookRotation(player.position - controller.transform.position), rotationSpeed * Time.deltaTime);
                    controller.transform.Rotate(0, 0, 0);
                }
    }

    /*void OnGUI()
    {
        if (isFollowing)
        {
                GUI.Button(new Rect(Screen.width - (Screen.width / 6), 0, Screen.width / 5, Screen.height / 8), "Drücke \"F\" um \nden Kampf sofort\nzu starten");
        }
    }*/

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