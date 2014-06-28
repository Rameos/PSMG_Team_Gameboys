using UnityEngine;
using System.Collections;

[System.Serializable]

public class AudioManager : MonoBehaviour {
	
	public AudioClip [] Steps;
	public static bool isWalkingSoundPlaying;

	// Use this for initialization
	void Start () {
		audio.clip = Steps [0];
	}
	
	// Update is called once per frame
	void Update () {
		isWalkingSoundPlaying = audio.isPlaying;
	}

	public void handleWalkingSound (bool controller){
		if (controller) {
			audio.Play ();
		} else {
			audio.Stop (); 
		}
	}

	public void handleSpeedWalkingSound (int condition) {
		audio.clip = Steps [condition];
	}
}
