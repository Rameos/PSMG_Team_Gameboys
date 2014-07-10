using UnityEngine;
using System.Collections;

public class ExtinguishFire : MonoBehaviour {

    private PlayerControl control;
    private GameObject player;
    private GameObject fire;
    private GameObject FireInvisibleWall;

    void Start()
    {
        player = GameObject.Find("Player");
        control = player.GetComponent<PlayerControl>();
        fire = GameObject.Find("Fire");
        FireInvisibleWall = GameObject.Find("FireInvisibleWall");
    }

    void OnTriggerEnter(Collider other)
    {
        print("Enter Fire Collider");
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("f"))
        {
            if (control.hasVodka)
            {
                


            } else
                if (control.hasWater)
                {
                    fire.renderer.enabled = false;
                    DestroyObject(FireInvisibleWall);
                    print("Kill Fire");
                }
        }
    }
}
