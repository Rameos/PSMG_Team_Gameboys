using UnityEngine;
using System.Collections;

public class EnemyFollowing : MonoBehaviour {

    public Transform player;

    private GameObject enemy;

    private float speed;
    private float climbSpeed;
    private bool climb;
    private bool go;

    void Awake()
    {
        go = false;
        speed = 0.35f;
        climbSpeed = 3f;
        climb = false;
        enemy = gameObject;
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.8f);
        go = true;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (go)
        {
            enemy.transform.rotation = Quaternion.LookRotation(player.position - enemy.transform.position);
            if (!climb)
            {
                enemy.transform.position += enemy.transform.TransformDirection(Vector3.forward * speed);
            }
            else
            {
                enemy.transform.position += enemy.transform.TransformDirection(Vector3.up * speed * climbSpeed);
            }
        }
	}

    void OnTrigerEnter(Collider col){
        if(col.gameObject.tag == TagManager.BARRIER)
        {
            climb = true;
        }
    }

    void OnTriggerStay(Collider col){
        if (col.gameObject.tag == TagManager.BARRIER)
        {
            climb = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == TagManager.BARRIER)
        {
            climb = false;
        }
    }
 }

