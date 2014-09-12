using UnityEngine;
using System.Collections;

public class Camera_Escape : MonoBehaviour {

    public Transform player;

    private GameObject escapeCamera;
    private AutomaticMovement automaticMovementPlayer;

    private const float distance = 40;
    private const float height = 15;
    private const float speed = 0.6f;
        
	// Use this for initialization
	void Awake () {
        escapeCamera = gameObject;
        automaticMovementPlayer = player.GetComponent<AutomaticMovement>();
        StartCoroutine(wait());
    }
    
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.8f);
    }

    void Start()
    {
        escapeCamera.transform.position = new Vector3(distance, height, 0f) + player.position;
    }
	
	// Update is called once per frame
	void  FixedUpdate () {
        if (!automaticMovementPlayer.getStopStatus)
        {
            escapeCamera.transform.position += new Vector3(1f, 0f, 0f) * speed;
            escapeCamera.transform.LookAt(player);
        }	
    }
}
