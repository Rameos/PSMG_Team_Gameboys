using UnityEngine;
using System.Collections;

public class StelzeBehaviour : MonoBehaviour {

    private PlayerControl playerControl;

    void Start()
    {
        playerControl = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<PlayerControl>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == TagManager.PLAYER)
        {
            playerControl.stelzePosition = gameObject.transform.parent.position;
            playerControl.onStelze = true;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if(col.tag == TagManager.PLAYER){
            gameObject.transform.position += new Vector3(0f, - Time.deltaTime * 3, 0f);  
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == TagManager.PLAYER)
        {
            playerControl.onStelze = false;
        }
    }
}
