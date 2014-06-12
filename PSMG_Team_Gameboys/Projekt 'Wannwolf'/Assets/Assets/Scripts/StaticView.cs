using UnityEngine;
using System.Collections;

public class StaticView : MonoBehaviour {

    private Transform camera;

	// Use this for initialization
	void Start () {
        camera = transform; 
        camera.position = new Vector3(100, 50, -200);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
