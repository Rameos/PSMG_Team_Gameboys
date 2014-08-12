using UnityEngine;
using System.Collections;

public class PlayerDie : MonoBehaviour {

    private Respawn respawn;  

    void Awake()
    {
        respawn = GameObject.FindGameObjectWithTag("GameController").GetComponent<Respawn>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == ("Player"))
        {
            respawn.dyingStatus = true;
        }
    }
}
