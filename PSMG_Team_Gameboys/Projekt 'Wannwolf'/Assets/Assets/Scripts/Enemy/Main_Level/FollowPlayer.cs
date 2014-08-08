using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{


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
        player = GameObject.FindWithTag("Player").transform; //target the player

    }

    void Update()
    {
        //rotate to look at the player
        float distance = Vector3.Distance(pizza.position, player.position);
        if (distance <= attackRange && distance >= attentionRange)
        {
            pizza.rotation = Quaternion.Slerp(pizza.rotation,
            Quaternion.LookRotation(player.position - pizza.position), rotationSpeed * Time.deltaTime);
        }
        else
            if (distance <= attentionRange && distance > stop)
            {
                //move towards the player
                pizza.rotation = Quaternion.Slerp(pizza.rotation,
                Quaternion.LookRotation(player.position - pizza.position), rotationSpeed * Time.deltaTime);
                pizza.position += pizza.forward * moveSpeed * Time.deltaTime;
                pizza.Rotate(0, Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0,Space.World);
            } 
            else 
                if (distance <= stop)
                {
                    pizza.rotation = Quaternion.Slerp(pizza.rotation,
                    Quaternion.LookRotation(player.position - pizza.position), rotationSpeed * Time.deltaTime);
                    pizza.Rotate(0, 0, 0);
                }
    }


}