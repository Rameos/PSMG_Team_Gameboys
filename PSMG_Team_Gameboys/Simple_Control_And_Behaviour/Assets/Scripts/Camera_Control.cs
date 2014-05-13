using UnityEngine;
using System.Collections;

public class Camera_Control : MonoBehaviour {

    public Transform target;
    
    private Transform cameraOne;

    private float walkDistance;
    private float height;
    private float mouseX;
    private float mouseY;

	// Use this for initialization
	void Start () {
        cameraOne = transform;
        walkDistance = 20f;
        height = 50f;
        mouseX = 0f;
        mouseY = 0f;
	}

    void LateUpdate()
    {   
        cameraOne.position = new Vector3(target.transform.position.x - walkDistance, target.transform.position.y + height, target.transform.position.z);
        cameraOne.LookAt(target);

        mouseX += Input.GetAxis("Mouse X")*10;
        mouseY += Input.GetAxis("Mouse Y")*10;

        Quaternion rotation = Quaternion.Euler(-mouseY,mouseX,0);
        Vector3 position = rotation * new Vector3(0, 0, -walkDistance) + target.position;

        cameraOne.rotation = rotation;
        cameraOne.position = position;
    }

}
