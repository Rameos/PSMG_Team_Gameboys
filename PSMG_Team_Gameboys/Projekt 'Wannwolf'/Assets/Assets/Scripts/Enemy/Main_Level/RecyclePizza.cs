using UnityEngine;
using System.Collections;

public class RecyclePizza : MonoBehaviour {

    public GameObject pizza;
    private Vector3 pizzaStartPosition;
    private float moveSpeed; 

   void Awake()
   {
       pizzaStartPosition = pizza.transform.position;
       moveSpeed = 0.5f;
   }

    public void recycleEnemy()
    {        
        Debug.Log("inactive");

        pizza.transform.position = pizzaStartPosition;

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

    // Enemy returns to its original position
    void returnToOrigin()
    {
        pizza.transform.rotation = Quaternion.Slerp(pizza.transform.rotation,
        Quaternion.LookRotation(pizzaStartPosition - pizza.transform.position), 1f);
        pizza.transform.position += pizza.transform.forward * moveSpeed;
    }
}
