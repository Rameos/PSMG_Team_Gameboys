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
}
