using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (10, 5, 25) * Time.deltaTime);
	}
}
