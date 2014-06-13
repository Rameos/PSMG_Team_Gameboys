using UnityEngine;
using System.Collections;

public class BeerTrigger : MonoBehaviour {

	bool canSwitch = false;
	bool waitActive = false;

	void OnTriggerStay (Collider other) {

		if(Input.GetKeyDown("f"))
		{

			if(GameObject.Find("bier").transform.parent == null && !waitActive) {
				Debug.Log("if");
				GameObject.Find("bier").transform.parent = GameObject.Find("pickto").transform;
				Destroy(GameObject.Find("bier").GetComponent("RotateObject"));
				StartCoroutine(Wait());   
			}
			else if(!waitActive){
				Debug.Log("else");
				GameObject.Find("bier").transform.parent = null;
				GameObject.Find("bier").AddComponent("RotateObject");
				StartCoroutine(Wait());   
			}
		}


	}
	IEnumerator Wait(){
		waitActive = true;
		yield return new WaitForSeconds (0.2f);
		canSwitch = true;
		waitActive = false;
	}
}
