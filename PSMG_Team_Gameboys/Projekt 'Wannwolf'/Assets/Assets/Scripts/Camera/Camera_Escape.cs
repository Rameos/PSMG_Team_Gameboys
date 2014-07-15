using UnityEngine;
using System.Collections;

public class Camera_Escape : MonoBehaviour {

    public Transform player;

    private GameObject escapeCamera;

    private float distance;
    private float height;

	// Use this for initialization
	void Awake () {
        escapeCamera = gameObject;
        distance = 30f;
        height = 10f;
	}
	
	// Update is called once per frame
	void  Update () {
        escapeCamera.transform.position = new Vector3(distance, height, 0f) + player.position;
	}
}
