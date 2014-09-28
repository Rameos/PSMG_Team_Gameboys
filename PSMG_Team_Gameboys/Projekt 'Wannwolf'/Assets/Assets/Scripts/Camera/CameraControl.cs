using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    private const float passingTime = 3f;

    public Transform target;

    private Terrain terrain;
    private Transform mainCamera;

    private float walkDistance;
    private float mouseX;
    private float mouseY;
    private float timePassed;

    private float minCameraDistance;

    public bool drunkCamera;

	// Use this for initialization
	void Start () {
        terrain = Terrain.FindObjectOfType<Terrain>();
        mainCamera = transform;
        walkDistance = 30f;
        mouseX = 0f;
        mouseY = 0f;
        timePassed = 0f;
        minCameraDistance = 5f;
        drunkCamera = false;
	}

    void LateUpdate()
    {
        mainCamera.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        mainCamera.position = mainCamera.rotation * new Vector3(0, 0, -walkDistance) + target.position;
        mainCamera.LookAt(target);

        //if (!drunkCamera)
        //{
            mouseX += Input.GetAxis("Mouse X") * 3;
            mouseY += Input.GetAxis("Mouse Y") * 3;
        //}
        /**else
        {
            mouseX -= Input.GetAxis("Mouse X") * 3;
            mouseY -= Input.GetAxis("Mouse Y") * 3;
        }
        */

        checkHit();
        recalculateRotateAngles();
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
        if (mouseY <= minCameraDistance)
                {
                    mouseY = minCameraDistance;
                }
                 else if (mouseY >= 50)
                {
                    mouseY = 50;
                }
        //setCameraPosition();
    }

    void setCameraPosition()
    {
        if (Input.GetAxis("Mouse Y") == 0)
        {
            float cameraSpeed = 0.25f;
            timePassed += Time.deltaTime;

            if (mouseY > 26 && timePassed >= passingTime)
            {
                mouseY -= cameraSpeed;
            }
            else if (mouseY < 24 && timePassed >= passingTime)
            {
                mouseY += cameraSpeed;
            }
        }
        else timePassed = 0;
    }

    void checkHit()
    {
        RaycastHit hit;
       
        if (mainCamera.position.y - terrain.SampleHeight(mainCamera.transform.position) < 3)
        {
            mainCamera.position = Vector3.Slerp(mainCamera.transform.position, mainCamera.rotation * new Vector3(0, 4f, -walkDistance) + target.position, 100f);
            mainCamera.LookAt(target);
        }

        float rayDistance = 3f;

   
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.left), out hit, rayDistance))
                {
                    mouseY += rayDistance+4;
                }
        else if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.right), out hit, rayDistance))
                    {
                        mouseY += rayDistance+4;
                    }
    }

    // Set Camera drunk
    public void setCameraDrunk()
    {
        drunkCamera = true;
    }

    // Set Camera sober
    public void setCameraSober()
    {
        drunkCamera = false;
    }
}
