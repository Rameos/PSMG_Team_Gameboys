using UnityEngine;
using System.Collections;

public class BierberTrigger : MonoBehaviour {
	
	void OnTriggerEnter (Collider other) {
		if(GameObject.Find("BierberBody").renderer.enabled == false)
		{
			GameObject.Find("BierberBody").renderer.enabled = true;
			GameObject.Find("BierberHead").renderer.enabled = true;
		}
		else if(GameObject.Find("bier").transform.parent == GameObject.Find("pickto").transform)
		{
			GameObject.Find("bier").transform.parent = null;
			GameObject.Find("FallenTree").renderer.enabled = true;
			GameObject.Find("FallenTree").collider.enabled = true;
			GameObject.Find("BierberInvisibleWall").collider.enabled = false;
			
		}
	}
}
