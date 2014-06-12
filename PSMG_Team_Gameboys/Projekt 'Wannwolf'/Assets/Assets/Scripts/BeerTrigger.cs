using UnityEngine;
using System.Collections;

public class BeerTrigger : MonoBehaviour {

	// Use this for initialization
	void OnTriggerStay (Collider other) {

		if(Input.GetKeyDown("f"))
		{

			GameObject.Find("bier").transform.parent = GameObject.Find("pickto").transform;
			Destroy(GameObject.Find("bier").GetComponent("RotateObject"));

		}
	}

}
