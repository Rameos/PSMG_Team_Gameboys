using UnityEngine;
using System.Collections;

public class BierberTrigger : MonoBehaviour {
	
	void OnTriggerEnter (Collider other) {
		if(GameObject.Find("BierberBody").renderer.enabled == false)
		{
			GameObject.Find("BierberBody").renderer.enabled = true;
			GameObject.Find("BierberHead").renderer.enabled = true;
		}
		if(GameObject.Find("bier").transform.parent == GameObject.Find("pickto").transform)
		{
			GameObject.Find("bier").transform.parent = GameObject.Find("BierberBody").transform;
			GameObject.Find("bier").transform.position = new Vector3(577.37f, 101.68f, 263.06f);
			GameObject.Find("FallenTree").renderer.enabled = true;
			GameObject.Find("FallenTree").collider.enabled = true;
			GameObject.Find("BierberInvisibleWall").collider.enabled = false;
			
		}
	}
}
