using UnityEngine;
using System.Collections;

public class RecyclePizza : MonoBehaviour {

    //public GameObject[] pizza;
    private Vector3 pizzaStartPosition;
    private float moveSpeed; 

   void Awake()
   {
       //pizza = GameObject.FindGameObjectsWithTag("Pizza");
       pizzaStartPosition = gameObject.transform.position;
       moveSpeed = 0.5f;
   }

    public void recycleEnemy()
    {        
        Debug.Log("inactive");

        gameObject.transform.position = pizzaStartPosition;

        StartCoroutine(recyclePizza(15));
    }

    IEnumerator recyclePizza(float seconds)
    {
  
            gameObject.transform.position = new Vector3(0, 0, 300);
            //pizza.SetActive(false);
            //pizza[i].renderer.enabled = false;
            //gameObject.collider.enabled = false;
            yield return new WaitForSeconds(seconds);
            Debug.Log("recycle");
            //pizza[i].renderer.enabled = true;
            //gameObject.collider.enabled = true;
            //pizza.SetActive(true);
            gameObject.transform.position = pizzaStartPosition;
        
            

    }

    // Enemy returns to its original position
    void returnToOrigin()
    {
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation,
        Quaternion.LookRotation(pizzaStartPosition - gameObject.transform.position), 1f);
        gameObject.transform.position += gameObject.transform.forward * moveSpeed;
    }
}
