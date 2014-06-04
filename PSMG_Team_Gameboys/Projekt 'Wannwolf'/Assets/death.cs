using UnityEngine;
using System.Collections;

public class death : MonoBehaviour {

    public Transform player;

    void OnTriggerEnter(Collider col)
    {        
        if (col.tag == "Player")
        {
            player.position = new Vector3(1149f, 105f, 375f);
        }
    }
}
