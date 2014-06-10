using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (10, 10, 40) * Time.deltaTime);
	}
}
