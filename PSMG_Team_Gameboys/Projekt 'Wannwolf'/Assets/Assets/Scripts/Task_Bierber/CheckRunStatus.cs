using UnityEngine;
using System.Collections;

public class CheckRunStatus : MonoBehaviour {

    private const float waitingTime = 3f;
    private MoneyManagement money;
    private float beforeMoney;
    private int value;
    private bool sneaking;


    void Awake()
    {
        money = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<MoneyManagement>();
        beforeMoney = money.getCurrentMoney();
        sneaking = true;
    }

    void Update()
    {
        if (!sneaking)
        {
            if (money.getCurrentMoney() > beforeMoney / 2)
            {
                money.subtractMoney(1);
            }
        }
    }

	void OnTriggerStay (Collider col) 
    {
        if (col.tag == TagManager.PLAYER)
        {
            if (Input.GetAxis("Run/Sneak") >= 0 && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
            {
                sneaking = false;
            }
            else
            {
                sneaking = true;
                beforeMoney = money.getCurrentMoney();
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == TagManager.PLAYER)
        {
            sneaking = true;
        }
    }
}
	


