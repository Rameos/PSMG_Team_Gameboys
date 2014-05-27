using UnityEngine;
using System.Collections;

public class Camera_Escape : MonoBehaviour {

    public Transform target;

    private GameObject mainCamera;

    private float distance;

	// Use this for initialization
	void Awake () {
        mainCamera = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        mainCamera.transform.LookAt(target); 
	}
}
