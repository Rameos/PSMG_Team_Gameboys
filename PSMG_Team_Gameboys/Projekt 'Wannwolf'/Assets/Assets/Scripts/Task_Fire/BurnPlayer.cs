using UnityEngine;
using System.Collections;

public class BurnPlayer : MonoBehaviour {

    private Respawn respawn;
    private ParticleSystem playerFlames;
    private MoneyManagement moneyManagment;


    private int beforeBurningMoney;
    private bool isBurning;

    void Awake()
    {
        respawn = GameObject.FindGameObjectWithTag("Fire").GetComponent<Respawn>();
        playerFlames = GameObject.FindGameObjectWithTag("PlayerFlames").GetComponent<ParticleSystem>();
        moneyManagment = GameObject.FindGameObjectWithTag("Player").GetComponent<MoneyManagement>();

        isBurning = false;
    }

    void Start()
    {
        respawn.enabled = false;
        beforeBurningMoney = moneyManagment.getCurrentMoney();
    }

    void FixedUpdate()
    {
        if (isBurning)
        {
            if (moneyManagment.getCurrentMoney() > beforeBurningMoney / 2)
            {
                moneyManagment.subtractMoney(1);
            }
        }

    }

    void OnTriggerEnter()
    {
        isBurning = true;
        playerFlames.Play(true);
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        isBurning = false;
        playerFlames.Stop(true);
        respawn.enabled = true;
    }
}
