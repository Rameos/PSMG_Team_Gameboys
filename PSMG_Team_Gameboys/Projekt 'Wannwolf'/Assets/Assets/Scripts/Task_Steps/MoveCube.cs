using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour {

    public Transform target;
    float moveSpeed = 20;
    bool moving = false;
    float stop = 5f;
    float rotationSpeed = 5;

    void Start()
    {
        gameObject.GetComponent<FollowPlayer>().enabled = false;
    }

    void OnTriggerStay(Collider other)
    {


        if (Input.GetKeyDown("f"))
        {
            if (moving == false)
            {
                moving = true;
                gameObject.GetComponent<FollowPlayer>().enabled = true;
            }
            else
            {
                moving = false;
                gameObject.GetComponent<FollowPlayer>().enabled = false;
            }
           }
        if (moving == true)
        {
            //float distance = Vector3.Distance(transform.position,target.position);
            //if (distance <= stop)
            //{
              //  transform.rotation = Quaternion.Slerp(transform.rotation,
               // Quaternion.LookRotation(target.position - transform.position), rotationSpeed * Time.deltaTime);
                //transform.Rotate(0, 0, 0);
            //}
            //else
            //{
              //  Vector3 newPos = target.position;
                //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, newPos, 0.2f);
            //}
        }
           
      //  }







    }
  

}
