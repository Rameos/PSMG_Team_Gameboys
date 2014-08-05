using UnityEngine;
using System.Collections;

[RequireComponent(typeof(DragByPlayer))]
public class MoveCube : MonoBehaviour {
    private DragByPlayer drag;

   

    void Start()
    {
        drag = GetComponent<DragByPlayer>();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
        
                if (Input.GetKeyDown("f"))
                {
                    //tree = GameObject.FindGameObjectWithTag("n");
                    drag.follow(gameObject, false);
                }

         


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


            //  }




        }


    }

    
  

}
