using UnityEngine;
using System.Collections;

public class TreeTrigger : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if (other == GameObject.FindGameObjectWithTag (TagManager.BIERBER)) {
			Debug.Log("TreeTrigger if");
				System.Threading.Thread.Sleep (1000);
				GameObject.FindGameObjectWithTag (TagManager.STAMM).animation.CrossFade ("FallingTree", 0f);
		}
	}
}
