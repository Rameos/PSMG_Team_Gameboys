﻿using UnityEngine;
using System.Collections;

public class BurnPlayer : MonoBehaviour {

    private ParticleSystem playerFlames;
    private MoneyManagement moneyManagment;


    private int beforeBurningMoney;
    private bool isBurning;

    void Awake()
    {
        isBurning = false;
    }

    void Start()
    {
        playerFlames = GameObject.FindGameObjectWithTag(TagManager.PLAYER_FLAMES).GetComponent<ParticleSystem>();
        moneyManagment = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<MoneyManagement>();

        beforeBurningMoney = moneyManagment.getCurrentMoney();
    }

    void Update()
    {
        if (isBurning)
        {
            if (moneyManagment.getCurrentMoney() > (beforeBurningMoney+1) / 2)
            {
                moneyManagment.subtractMoney(1);
            }
        }

    }

    void OnTriggerEnter()
    {
        isBurning = true;
        playerFlames.Play(true);
        StartCoroutine(Wait());
    }

    void OnTriggerStay()
    {
        isBurning = true;
        playerFlames.Play(true);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        isBurning = false;
        playerFlames.Stop(true);
        beforeBurningMoney = moneyManagment.getCurrentMoney();
    }
}
