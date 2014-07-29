using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour {

    public Transform target;
    float moveSpeed = 20;



    void OnTriggerStay(Collider other)
    {


       // if (Input.GetKeyDown("f"))
       // {
           // if (target != null)
           // {
                //transform.position = Vector3.MoveTowards(transform.position, target.position, 1);
                //gameObject.transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
           // }
           
      //  }







    }
  

}
