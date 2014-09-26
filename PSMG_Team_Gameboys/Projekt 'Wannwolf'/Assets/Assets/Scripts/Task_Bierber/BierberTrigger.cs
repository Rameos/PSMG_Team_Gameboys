using UnityEngine;
using System.Collections;

public class BierberTrigger : MonoBehaviour {


	
	void OnTriggerEnter (Collider other) {

		if(GameObject.FindGameObjectWithTag(TagManager.BIERBER_BODY).renderer.enabled == false)
		{
			GameObject.FindGameObjectWithTag (TagManager.BIERBER).animation.CrossFade ("BierberAppear", 0f);
			GameObject.FindGameObjectWithTag(TagManager.BIERBER_BODY).renderer.enabled = true;
			GameObject.FindGameObjectWithTag(TagManager.BIERBER_HEAD).renderer.enabled = true;

		}
		if(GameObject.FindGameObjectWithTag(TagManager.BEER).transform.parent == GameObject.Find("pickto").transform)
		{
			GameObject.FindGameObjectWithTag(TagManager.BEER).transform.parent = GameObject.Find(TagManager.BIERBER_BODY).transform;
            GameObject.FindGameObjectWithTag(TagManager.BEER).transform.position = new Vector3(574.5643f, 104.2155f, 233.2953f);
            Destroy(GameObject.FindGameObjectWithTag(TagManager.BEER).transform.collider);
			GameObject.FindGameObjectWithTag (TagManager.BIERBER).animation.CrossFade ("BierberWalkAndCutTree", 0f);
			GameObject.FindGameObjectWithTag(TagManager.BIERBER_INVISIBLE_WALL).collider.enabled = false;
			StartCoroutine(fallingTree());

			// Disable the renderer of the angler's minimap icon
			GameObject.FindGameObjectWithTag("MinimapAngler").GetComponent<ColorBlue>().setRenderer(false);

			
		}


	}
	IEnumerator fallingTree(){
		yield return new WaitForSeconds(3);
		GameObject.FindGameObjectWithTag (TagManager.STAMM).animation.CrossFade ("FallingTree1", 0f);
	}
}
