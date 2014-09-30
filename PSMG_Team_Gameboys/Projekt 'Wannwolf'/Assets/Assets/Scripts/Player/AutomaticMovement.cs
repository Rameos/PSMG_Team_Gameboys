using UnityEngine;
using System.Collections;

public class AutomaticMovement : MonoBehaviour {

    private const float speed = 0.6f;

    public Transform mainCamera;

    private bool stop;

    void Awake()
    {
        stop = true;
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
            playAnimaton();
            gameObject.transform.position += new Vector3(1f, 0f, 0f) * speed;
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == TagManager.BARRIER)
        {
            stopAnimation();
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

    void stopAnimation()
    {
        animation.Stop();
    }

    void playAnimaton()
    {
        animation.Play("Armature|Eberhardt_Walk");
        animation["Armature|Eberhardt_Walk"].speed = 6.0f;
    }

    public bool getStopStatus
    {
        get { return stop; } 
    }
}
