using UnityEngine;
using System.Collections;

public class PlayerDie : MonoBehaviour {

    private Respawn respawn;  

    void Awake()
    {
        respawn = GameObject.FindGameObjectWithTag(TagManager.GAME_CONTROLLER).GetComponent<Respawn>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == (TagManager.PLAYER))
        {
            respawn.dyingStatus = true;
        }
    }
}
