using UnityEngine;
using System.Collections;

public class DiePlayerDie : MonoBehaviour {

	void OnTriggerEnter(Collider col){
        if (col.tag == TagManager.PLAYER)
        {
            Respawn.respawn.dyingStatus = true;
        }
    }
}
