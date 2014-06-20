using UnityEngine;
using System.Collections;

public class EnemyFollowing : MonoBehaviour {

    public Transform player;

    private GameObject enemy;

    private float speed;
    private float gravity;
    private bool climb;
    private bool grounded;

    void Awake()
    {
        speed = 0.3f;
        gravity = 1f;
        climb = false;
        grounded = true;
        enemy = gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        enemy.transform.rotation = Quaternion.LookRotation(player.position - enemy.transform.position);
        if(!climb)
        {
            enemy.transform.position += enemy.transform.TransformDirection(Vector3.forward * speed);
            if (!grounded)
            {
                enemy.transform.position += enemy.transform.TransformDirection(Vector3.down * gravity);
            }
        }else{
            enemy.transform.position += enemy.transform.TransformDirection(Vector3.up * speed);
        }
	}

    void OnTrigerEnter(Collider col){
        if(col.gameObject.tag == "Barrier")
        {
            climb = true;
        }
    }

    void OnTriggerStay(Collider col){
        if (col.gameObject.tag == "Barrier")
        {
            climb = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Barrier")
        {
            climb = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.LogWarning("CollisionEnter");
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    void OnCollisionStay(Collision col)
    {
        Debug.LogWarning("CollisionEnter");
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
 }

