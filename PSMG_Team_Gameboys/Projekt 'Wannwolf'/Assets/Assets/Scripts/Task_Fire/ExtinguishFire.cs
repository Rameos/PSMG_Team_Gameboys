using UnityEngine;
using System.Collections;

public class ExtinguishFire : MonoBehaviour {

    private PlayerControl control;
    private GameObject player;
    private GameObject fire;
    private GameObject fireInvisibleWall;
    private DrinkLogic drinkLogic;

    void Start()
    {
        player = GameObject.Find("Player");
        control = player.GetComponent<PlayerControl>();
        fire = GameObject.Find("Fire");
        fireInvisibleWall = GameObject.Find("FireInvisibleWall");
        drinkLogic = GameObject.FindGameObjectWithTag("Player").GetComponent<DrinkLogic>();
    }

    void OnTriggerEnter(Collider other)
    {
        drinkLogic.inFireRadius = true;
        print("Enter Fire Collider");
    }

    void OnTriggerStay(Collider other)
    {
        if (drinkLogic.vodkaEmptied)
        {
            fire.particleEmitter.emitterVelocityScale *= 3f;
        }

        if (drinkLogic.urinating)
        {
            DestroyObject(fire);
            DestroyObject(fireInvisibleWall);
        }
    }

    void OnTriggerExit(Collider other)
    {
        drinkLogic.inFireRadius = false;
    }
}
