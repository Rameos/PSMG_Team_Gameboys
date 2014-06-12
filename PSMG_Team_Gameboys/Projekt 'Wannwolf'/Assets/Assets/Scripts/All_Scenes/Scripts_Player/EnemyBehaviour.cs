using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public Transform player;
    public Transform thisEnemy;

    private GameObject playerObject;

    private Vector3 enemyStartPosition;
    private float followSpeed;
    private float attackSpeed;
    private float sightRadius;
    private float followingRadius;
    private float currentAttentionRadius;

    private float distancePlayerEnemy;

    private bool playerFollowed;
    private bool currentlyAttacking;

    // Money Management Instance Variables
    private MoneyManagement money;
    private float subtractTime = 3f;
    private float subtractRate = 5f;
    private bool enemySeen = false;

	// Initializing Instance Variables
	void Start () {
        enemyStartPosition = thisEnemy.position; // Store enemy's original position
        sightRadius = 30f;
        followingRadius = 60f;
        currentAttentionRadius = sightRadius;
        followSpeed = 0.25f;
        attackSpeed = 0.5f;
        playerFollowed = false;
        currentlyAttacking = false;

        playerObject = GameObject.Find("Player");
        money = playerObject.GetComponent<MoneyManagement>();
	}

    void LateUpdate()
    {
        if (playerFollowed && Vector3.Distance(player.position, thisEnemy.position) <= currentAttentionRadius)
        {
            // Enemy slowly follows the player
            if (Vector3.Distance(player.position, thisEnemy.position) >= 30f)
            {
                thisEnemy.rotation = Quaternion.LookRotation(player.position - thisEnemy.position);
                thisEnemy.position += thisEnemy.TransformDirection(Vector3.forward * followSpeed);
            }
            // Enemy becomes faster
            else
            {
                thisEnemy.rotation = Quaternion.LookRotation(player.position - thisEnemy.position);
                thisEnemy.position += thisEnemy.TransformDirection(Vector3.forward * attackSpeed);
            }
        }
        else
        {
            playerFollowed = false;
            currentAttentionRadius = sightRadius;

            // Enemy returns to its original position 
            if (enemySeen)
            {
                returnToOrigin();
            }            
        }
    }
    
    // When Player enters the Box Collider
    void OnTriggerEnter(Collider col)
    {
        print("Trigger entered");
        currentlyAttacking = true;
        if (col.gameObject.tag == "Player")
        {
            playerFollowed = true;
            currentAttentionRadius = followingRadius;
            enemySeen = true;
        }
        if (currentlyAttacking)
        {
            InvokeRepeating("attackPlayer", 1.5f, 3.5f);
        }
    }

    void OnTriggerExit()
    {
        print("Trigger exited");
        currentlyAttacking = false;
        CancelInvoke();
    }

    // Enemy returns to its original position
    void returnToOrigin()
    {
        thisEnemy.rotation = Quaternion.Slerp(thisEnemy.rotation,
        Quaternion.LookRotation(enemyStartPosition - thisEnemy.position), 1f);
        thisEnemy.position += thisEnemy.forward * attackSpeed;
    }

    // Attack the Player while in range
    void attackPlayer()
    {
        print("coroutine started: " + currentlyAttacking);
        if (currentlyAttacking)
        {
            money.subtractMoney(3);
        }
    }

    /*
    void OnTriggerStay()
    {
        if (Vector3.Distance(target.position, enemy.transform.position) <= currentAttentionRadius) 
        {
            enemy.transform.rotation = Quaternion.LookRotation(target.position - enemy.transform.position);
            enemy.transform.position += enemy.transform.TransformDirection(Vector3.forward * speed);
        }
    }
    */
}
