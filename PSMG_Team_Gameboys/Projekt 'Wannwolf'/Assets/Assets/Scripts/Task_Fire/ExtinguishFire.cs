using UnityEngine;
using System.Collections;

public class ExtinguishFire : MonoBehaviour {

    private GameObject fireRadiusTrigger;
    private DrinkLogic drinkLogic;
    private PlayerControl control;
    private ParticleSystem urin;
    private bool extinguishable;
    
    void Awake()
    {
        fireRadiusTrigger = GameObject.FindGameObjectWithTag("FireRadiusTrigger");
        control = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        drinkLogic = GameObject.FindGameObjectWithTag("Player").GetComponent<DrinkLogic>();
        extinguishable = true;
        drinkLogic = GameObject.FindGameObjectWithTag("Player").GetComponent<DrinkLogic>();
        extinguishable = true;
        urin = GameObject.FindGameObjectWithTag("Urinstrahl").GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Fire") == null)
        {
            GameObject.Destroy(fireRadiusTrigger);
        }
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
            drinkLogic.diedInFire = true;
            drinkLogic.vodkaEmptied = false;
            extinguishable = false;
        }

        if (drinkLogic.ableToUrinate && Input.GetKeyDown(KeyCode.E))
        {
            urin.particleSystem.Play(true);    
        }
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
