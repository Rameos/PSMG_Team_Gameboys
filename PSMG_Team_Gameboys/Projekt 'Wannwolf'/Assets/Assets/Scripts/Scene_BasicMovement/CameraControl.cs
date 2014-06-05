using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    private const float passingTime = 3f;

    public Transform target;
    public Transform terrain;
    
    private Transform mainCamera;

    private float walkDistance;
    private float height;
    private float mouseX;
    private float mouseY;
    private float timePassed;
    private bool hitMap;

	// Use this for initialization
	void Start () {
        mainCamera = transform;
        walkDistance = 20f;
        height = 50f;
        mouseX = 0f;
        mouseY = 0f;
        timePassed = 0f;
        hitMap = false;
	}

    void LateUpdate()
    {
        mainCamera.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        mainCamera.position = mainCamera.rotation * new Vector3(0, 0, -walkDistance) + target.position;
        mainCamera.LookAt(target);

        if (!hitMap)
        {
            mouseX += Input.GetAxis("Mouse X") * 5;
            mouseY += Input.GetAxis("Mouse Y") * 5;
        }
        else
        {
            mouseX += Input.GetAxis("Mouse X") * 5;
            mouseY += 2;
        }

        recalculateRotateAngles();
        
        checkHit();
        setCameraPosition();
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

    void setupCameraMovement()
    {
        if (mouseY <= 5)
                {
                    mouseY = 5;
                }
                 else if (mouseY >= 75)
                {
                    mouseY = 75;
                }
        setCameraPosition();
    }

    void setCameraPosition()
    {
        if (Input.GetAxis("Mouse Y") == 0)
        {
            float cameraSpeed = 0.25f;
            timePassed += Time.deltaTime;

            if (mouseY > 26 && timePassed >= passingTime && !hitMap)
            {
                mouseY -= cameraSpeed;
            }
            else if (mouseY < 24 && timePassed >= passingTime && !hitMap)
            {
                mouseY += cameraSpeed;
            }
        }
        else timePassed = 0;
    }

    void checkHit()
    {
        RaycastHit hit = new RaycastHit();
        float x = 0;
        float rayDistance = 10f;

        if (Physics.Raycast(mainCamera.transform.position, camera.transform.TransformDirection(Vector3.back), out hit, rayDistance))
        {
            hitMap = true;
        }
        else x++;

        if (Physics.Raycast(mainCamera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit, rayDistance))
        {
            hitMap = true;
        }
        else x++;

        if (Physics.Raycast(mainCamera.transform.position, camera.transform.TransformDirection(Vector3.left), out hit, rayDistance))
        {
            hitMap = true;
        }
        else x++;

        if (Physics.Raycast(mainCamera.transform.position, camera.transform.TransformDirection(Vector3.right), out hit, rayDistance))
        {
            hitMap = true;
        }
        else x++;

        if (Physics.Raycast(mainCamera.transform.position, camera.transform.TransformDirection(Vector3.up), out hit, rayDistance))
        {
            hitMap = true;
        }
        else x++;

        if (x == 5)
        {
            hitMap = false;
        }

    }
}
