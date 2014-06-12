using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour {

    private const int maxHealth = 5;
    private int curHealth;
  
    private const float interactionRadius = 8.0f;

    public int mouseButtonNum;

    public Transform enemy;
    public Transform player;

    private int hitNumber;

    MoneyManagement money;

    void Awake()
    {
        money = player.gameObject.GetComponent<MoneyManagement>();
        curHealth = maxHealth;
        updateGUIText(curHealth);

        hitNumber = 0;
    }

    void Update()
    {
        RaycastHit hit = new RaycastHit();
        if (Vector3.Distance(player.position, enemy.position) <= interactionRadius && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R pressed");
            hitNumber++;
            curHealth--;
            updateGUIText(curHealth);
            Debug.Log("HitNum: " + hitNumber + ", curHealth: " + curHealth);
        }

        destroyEnemy();
    }


    void destroyEnemy()
    {
        if (curHealth == 0)
        {
            DestroyObject(enemy.gameObject);
            money.addMoney(15);
        }
    }

    void updateGUIText(int health)
    {
        //enemyHealthText.text = health.ToString();
    }
	
}

//Physics.Raycast(player.transform.position, player.transform.forward * -1, out hit, interactionRadius) &&