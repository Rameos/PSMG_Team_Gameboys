﻿using UnityEngine;
using System.Collections;

public class TimeBuster : MonoBehaviour {

    public Transform target;

    private GameObject timeBuster;

    private HitCounter hitCounter;

    private float speed;
    private float sightRadius;
    private float followingRadius;
    private float hitTime;

    private bool targetFollowed;

	// Use this for initialization
	void Start () {
        timeBuster = gameObject;

        sightRadius = 30f;
        followingRadius = 60f;
        speed = 0.5f;
        hitTime = 0.0f;

        targetFollowed = false;
	}

    void Update()
    {
        if (Vector3.Distance(target.position, timeBuster.transform.position) <= sightRadius)
        {
            targetFollowed = true;
        }

        destroyCondition();
    }

    void LateUpdate()
    {
        if (Vector3.Distance(target.position, timeBuster.transform.position) <= followingRadius && targetFollowed)
        {
            timeBuster.transform.rotation = Quaternion.LookRotation(target.position - timeBuster.transform.position);
            timeBuster.transform.position += timeBuster.transform.TransformDirection(Vector3.forward * speed);
        }
        else
        {
            targetFollowed = false;
        }
    }

    private void destroyCondition()
    {
        if(Vector3.Distance(target.position, timeBuster.transform.position) <= 5)
        {
            hitTime += Time.deltaTime;
        }
        if (hitTime >= 5)
        {
            hitCounter.GetComponent<HitCounter>().HitNumber++;
        }
        if (hitCounter.GetComponent<HitCounter>().HitNumber >= 3)
        {
            DestroyObject(timeBuster);
        }
    }

    /*
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            followingRadius = 30;
        }
    }

    void OnTriggerStay()
    {
        if (Vector3.Distance(target.position, timeBuster.transform.position) <= radius) 
        {
            timeBuster.transform.rotation = Quaternion.LookRotation(target.position - timeBuster.transform.position);
            timeBuster.transform.position += timeBuster.transform.TransformDirection(Vector3.forward * speed);
        }
    }

    void OnTriggerExit()
    {
        followingRadius = 0;
    }
     */
}
