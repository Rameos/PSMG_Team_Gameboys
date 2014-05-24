using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Transform target;

    private GameObject enemy;

    private float speed;
    private float sightRadius;
    private float followingRadius;
    private float currentAttentionRadius;

    private bool playerFollowed;

	// Use this for initialization
	void Start () {
        enemy = gameObject;

        sightRadius = 30f;
        followingRadius = 60f;
        currentAttentionRadius = sightRadius;
        speed = 0.5f;

        playerFollowed = false;
	}

    void LateUpdate()
    {
        if (playerFollowed && Vector3.Distance(target.position, enemy.transform.position) <= currentAttentionRadius)
        {
            enemy.transform.rotation = Quaternion.LookRotation(target.position - enemy.transform.position);
            enemy.transform.position += enemy.transform.TransformDirection(Vector3.forward * speed);
        }
        else
        {
            playerFollowed = false;
            currentAttentionRadius = sightRadius;
        }
    }

    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerFollowed = true;
            currentAttentionRadius = followingRadius;
        }
    }

    /*
    void OnTriggerStay()
    {
        if (Vector3.Distance(target.position, enemy.transform.position) <= currentAttentionRadius) 
        {
            enemy.transform.rotation = Quaternion.LookRotation(target.position - enemy.transform.position);
            enemy.transform.position += enemy.transform.TransformDirection(Vector3.forward * speed);
        }
    }

    void OnTriggerExit()
    {
        followingRadius = 0;
    }
     */
}
