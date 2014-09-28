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
        mainCamera.transform.localPosition = gameObject.transform.localPosition + new Vector3(0,5f,-8f);
        mainCamera.transform.LookAt(gameObject.transform);
        GameObject.FindGameObjectWithTag(TagManager.PLAYER).transform.position = gameObject.transform.localPosition - new Vector3(0, 0, 7f);
        gameObject.transform.LookAt(mainCamera.transform);
    }

    public void setFireTaskStatic(GameObject gameObject)
    {
        mainCamera.transform.position = gameObject.transform.position + new Vector3(11, 3, -18);
        setCameraFocus(gameObject);
    }

    public void setVomitStatic()
    {
        setCameraStatic();
        mainCamera.transform.rotation = Quaternion.Euler(0, 180, 0);
        mainCamera.transform.position = mainCamera.transform.rotation * new Vector3(0, 0, -10) + GameObject.FindGameObjectWithTag(TagManager.PLAYER).transform.position;
        mainCamera.transform.LookAt(GameObject.FindGameObjectWithTag(TagManager.PLAYER).transform);
    }
}
