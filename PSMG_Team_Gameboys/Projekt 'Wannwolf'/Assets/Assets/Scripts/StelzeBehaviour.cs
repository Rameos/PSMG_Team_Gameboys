using UnityEngine;
using System.Collections;

public class StelzeBehaviour : MonoBehaviour {

    void OnTriggerStay(Collider col)
    {
        if(col.tag == TagManager.PLAYER){
            gameObject.transform.position += new Vector3(0f, - Time.deltaTime * 3, 0f);  
        }
    }
}
