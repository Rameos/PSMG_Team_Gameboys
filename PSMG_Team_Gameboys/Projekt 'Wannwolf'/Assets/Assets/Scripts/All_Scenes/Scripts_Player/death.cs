﻿using UnityEngine;
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
            // Subtract money from the players account on death
            money.subtractMoney(15);

            // Decide where to relocate the player to after death
            int curMoney = money.getCurrentMoney();
            int moneyMinimum = money.getMoneyMinimum();
            int moneyMaximum = money.getMoneyMaximum();

            if (curMoney > moneyMinimum)
            {
                // a) Relocate player in front of canyon on death
                player.position = new Vector3(1149f, 105f, 375f);
            }
            else
            {
                // b) Relocate player at the begin of the level if no money is left
                player.position = new Vector3(96f, 107f, 101f);
                money.setCurrentMoney(moneyMaximum);
            }


            
        }
    }
}
