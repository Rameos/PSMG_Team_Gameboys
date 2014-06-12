using UnityEngine;
using System.Collections;

public class PLayerMovement : MonoBehaviour {

    public Transform playerEmpty;
	
	// Update is called once per frame
	void Update () {
        playerEmpty.Rotate(new Vector3(1f, 0f, 0f), -Input.GetAxis("Horizontal"));
	}
}
