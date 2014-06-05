using UnityEngine;
using System.Collections;

public class Camera_Escape : MonoBehaviour {

    public Transform target;

    private GameObject escapeCamera;

    private float distance;

	// Use this for initialization
	void Awake () {
        escapeCamera = gameObject;
	}
	
	// Update is called once per frame
	void  Update () {
        escapeCamera.transform.position = new Vector3(target.position.x + 200f, target.position.y + 50f, target.position.z);
        //escapeCamera.transform.LookAt(target);
        escapeCamera.transform.Rotate(new Vector3(0f, 0f, 1f), Input.GetAxis("Horizontal"));
	}
}
