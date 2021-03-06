﻿using UnityEngine;
using System.Collections;

public class PickMushroom : MonoBehaviour {

    private const float livingtime = 15f;
    private const int mushroomValue = 5;

    private float passedTime = 0f;

    void Awake()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, 1), 90);
    }

    void Update ()
    {
        rotateObject();

		passedTime += Time.deltaTime;

        if (passedTime >= livingtime)
        {
            disappearMushroom();
        }
    }

    void OnTriggerEnter (Collider col)
    {
        if (col.tag == TagManager.PLAYER)
        {
            GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<MoneyManagement>().addMoney(mushroomValue);
            disappearMushroom();
        }
    }

    void rotateObject()
    {
        gameObject.transform.Rotate(new Vector3(1, 0, 0), 10);
    }

    void disappearMushroom()
    {
        Destroy(gameObject);
		passedTime = 0f;
    }
}
