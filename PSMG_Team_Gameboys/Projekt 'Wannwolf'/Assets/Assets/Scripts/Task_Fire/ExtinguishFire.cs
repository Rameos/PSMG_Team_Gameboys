using UnityEngine;
using System.Collections;

public class ExtinguishFire : MonoBehaviour {

<<<<<<< HEAD
    private GameObject fire;
    private GameObject fireInvisibleWall;
    private DrinkLogic drinkLogic;
    private MoneyManagement moneyManagement;
    private PlayerControl control;
=======
    private DrinkLogic drinkLogic;
    private PlayerControl control;
    private ParticleSystem urin;
>>>>>>> origin/Drunk-Player
    private bool extinguishable;
    
    void Start()
    {
        control = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
<<<<<<< HEAD
        fire = GameObject.Find("Fire");
        fireInvisibleWall = GameObject.Find("FireInvisibleWall");
        drinkLogic = GameObject.FindGameObjectWithTag("Player").GetComponent<DrinkLogic>();
        moneyManagement = GameObject.FindGameObjectWithTag("Player").GetComponent<MoneyManagement>();
        extinguishable = true;
=======
        drinkLogic = GameObject.FindGameObjectWithTag("Player").GetComponent<DrinkLogic>();
        extinguishable = true;
        urin = GameObject.FindGameObjectWithTag("Urinstrahl").GetComponent<ParticleSystem>();
>>>>>>> origin/Drunk-Player
    }

    void OnTriggerEnter(Collider other)
    {
        drinkLogic.inFireRadius = true;
        print("Enter Fire Collider");
    }

    void OnTriggerStay(Collider other)
    {
        if (drinkLogic.vodkaEmptied && extinguishable)
<<<<<<< HEAD
        {
            moneyManagement.subtractMoney(10);
            drinkLogic.vodkaEmptied = false;
            extinguishable = false;
=======
        {
            drinkLogic.diedInFire = true;
            drinkLogic.vodkaEmptied = false;
            extinguishable = false;
        }

        if (drinkLogic.ableToUrinate && Input.GetKeyDown(KeyCode.E))
        {
            urin.particleSystem.Play(true);    
>>>>>>> origin/Drunk-Player
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

    void OnGUI()
    {
        if (drinkLogic.inFireRadius && control.vodkaStatus)
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
