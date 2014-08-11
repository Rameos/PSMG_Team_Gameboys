using UnityEngine;
using System.Collections;
[RequireComponent(typeof(MoneyManagement))]
[RequireComponent(typeof(DragByPlayer))]
[RequireComponent(typeof(HintDialogue))]


public class BeerTrigger : MonoBehaviour {

    private MoneyManagement money;
    int dieVal = 0;
    private DragByPlayer drag;
	private HintDialogue hint;



    void Start()
    {
        money = GameObject.FindGameObjectWithTag("Player").GetComponent<MoneyManagement>();
        drag = GetComponent<DragByPlayer>();
		hint = GetComponent<HintDialogue>();

    }

	void OnTriggerStay (Collider other) {
       

            if (Input.GetAxis("Run/Sneak") >= 0)
            {
                money.setCurrentMoney(dieVal);

            }

            if (Input.GetKeyDown("f"))
            {
                hint.playNorbertBeerHint();
                drag.follow(gameObject, true);
            }
            
       
            }
	}
	


