using UnityEngine;
using System.Collections;

public class BuyBeverage : MonoBehaviour {

    private GameObject player;
    private PlayerControl control;

    void Start()
    {
        player = GameObject.Find("Player");
        control = player.GetComponent<PlayerControl>();
    }

    void OnTriggerEnter(Collider other)
    {
        print("Pilzeria Trigger entered");
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("v"))
        {
            print("Bought Vodka");
            control.hasVodka = true;
            control.hasWater = false;
            print("hasVodka " + control.hasVodka);
        }

        if (Input.GetKeyDown("f"))
        {
            print("Bought Water");
            control.hasWater = true;
            control.hasVodka = false;
            print("hasWater: " + control.hasWater);
            
        }
    }
}
