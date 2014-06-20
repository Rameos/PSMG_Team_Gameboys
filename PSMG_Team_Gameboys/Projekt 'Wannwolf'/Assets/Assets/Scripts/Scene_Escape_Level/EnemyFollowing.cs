using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class EnemyFollowing : MonoBehaviour {

    public Transform player;

    private CharacterController characterController;
    private GameObject emptyLeft;
    private GameObject emptyRight;
    private GameObject emptyNearLeft;
    private GameObject emptyNearRight;

    private float speed;

    void Awake()
    {
        speed = 0.3f;

        characterController = GetComponent<CharacterController>();
        emptyLeft = GameObject.FindGameObjectWithTag("EnemyEmptyLeft");
        emptyRight = GameObject.FindGameObjectWithTag("EnemyEmptyRight");
        emptyNearLeft = GameObject.FindGameObjectWithTag("EnemyEmptyNearLeft");
        emptyNearRight = GameObject.FindGameObjectWithTag("EnemyEmptyNearRight");
    }

    /*void OnStart()
    {
        characterController.transform.LookAt(player.position);
        emptyLeft.transform.rotation = characterController.transform.rotation;
        emptyRight.transform.rotation = characterController.transform.rotation;
    }*/
	
	// Update is called once per frame
	void Update () {
        characterController.transform.rotation = Quaternion.LookRotation(player.position - characterController.transform.position);
        characterController.Move(characterController.transform.TransformDirection(Vector3.forward * speed));
        getBarriers();
	}

    void getBarriers()
    {
        RaycastHit hit = new RaycastHit();
        float distance = 5f;

            if (Physics.Raycast(emptyNearRight.transform.position, emptyNearRight.transform.forward, out hit, distance) && Physics.Raycast(emptyNearLeft.transform.position, emptyNearLeft.transform.forward, out hit, distance))
            {
                if (Physics.Raycast(emptyRight.transform.position, emptyRight.transform.forward, out hit, distance))
                {
                    characterController.Move(characterController.transform.TransformDirection(Vector3.left * speed));
                }
                else{
                    if((Physics.Raycast(emptyLeft.transform.position, emptyLeft.transform.forward, out hit, distance))){
                        characterController.Move(characterController.transform.TransformDirection(Vector3.right * speed));
                    }
                }
            }
            /*else
            {
                if (Physics.Raycast(emptyNearRight.transform.position, emptyNearRight.transform.forward, out hit, distance))
                {
                    characterController.Move(characterController.transform.TransformDirection(Vector3.left * speed));
                }else{
                    if(Physics.Raycast(emptyNearLeft.transform.position, emptyNearLeft.transform.forward, out hit, distance))
                    {
                        characterController.Move(characterController.transform.TransformDirection(Vector3.right * speed));
                    }
                }
            }*/
    }
}

