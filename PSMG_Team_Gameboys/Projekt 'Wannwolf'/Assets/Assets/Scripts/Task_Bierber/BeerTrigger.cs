using UnityEngine;
using System.Collections;
[RequireComponent(typeof(MoneyManagement))]
[RequireComponent(typeof(DragByPlayer))]
[RequireComponent(typeof(HintDialogue))]


public class BeerTrigger : MonoBehaviour {

    private MoneyManagement money;
    private double currentVal;
    private int value;
    private DragByPlayer drag;
	private HintDialogue hint;



    void Start()
    {
        money = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<MoneyManagement>();
        drag = GetComponent<DragByPlayer>();
		hint = GameObject.FindGameObjectWithTag(TagManager.ANGLER_ARRIVAL_HINT).GetComponent<HintDialogue>();

    }

	void OnTriggerStay (Collider other) {
       

            if (Input.GetAxis("Run/Sneak") >= 0)
            {
                currentVal = money.getCurrentMoney();
                currentVal *= 0.7;
                value = (int)currentVal;
                money.setCurrentMoney(value);

            }

            if (Input.GetKeyDown("f"))
            {
                hint.playNorbertBeerHint();
                drag.follow(gameObject, true);
            }
            
       
            }
	}
	


