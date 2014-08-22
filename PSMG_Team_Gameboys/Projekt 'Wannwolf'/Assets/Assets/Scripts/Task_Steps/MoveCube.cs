using UnityEngine;
using System.Collections;

[RequireComponent(typeof(DragByPlayer))]
public class MoveCube : MonoBehaviour {
    private DragByPlayer drag;

   

    void Start()
    {
        drag = GetComponent<DragByPlayer>();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == TagManager.PLAYER)
        {
        
                if (Input.GetKeyDown("f"))
                {
                    drag.follow(gameObject, false);
                }

        
        }


    }

    
  

}
