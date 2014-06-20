using UnityEngine;
using System.Collections;

public class AutomaticMovement : MonoBehaviour {

    public Transform mainCamera;

    private float speed;
    private bool stop;

    void Awake()
    {
        speed = 0.3f;
        stop = false;
    }

	// Update is called once per frame
	void Update () {
        if (!stop)
        {
            gameObject.transform.position += new Vector3(1f, 0f, 0f) * speed;
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Barrier")
        {
            stop = true;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Barrier")
        {
            stop = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Barrier")
        {
            stop = false;
        }
    }
}
