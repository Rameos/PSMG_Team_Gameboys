using UnityEngine;
using System.Collections;
[RequireComponent(typeof(MoneyManagement))]

public class BeerTrigger : MonoBehaviour {

	bool waitActive = false;
    private MoneyManagement money;
    int dieVal = 0;

    void Start()
    {
        money = GameObject.FindGameObjectWithTag("Player").GetComponent<MoneyManagement>();
    }

	void OnTriggerStay (Collider other) {
       

            if (Input.GetAxis("Run/Sneak") >= 0)
            {
                money.setCurrentMoney(dieVal);

            }

            if (Input.GetKeyDown("f"))
            {

                if (GameObject.FindGameObjectWithTag("Beer").transform.parent == null && !waitActive)
                {
                    Debug.Log("if");
					GameObject.FindGameObjectWithTag("Beer").transform.parent = GameObject.Find("pickto").transform;
					Destroy(GameObject.FindGameObjectWithTag("Beer").GetComponent("RotateObject"));
                    StartCoroutine(Wait());
                }
                else if (!waitActive)
                {
					GameObject.FindGameObjectWithTag("Beer").transform.parent = null;
					GameObject.FindGameObjectWithTag("Beer").AddComponent("RotateObject");
                    StartCoroutine(Wait());
                }
            }
            
        
      

        


	}
	IEnumerator Wait(){
		waitActive = true;
		yield return new WaitForSeconds (0.2f);
		waitActive = false;
	}


}
