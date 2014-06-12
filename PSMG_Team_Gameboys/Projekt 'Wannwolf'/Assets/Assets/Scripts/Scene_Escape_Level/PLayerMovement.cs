using UnityEngine;
using System.Collections;

public class PLayerMovement : MonoBehaviour {

    public Transform treeTrunk;
	
	// Update is called once per frame
	void Update () {
        treeTrunk.Rotate(new Vector3(0f, 0f, 1f), Input.GetAxis("Horizontal"));
	}
}
