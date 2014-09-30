using UnityEngine;
using System.Collections;

public class PickLastReplacement : MonoBehaviour
{

    private bool inTrigger;
    private float rotationSpeed;
    private GameObject mainCamera;
    private GameObject player;
    private Camera_Escape cameraControl;
    private ReplacementHUDLogic hudLogic;
    private PLayerMovement playerMovement;
    private AutomaticMovement playerAutomaticMovement;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
        mainCamera = GameObject.FindGameObjectWithTag(TagManager.MAIN_CAMERA);
        cameraControl = mainCamera.GetComponent<Camera_Escape>();
        hudLogic = GameObject.FindGameObjectWithTag(TagManager.GAME_CONTROLLER).GetComponent<ReplacementHUDLogic>();
        playerMovement = player.GetComponent<PLayerMovement>();
        playerAutomaticMovement = player.GetComponent<AutomaticMovement>();

        rotationSpeed = 6f;
        inTrigger = false;
    }

    void FixedUpdate()
    {
        rotateObject();
        riseObject();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == TagManager.PLAYER)
        {
            cameraControl.enabled = false;
            playerMovement.enabled = false;
            playerAutomaticMovement.enabled = false;
            hudLogic.hasPieces++;
            inTrigger = true;
        }
    }

    IEnumerator stop()
    {
        yield return new WaitForSeconds(3f);
        inTrigger = false;
        yield return new WaitForSeconds(1f);
        LoadScene.loadScene();
    }

    void rotateObject()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, 1), rotationSpeed);
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
