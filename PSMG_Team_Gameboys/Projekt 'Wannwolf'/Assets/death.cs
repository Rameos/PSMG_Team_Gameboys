using UnityEngine;
using System.Collections;

public class death : MonoBehaviour {

    // Instance variables
    public Transform player;
    GameObject playerObject;
    MoneyManagement money;

    // Initialize objects/scripts
    void Awake()
    {
        playerObject = GameObject.Find("Player");
        money = playerObject.GetComponent<MoneyManagement>();
    }

    // Reaction on players death
    void OnTriggerEnter(Collider col)
    {        
        if (col.tag == "Player")
        {
            // Relocate player in front of canyon on death
            player.position = new Vector3(1149f, 105f, 375f);

            // Subtract money from the players account on death
            money.subtractMoney(15);
        }
    }
}
