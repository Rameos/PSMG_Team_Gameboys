using UnityEngine;
using System.Collections;

public class PLayerMovement : MonoBehaviour {

    public Transform treeTrunk;
    public Transform plane;

    private Transform player;

	// Use this for initialization
	void Start () {
        player = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
        treeTrunk.Rotate(new Vector3(0f, 1f, 0f), Input.GetAxis("Horizontal"));
        plane.position += new Vector3(0f, 0f, Input.GetAxis("Horizontal")); 
	}
}
