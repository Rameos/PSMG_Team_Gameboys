using UnityEngine;
using System.Collections;

public class DelayedRendering : MonoBehaviour {

	// Render this object with a delay
	void Start () {
	    renderer.material.renderQueue = 2800; 
	}
	

}
