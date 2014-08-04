using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour {

    public GameObject tree;
    private bool waitActive = false;

    void Start()
    {

    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (gameObject.tag == "n")
            {
                if (Input.GetKeyDown("n"))
                {
                    tree = GameObject.FindGameObjectWithTag("n");
                    follow();
                }

            }
            else if (gameObject.tag == "m")
            {
                if (Input.GetKeyDown("m"))
                {
                    tree = GameObject.FindGameObjectWithTag("m");
                    follow();
                }

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

    void follow()
    {
        if (tree.transform.parent == null && !waitActive)
        {
            Debug.Log("if");
            tree.transform.parent = GameObject.Find("pickto").transform;
            StartCoroutine(Wait());
        }
        else if (!waitActive)
        {
            Debug.Log("else");
            tree.transform.parent = null;
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
