using UnityEngine;
using System.Collections;

public class PickTimeMachineReplacement : MonoBehaviour {

    private bool inTrigger;
    private float rotationSpeed;
    private GameObject mainCamera;
    private CameraControl cameraControl;
    private PlayerControl playerControl;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag(TagManager.MAIN_CAMERA);
        cameraControl = mainCamera.GetComponent<CameraControl>();
        playerControl = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<PlayerControl>();

        rotationSpeed = 6f;
        inTrigger = false;
    }

    void FixedUpdate()
    {
        rotateObject();
        riseObject();
    }

	void OnTriggerEnter(Collider col){
        if (col.tag == TagManager.PLAYER)
        {
            cameraControl.enabled = false;
            playerControl.enabled = false;
            inTrigger = true;
        }
    }

    IEnumerator stop()
    {
        yield return new WaitForSeconds(3f);
        inTrigger = false;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        cameraControl.enabled = true;
        playerControl.enabled = true;
    }

    void rotateObject()
    {
        gameObject.transform.Rotate(new Vector3(0, 1, 0), rotationSpeed);
        if (inTrigger)
        {
            rotationSpeed += Time.deltaTime * 15;
        }
    }

    void riseObject()
    {
        if (inTrigger)
        {
            mainCamera.transform.LookAt(gameObject.transform);
            gameObject.transform.position += new Vector3(0f, Time.deltaTime * 5, 0f);
            StartCoroutine(stop());
        }
    }
}
