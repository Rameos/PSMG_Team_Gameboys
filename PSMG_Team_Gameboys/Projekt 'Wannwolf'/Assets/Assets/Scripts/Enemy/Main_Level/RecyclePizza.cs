using UnityEngine;
using System.Collections;

public class RecyclePizza : MonoBehaviour {

    private Vector3 pizzaStartPosition;
    private float moveSpeed;
    public Vector3 startPos;

   void Awake()
   {
       pizzaStartPosition = gameObject.transform.position;
       moveSpeed = 0.5f;
   }

    public void recycleEnemy()
    {        
        gameObject.transform.position = pizzaStartPosition;
        StartCoroutine(recyclePizza(15));
    }

    //moves the pizza out of the players sight and puts it back after 15 seconds
    IEnumerator recyclePizza(float seconds)
    {
            gameObject.transform.position = new Vector3(0, 0, 3000);
            yield return new WaitForSeconds(seconds);
            gameObject.transform.position = startPos;
    }
}
