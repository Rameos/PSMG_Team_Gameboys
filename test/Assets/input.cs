using UnityEngine;
using System.Collections;

public class input : MonoBehaviour {

	public float speed = 0.1f;
	public float JumpSpeed = 5.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
				float transformV = UnityEngine.Input.GetAxis ("Vertical") * speed;
				float transformH = UnityEngine.Input.GetAxis ("Horizontal") * speed;

				transform.Translate (transformH, 0, transformV);

				if (Input.GetKeyDown("space")) {
					Debug.Log("jump");
			rigidbody.velocity += (Vector3.up *JumpSpeed);
	
				}
		}
}

