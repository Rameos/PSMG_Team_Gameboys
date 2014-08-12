using UnityEngine;
using System.Collections;

public class DragByPlayer : MonoBehaviour {
    private bool waitActive = false;

    public void follow(GameObject obj, bool rotate)
    {
        if(rotate == true){
            obj = GameObject.FindGameObjectWithTag(TagManager.BEER);
        }
        if (obj.transform.parent == null && !waitActive)
        {
            Debug.Log("if");
            obj.transform.parent = GameObject.Find("pickto").transform;
            if (rotate == true)
            {
                Destroy(obj.GetComponent("RotateObject"));
            }
            StartCoroutine(Wait());
        }
        else if (!waitActive)
        {
            Debug.Log("else");
            obj.transform.parent = null;
            if (rotate == true)
            {
                obj.AddComponent("RotateObject");
            }

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
