using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour {

 
    private bool waitActive = false;





    void OnTriggerStay(Collider other)
    {
     
       // id = obj.ToCharArray();

       // if (Input.GetKeyDown("f"))
       // {
           // if (target != null)
           // {
                //transform.position = Vector3.MoveTowards(transform.position, target.position, 1);
                //gameObject.transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
        //transform.position += transform.forward * moveSpeed * Time.deltaTime;
           // }
           
      //  }
        if (gameObject.tag == "m")
        {
            if (Input.GetKeyDown("m"))
            {
                follow();
            }
        }
        else if (gameObject.tag == "n")
        {
            if (Input.GetKeyDown("n"))
            {
                follow();
            }
        }

    
    }

    void follow()
    {
        if (gameObject.transform.parent == null && !waitActive)
        {
            Debug.Log("if");
            gameObject.transform.parent = GameObject.Find("pickto").transform;
            //Destroy(GameObject.Find("Cube").GetComponent("RotateObject"));
            StartCoroutine(Wait());
        }
        else if (!waitActive)
        {
            Debug.Log("else");
            gameObject.transform.parent = null;
            //GameObject.Find("Cube").AddComponent("RotateObject");
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        waitActive = true;
        yield return new WaitForSeconds(0.2f);
        waitActive = false;
    }
  

}
