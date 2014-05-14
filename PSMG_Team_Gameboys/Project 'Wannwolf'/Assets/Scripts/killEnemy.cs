using UnityEngine;
using System.Collections;

public class killEnemy : MonoBehaviour {

    private GameObject enemy;

    private int hitNumber;

    void Awake()
    {
        enemy = gameObject;

        hitNumber = 0;
    }

	void OnTriggerStay(Collider Cube){
		if (Input.GetAxis("Slap") == 1) {
            hitNumber++;
		}
        destroyEnemy();
	}

    void destroyEnemy()
    {
        if (hitNumber == 5)
        {
            DestroyObject(enemy);
        }
    }
}
