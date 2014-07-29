using UnityEngine;
using System.Collections;
[RequireComponent(typeof(MoneyManagement))]

public class BeerTrigger : MonoBehaviour {

	bool waitActive = false;
    private MoneyManagement money;
    int dieVal = 0;

    void Start()
    {
        money = GetComponent<MoneyManagement>();
    }

	void OnTriggerStay (Collider other) {
       

            if (Input.GetAxis("Run/Sneak") >= 0)
            {
                money.setCurrentMoney(dieVal);

            }

            if (Input.GetKeyDown("f"))
            {

                if (GameObject.Find("bier").transform.parent == null && !waitActive)
                {
                    Debug.Log("if");
                    GameObject.Find("bier").transform.parent = GameObject.Find("pickto").transform;
                    Destroy(GameObject.Find("bier").GetComponent("RotateObject"));
                    StartCoroutine(Wait());
                }
                else if (!waitActive)
                {
                    Debug.Log("else");
                    GameObject.Find("bier").transform.parent = null;
                    GameObject.Find("bier").AddComponent("RotateObject");
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
