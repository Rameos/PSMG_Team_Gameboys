using UnityEngine;
using System.Collections;

public class DragByPlayer : MonoBehaviour {
    private bool waitActive = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void follow(GameObject obj, bool rotate)
    {
        if(rotate == true){
            obj = GameObject.Find("bier");
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
