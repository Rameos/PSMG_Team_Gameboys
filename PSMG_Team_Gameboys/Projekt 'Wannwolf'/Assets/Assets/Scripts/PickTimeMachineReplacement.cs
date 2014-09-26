using UnityEngine;
using System.Collections;

public class PickTimeMachineReplacement : MonoBehaviour {

    private bool inTrigger;
    private float rotationSpeed;
    private GameObject mainCamera;
    private CameraControl cameraControl;
    private PlayerControl playerControl;

	public Texture2D lenker;
	public Texture2D rad;
	public Texture2D turbine;

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
		updateHUD(playerControl.hasPieces); // use "hasPieces instance variable of the player to check, which ersatzteil has already been picked up
    }

	void OnTriggerEnter(Collider col){
        if (col.tag == TagManager.PLAYER)
        {
            cameraControl.enabled = false;
            playerControl.enabled = false;
            playerControl.hasPieces++;
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

    // Display the picked ersatzteil with 100% opacity insted of 50%
	void updateHUD(int counter){
		switch (counter) {
			case 1:
				GameObject.FindGameObjectWithTag("Lenker").GetComponent<GUITexture>().texture = lenker;
				break;		
			case 2:
				GameObject.FindGameObjectWithTag("Rad").GetComponent<GUITexture>().texture = rad;
				break;		
			case 3:
				GameObject.FindGameObjectWithTag("Turbine").GetComponent<GUITexture>().texture = turbine;
				break;
		}
	}
}
