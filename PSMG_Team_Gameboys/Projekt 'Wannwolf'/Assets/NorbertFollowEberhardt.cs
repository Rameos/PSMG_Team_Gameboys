﻿using UnityEngine;
using System.Collections;

public class NorbertFollowEberhardt : MonoBehaviour
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
    Transform norbert; //current transform data of this enemy

    void Awake()
    {
        norbert = transform; //cache transform data for easy access/performance
    }

    void Start()
    {
        gravity = Vector3.zero;
        controller = norbert.GetComponent<CharacterController>();
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER).transform; //target the player

    }

    void Update()
    {
        //rotate to look at the player
        float distance = Vector3.Distance(norbert.position, player.position);

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
                controller.transform.rotation = Quaternion.Slerp(norbert.rotation,
                Quaternion.LookRotation(player.position - controller.transform.position), rotationSpeed * Time.deltaTime);
                controller.Move(moveTo * Time.deltaTime);
                controller.transform.Rotate(-90, Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, Space.World);
            }
            else
                if (distance <= stop)
                {
                    controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation,
                    Quaternion.LookRotation(player.position - controller.transform.position), rotationSpeed * Time.deltaTime);
                    controller.transform.Rotate(-90, 0, 0);
                }
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