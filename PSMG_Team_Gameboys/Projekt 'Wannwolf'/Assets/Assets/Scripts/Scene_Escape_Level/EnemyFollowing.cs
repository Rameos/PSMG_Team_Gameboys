using UnityEngine;
using System.Collections;

public class EnemyFollowing : MonoBehaviour {

    public Transform player;

    private GameObject enemy;
    private float speed;

    void Awake()
    {
        enemy = gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        enemy.transform.rotation = Quaternion.LookRotation(player.position - enemy.transform.position);
        enemy.transform.position += enemy.transform.TransformDirection(Vector3.forward * 0.2f);
	}
}
