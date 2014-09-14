﻿using UnityEngine;
using System.Collections;

public class ExtinguishFire : MonoBehaviour {

    private GameObject fireRadiusTrigger;
    private DrinkLogic drinkLogic;
    private PlayerControl control;
    private ParticleSystem urin;
    private CameraSwitcher switcher;

    private float width = 160;
    private float height = 30;
   
    private bool extinguishable;
    public bool startPeeing = false;
    
    void Awake()
    {
        switcher = gameObject.GetComponent<CameraSwitcher>();
        fireRadiusTrigger = GameObject.FindGameObjectWithTag(TagManager.FIRE_RADIUS_TRIGGER);
        control = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<PlayerControl>();
        extinguishable = true;
        drinkLogic = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<DrinkLogic>();
        extinguishable = true;
        urin = GameObject.FindGameObjectWithTag(TagManager.URINSTRAHL).GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.FIRE) == null)
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
            GameObject.FindGameObjectWithTag(TagManager.PLAYER).transform.position = GameObject.FindGameObjectWithTag(TagManager.PEEING_POSITION).transform.position;
            control.enabled = false;
            switcher.setCameraStatic();
            switcher.setFireTaskStatic(GameObject.FindGameObjectWithTag(TagManager.PLAYER));
            startPeeing = true;
            Destroy(gameObject);
        }
    }

    void OnGUI()
    {
        if (drinkLogic.inFireRadius && control.vodkaStatus)
        {
            GUI.Button(new Rect((Screen.width - (width * 2)) / 2, (float)(Screen.height * 0.2), width * 2, height), "Drücke \"F\" um das Feuer zu löschen");
            control.hadVodkaOnce = true;
        }

        if (drinkLogic.inFireRadius && drinkLogic.ableToUrinate)
        {
            GUI.Button(new Rect((Screen.width - (width * 2)) / 2, (float)(Screen.height * 0.2), width * 2, height), "Drücke \"E\" um das Feuer zu auszupinkeln");
        }
    }

    void OnTriggerExit(Collider other)
    {
       drinkLogic.inFireRadius = false;
       extinguishable = true;
    }
}
