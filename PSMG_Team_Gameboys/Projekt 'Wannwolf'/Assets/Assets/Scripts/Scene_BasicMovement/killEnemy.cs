using UnityEngine;
using System.Collections;

public class killEnemy : MonoBehaviour {

    private const int enemyHealth = 5;
    private const float interactionRadius = 3.0f;

    public int mouseButtonNum;

    public GameObject enemy;
    private GameObject player;

    private int hitNumber;

    void Awake()
    {
        player = gameObject;

        hitNumber = 0;
    }

    void Update()
    {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(player.transform.position, player.transform.forward * -1, out hit, interactionRadius) && Input.GetMouseButtonDown(mouseButtonNum))
        {
            hitNumber++;
        }

        destroyEnemy();
    }


    void destroyEnemy()
    {
        if (hitNumber == enemyHealth)
        {
            DestroyObject(enemy);
        }
    }
	
}
