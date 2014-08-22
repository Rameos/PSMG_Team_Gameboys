using UnityEngine;
using System.Collections;

public class DragByPlayer : MonoBehaviour {

    private GameObject obj;
    private bool waitActive = false;

    void Start()
    {
        obj = gameObject;
    }

    void OnTriggerStay()
    {
        if (Input.GetKeyDown("f"))
        {
            follow();
        }
    }

    void follow()
    {
        if (obj.transform.parent == null && !waitActive)
        {
            obj.transform.parent = GameObject.Find("pickto").transform;

            Destroy(obj.GetComponent<RotateObject>());
            
            StartCoroutine(Wait());
        }
        else if (!waitActive)
        {
            obj.transform.parent = null;
            obj.AddComponent<RotateObject>();

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
