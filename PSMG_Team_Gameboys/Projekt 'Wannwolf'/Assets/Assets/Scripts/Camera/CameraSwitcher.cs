using UnityEngine;
using System.Collections;

public class CameraSwitcher : MonoBehaviour {

    private GameObject mainCamera;

	// Use this for initialization
	void Start () {
        mainCamera = GameObject.FindGameObjectWithTag(TagManager.MAIN_CAMERA);
	}

    public void setCameraStatic()
    {
        mainCamera.GetComponent<CameraControl>().enabled = false;
    } 

    public void setCameraDynamic()
    {
        mainCamera.GetComponent<CameraControl>().enabled = true;
    }

    public void setCameraFocus(GameObject gameObject)
    {
        mainCamera.transform.LookAt(gameObject.transform);
    }

    public void setFireTaskStatic(GameObject gameObject)
    {
        //mainCamera.transform.position = gameObject.transform.position - new Vector3(-15, -5, 20);
        //setCameraFocus(gameObject);
        mainCamera.transform.position = gameObject.transform.position + new Vector3(0,10,0);
        mainCamera.transform.rotation = gameObject.transform.rotation;
    }
}
