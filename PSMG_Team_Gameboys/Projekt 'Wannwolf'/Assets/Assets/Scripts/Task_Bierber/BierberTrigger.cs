using UnityEngine;
using System.Collections;

public class BierberTrigger : MonoBehaviour {


	
	void OnTriggerEnter (Collider other) {

		/*
         * play bierber appear animation (if not already happened)
         */
		if(GameObject.FindGameObjectWithTag(TagManager.BIERBER_BODY).renderer.enabled == false)
		{
			GameObject.FindGameObjectWithTag (TagManager.BIERBER).animation.CrossFade ("BierberAppear", 0f);
			GameObject.FindGameObjectWithTag(TagManager.BIERBER_BODY).renderer.enabled = true;
			GameObject.FindGameObjectWithTag(TagManager.BIERBER_HEAD).renderer.enabled = true;

		}
	/*
         * if player carries the beer:
         * - play cut tree animation
         * - unparent beer and make it immovable
         */
		if(GameObject.FindGameObjectWithTag(TagManager.BEER).transform.parent == GameObject.Find("pickto").transform)
		{
			GameObject.FindGameObjectWithTag(TagManager.BEER).transform.parent = GameObject.Find(TagManager.BIERBER_BODY).transform;
            GameObject.FindGameObjectWithTag(TagManager.BEER).GetComponent<DragByPlayer>().enabled = false;
           
			GameObject.FindGameObjectWithTag (TagManager.BIERBER).animation.CrossFade ("BierberWalkAndCutTree", 0f);

			StartCoroutine(fallingTree());

			// Disable the renderer of the angler's minimap icon
			GameObject.FindGameObjectWithTag("MinimapAngler").GetComponent<ColorBlue>().setRenderer(false);

			
		}


	}
	IEnumerator fallingTree(){
		yield return new WaitForSeconds(3);
        Destroy(GameObject.FindGameObjectWithTag(TagManager.BIERBER_INVISIBLE_WALL));
        GameObject.FindGameObjectWithTag(TagManager.STAMM).animation.Play("FallingTree");
	}
}
