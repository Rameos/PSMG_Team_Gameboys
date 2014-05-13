using UnityEngine;
using System.Collections;

public class killObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider Cube){
		if (Input.GetKeyDown ("k")) {
			Debug.Log ("kill");
			Destroy(gameObject);
		}

	
	}
}
