using UnityEngine;
using System.Collections;

[System.Serializable]

public class AudioManager : MonoBehaviour {
	
	public AudioClip [] Steps;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void handleWalkingSound (bool controller){
		if (controller) {
			audio.clip = Steps [0];
			audio.Play ();
		} else {
			audio.Stop (); 
		}
	}

}
