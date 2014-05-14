using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Transform target;

    private GameObject timeBuster;

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
