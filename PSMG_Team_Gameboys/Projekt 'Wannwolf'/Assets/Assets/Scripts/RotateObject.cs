using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {

	/*
     * very complicated function.
     * rotates object on three axis
     */
	void Update () {
		transform.Rotate (new Vector3 (10, 5, 25) * Time.deltaTime);
	}
}
