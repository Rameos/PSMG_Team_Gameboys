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
			GameObject.FindGameObjectWithTag(TagManager.BEER).transform.position = new Vector3(577.37f, 101.68f, 263.06f);
			GameObject.FindGameObjectWithTag (TagManager.BIERBER).animation.CrossFade ("BierberWalkAndCutTree", 0f);
			GameObject.FindGameObjectWithTag(TagManager.BIERBER_INVISIBLE_WALL).collider.enabled = false;
			//System.Threading.Thread.Sleep (2500);
			StartCoroutine(fallingTree());
			GameObject.FindGameObjectWithTag("MinimapAngler").GetComponent<ColorBlue>().setRenderer(false);

			
		}


	}
	IEnumerator fallingTree(){
		yield return new WaitForSeconds(3);
		GameObject.FindGameObjectWithTag (TagManager.STAMM).animation.CrossFade ("FallingTree", 0f);
	}
}
