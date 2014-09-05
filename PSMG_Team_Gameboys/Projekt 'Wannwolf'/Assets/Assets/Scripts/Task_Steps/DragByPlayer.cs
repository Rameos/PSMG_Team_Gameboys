using UnityEngine;
using System.Collections;

public class DragByPlayer : MonoBehaviour {

    private GameObject obj;
    private bool waitActive = false;
    private bool isBeer = false;

    void Start()
    {
        obj = gameObject;
        if (obj.tag == TagManager.BEER)
        {
            isBeer = true;
        }
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
        if (obj.transform.parent == null && GameObject.Find("pickto").GetComponentInChildren<DragByPlayer>() == null && !waitActive)
        {
            obj.transform.parent = GameObject.Find("pickto").transform;
            obj.transform.position = GameObject.Find("pickto").transform.position;
            obj.collider.enabled = false;

            destroyRotation();
            
            StartCoroutine(Wait());
        }
        else if (!waitActive)
        {
            obj.collider.enabled = true;
            obj.transform.parent = null;
            addRotation();

            StartCoroutine(Wait());
        }
    }

    void destroyRotation()
    {
        if(isBeer)
        Destroy(obj.GetComponent<RotateObject>());
    }

    void addRotation()
    {
        if(isBeer)
        obj.AddComponent<RotateObject>();
    }

    IEnumerator Wait()
    {
        waitActive = true;
        yield return new WaitForSeconds(0.2f);
        waitActive = false;
    }
}
