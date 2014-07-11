using UnityEngine;
using System.Collections;

public class RespawnPlayer : MonoBehaviour {

    void OnTriggerEnter(Collider col) 
    {
        if (col.gameObject.tag == "Enemy")
        {
            
        }
    }
}
