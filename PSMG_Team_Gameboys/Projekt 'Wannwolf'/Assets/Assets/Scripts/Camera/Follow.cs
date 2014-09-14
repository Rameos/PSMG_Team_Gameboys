using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

    public Transform target;


	// Set the minimap on start of the game for the very first time (same as in LateUpdate)
    void Awake()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
            Quaternion correctRotation = target.rotation;
            correctRotation *= Quaternion.Euler(90, 0, 0);
            transform.rotation = correctRotation;            
        }
    }


    // Follow and always show the player in center of the map
    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
            Quaternion correctRotation = target.rotation;
            correctRotation *= Quaternion.Euler(90, 0, 0);
            transform.rotation = correctRotation;            
        }
    }
}
