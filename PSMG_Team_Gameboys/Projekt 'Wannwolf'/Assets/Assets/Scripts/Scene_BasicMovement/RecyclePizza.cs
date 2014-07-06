using UnityEngine;
using System.Collections;

public class RecyclePizza : MonoBehaviour {

   // public GameObject pizza;

	// Use this for initialization
	void Start () {
       
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void recycleEnemy()
    {
        
        Debug.Log("inactive");
        StartCoroutine(recyclePizza(15));

    }

    IEnumerator recyclePizza(float seconds)
    {
        //pizza.SetActive(false);
        renderer.enabled = false;
        collider.enabled = false;
        yield return new WaitForSeconds(seconds);
        Debug.Log("recycle");
        renderer.enabled = true;
        collider.enabled = true;
        //pizza.SetActive(true);

    }
}
