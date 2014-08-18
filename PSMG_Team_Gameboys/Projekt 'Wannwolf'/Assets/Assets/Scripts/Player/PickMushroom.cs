using UnityEngine;
using System.Collections;

public class PickMushroom : MonoBehaviour {

    private const float livingtime = 15f;
    private const int mushroomValue = 5;

    private float passedTime;

    void Update ()
    {
        passedTime += Time.fixedDeltaTime;

        if (passedTime >= livingtime)
        {
            disappearMushroom();
        }
    }

    void OnTriggerEnter (Collider col)
    {
        if (col.tag == TagManager.PLAYER)
        {
            col.GetComponent<MoneyManagement>().addMoney(mushroomValue);
            disappearMushroom();
        }
    }

    void disappearMushroom()
    {
        Destroy(gameObject);
    }
}
