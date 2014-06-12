using UnityEngine;
using System.Collections;

public class AutomaticMovement : MonoBehaviour {

    public Transform mainCamera;

	// Update is called once per frame
	void Update () {
        //gameObject.transform.rotation = Quaternion.LookRotation(mainCamera.position - gameObject.transform.position);
        //gameObject.transform.localPosition += gameObject.transform.TransformDirection(Vector3.forward*0.2f);
        gameObject.transform.position += new Vector3(1f, 0f, 0f) * 0.2f;
	}
}
