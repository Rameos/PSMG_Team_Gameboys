using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

    public Transform target;


    // Follow and always show the player in center of the map
    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
        }
    }
}
