using UnityEngine;
using System.Collections;

public class AutomaticMovement : MonoBehaviour {

    public Transform mainCamera;

    private MoneyManagement money;
    private float speed;
    private bool stop;

    void Awake()
    {
        speed = 0.3f;
        stop = true;
        money = GetComponent<MoneyManagement>();
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.8f);
        stop = false;
    }

	// Update is called once per frame
	void FixedUpdate () {
        if (!stop)
        {
            gameObject.transform.position += new Vector3(1f, 0f, 0f) * speed;
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == TagManager.BARRIER)
        {
            stop = true;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == TagManager.BARRIER)
        {
            stop = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == TagManager.BARRIER)
        {
            stop = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == TagManager.MUSHROOM)
        {
            money.addMoney(1);
            GameObject.Destroy(col.gameObject);
        }
    }
}
