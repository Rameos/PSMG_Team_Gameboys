using UnityEngine;
using System.Collections;
[RequireComponent(typeof(MoneyManagement))]
[RequireComponent(typeof(DragByPlayer))]


public class BeerTrigger : MonoBehaviour {

    private MoneyManagement money;
    int dieVal = 0;
    private DragByPlayer drag;


    void Start()
    {
        money = GameObject.FindGameObjectWithTag("Player").GetComponent<MoneyManagement>();
        drag = GetComponent<DragByPlayer>();
    }

	void OnTriggerStay (Collider other) {
       

            if (Input.GetAxis("Run/Sneak") >= 0)
            {
                money.setCurrentMoney(dieVal);

            }

            if (Input.GetKeyDown("f"))
            {
                drag.follow(gameObject, true);
               
            }
	}
	

}
