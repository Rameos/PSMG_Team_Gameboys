using UnityEngine;
using System.Collections;

public class Camera_Control : MonoBehaviour {

    public Transform target;

    public bool cameraReversed;
    
    private Transform mainCamera;

    private float walkDistance;
    private float height;
    private float mouseX;
    private float mouseY;

	// Use this for initialization
	void Start () {
        mainCamera = transform;
        walkDistance = 20f;
        height = 50f;
        mouseX = 0f;
        mouseY = 0f;
	}

    void LateUpdate()
    {   
        mainCamera.position = new Vector3(target.transform.position.x - walkDistance, target.transform.position.y + height, target.transform.position.z);
        mainCamera.LookAt(target);

        mouseX += Input.GetAxis("Mouse X")*5;
        mouseY += Input.GetAxis("Mouse Y")*5;

        recalculateRotateAngles();
        cameraReverseStatus();
    }

    void recalculateRotateAngles()
    {
        if (mouseX > 360)
        {
            mouseX -= 360;
        }
        else if (mouseX < 0)
        {
            mouseX += 360;
        }
        setupCameraMovement();
    }

    void cameraReverseStatus()
    {
        Quaternion rotation;
       
        if (cameraReversed)
        {
           rotation = Quaternion.Euler(-mouseY, mouseX, 0);
        }
        else
        {
            rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }

        Vector3 position = rotation * new Vector3(0, 0, -walkDistance) + target.position;
        mainCamera.rotation = rotation;
        mainCamera.position = position;
    }

    void setupCameraMovement()
    {
        if (cameraReversed)
        {
            if (mouseY > -5)
            {
                mouseY = -5;
            }
            else if (mouseY <= -75)
            {
                mouseY = -75;
            }
        }else
            {
                if (mouseY < 5)
                {
                    mouseY = 5;
                }
                 else if (mouseY >= 75)
                {
                    mouseY = 75;
                }
            }

    }
}
