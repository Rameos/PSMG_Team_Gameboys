using UnityEngine;
using System.Collections;

public class DragByPlayer : MonoBehaviour {

    private GameObject obj;
    private bool waitActive = false;
    private bool isBeer = false;
    bool inTrigger = false;

    void Start()
    {
        obj = gameObject;
        if (obj.tag == TagManager.BEER)
        {
            isBeer = true;
        }
    }

    void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown("f"))
            {
                follow();
            }
        }
    }

    void OnTriggerEnter()
    {
        inTrigger = true;
    }

    void OnTriggerExit()
    {
        inTrigger = false;
    }

    void OnTriggerStay()
    {
      
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

    void OnGUI()
    {
        if (inTrigger)
        {
            if (isBeer)
            {
                if (obj.transform.parent == null)
                {
                    GUI.Button(new Rect((Screen.width - 170) / 2, (float)(Screen.height * 0.2), 170, 100), "Drücke \"F\" um \ndas Bier aufzunehmen");
                }
                else
                {
                    GUI.Button(new Rect((Screen.width - 170) / 2, (float)(Screen.height * 0.2), 170, 100), "Drücke \"F\" um \ndas Bier abzulegen");
                }
            }
            else
            {
                if (obj.transform.parent == null)
                {
                    GUI.Button(new Rect((Screen.width - 170) / 2, (float)(Screen.height * 0.2),200, 100), "Drücke \"F\" um \nden Baumstamm aufzunehmen");
                }
                else
                {
                    GUI.Button(new Rect((Screen.width - 170) / 2, (float)(Screen.height * 0.2), 200, 100), "Drücke \"F\" um \n den Baumstamm abzulegen");
                }
            }
            
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
