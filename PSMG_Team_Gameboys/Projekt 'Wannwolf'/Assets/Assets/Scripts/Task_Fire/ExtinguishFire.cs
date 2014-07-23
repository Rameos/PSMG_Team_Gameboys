using UnityEngine;
using System.Collections;

public class ExtinguishFire : MonoBehaviour {

    private GameObject fire;
    private GameObject fireInvisibleWall;
    private DrinkLogic drinkLogic;
    private MoneyManagement moneyManagement;
    private PlayerControl control;
    private bool extinguishable;
    
    void Start()
    {
        control = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        fire = GameObject.Find("Fire");
        fireInvisibleWall = GameObject.Find("FireInvisibleWall");
        drinkLogic = GameObject.FindGameObjectWithTag("Player").GetComponent<DrinkLogic>();
        moneyManagement = GameObject.FindGameObjectWithTag("Player").GetComponent<MoneyManagement>();
        extinguishable = true;
    }

    void OnTriggerEnter(Collider other)
    {
        drinkLogic.inFireRadius = true;
        print("Enter Fire Collider");
    }

    void OnTriggerStay(Collider other)
    {
        if (drinkLogic.vodkaEmptied && extinguishable)
        {
            moneyManagement.subtractMoney(10);
            drinkLogic.vodkaEmptied = false;
            extinguishable = false;
        }

        if (drinkLogic.ableToUrinate && Input.GetKeyDown(KeyCode.E))
        {
            DestroyObject(fire);
            DestroyObject(fireInvisibleWall);
            drinkLogic.ableToUrinate = false;
        }
    }

    void OnGUI()
    {
        if (drinkLogic.inFireRadius && control.hasVodka)
        {
            GUI.Button(new Rect(Screen.width-(Screen.width/6), 0, Screen.width / 5 , Screen.height / 8), "Drücke \"F\" um das Feuer zu löschen");
        }

        if (drinkLogic.inFireRadius && drinkLogic.ableToUrinate)
        {
            GUI.Button(new Rect(Screen.width - (Screen.width / 6), 0, Screen.width / 5, Screen.height / 8), "Drücke \"E\" um das Feuer zu auszupinkeln");
        }
    }

    void OnTriggerExit(Collider other)
    {
       drinkLogic.inFireRadius = false;
       extinguishable = true;
    }
}
