﻿using UnityEngine;
using System.Collections;

public class DragByPlayer : MonoBehaviour {

    private GameObject obj;
    private bool waitActive = false;
    private bool isBeer = false;
    private bool inTrigger = false;

    private string pickBeer = "Drücke \"F\" um \ndas Bier aufzunehmen";
    private string dropBeer = "Drücke \"F\" um \ndas Bier abzulegen";
    private string pickTree = "Drücke \"F\" um \nden Baumstamm aufzunehmen";
    private string dropTree = "Drücke \"F\" um \n den Baumstamm abzulegen";

    private GUIStyle center;


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

    //objects follow the player
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


    //informs the player how to pick up an item
    void OnGUI()
    {
        if (inTrigger)
        {
            if (isBeer)
            {
                center = new GUIStyle(GUI.skin.textField);
                center.alignment = TextAnchor.MiddleCenter;
                if (obj.transform.parent == null)
                {
                    GUI.TextField(new Rect((Screen.width - 170) / 2, (float)(Screen.height * 0.2), 170, 100), pickBeer, center);
                }
                else
                {
                    GUI.TextField(new Rect((Screen.width - 170) / 2, (float)(Screen.height * 0.2), 170, 100), dropBeer, center);
                }
            }
            else
            {
                if (obj.transform.parent == null)
                {
                    GUI.TextField(new Rect((Screen.width - 170) / 2, (float)(Screen.height * 0.2), 200, 100), pickTree, center);
                }
                else
                {
                    GUI.TextField(new Rect((Screen.width - 170) / 2, (float)(Screen.height * 0.2), 200, 100), dropTree, center);
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
