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
    Transform pizza; //current transform data of this enemy

    void Awake()
    {
        pizza = transform; //cache transform data for easy access/performance
    }

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag(TagManager.PIZZA).GetComponent<CharacterController>();
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
                //move towards the player
                controller.transform.rotation = Quaternion.Slerp(pizza.rotation,
                Quaternion.LookRotation(player.position - controller.transform.position), rotationSpeed * Time.deltaTime);
                controller.Move(controller.transform.forward * moveSpeed * Time.deltaTime);
                controller.transform.Rotate(0, Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0,Space.World);
            } 
            else 
                if (distance <= stop)
                {
                    controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation,
                    Quaternion.LookRotation(player.position - controller.transform.position), rotationSpeed * Time.deltaTime);
                    controller.transform.Rotate(0, 0, 0);
                }
    }
}