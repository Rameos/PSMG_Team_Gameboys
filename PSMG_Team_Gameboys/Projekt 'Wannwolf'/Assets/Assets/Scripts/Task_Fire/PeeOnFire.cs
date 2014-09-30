using UnityEngine;
using System.Collections;
using iViewX;

public class PeeOnFire : MonoBehaviourWithGazeComponent
{

    private bool peeing = false;
    private ParticleSystem[] fire;
    private GameObject player;
    private float rotation;
    private ExtinguishFire exFire;
    private bool isPeeing;
    public AudioClip PeeSound;

	void Awake () {
    exFire = GameObject.FindGameObjectWithTag(TagManager.FIRE_RADIUS_TRIGGER).GetComponent<ExtinguishFire>();
    fire = gameObject.GetComponentsInChildren<ParticleSystem>();
    player = GameObject.FindGameObjectWithTag("Player");
    audio.clip = PeeSound;
    isPeeing = false;
	}
	

	void Update () {
        shrinkFire();
        growFire();
	}

    //while the player is looking at the fire, it constantly shrinks until it completely disappears
    void shrinkFire()
    {
        if (peeing && exFire.startPeeing)
        {
            if (!isPeeing)
            {
                audio.Play();
                isPeeing = true;
            }
            if (fire[0].startLifetime <= 0.1)
            {
                GameObject.FindGameObjectWithTag(TagManager.PLAYER_FLAMES).GetComponent<ParticleSystem>().Stop();
                GameObject.Destroy(gameObject);
            }
            else
            {
                if (fire[0].startLifetime > 2.5f)
                {
                    setFireHeight(Time.deltaTime * 3);
                }
                else setFireHeight(Time.deltaTime * 0.7f);
            }
        }
    }

    void setFireHeight(float shrinkFactor)
    {
       for (int i = 0; i < fire.Length; i++)
        {
            fire[i].startLifetime -= shrinkFactor;
        }
    }


    //if the player stopped extinguishing the fire before it is completely gone, the fire grows back to its original size
    void growFire()
    {
        if (!peeing)
        {
            
            if (fire[0].startLifetime < 3.5f)
            {
                for (int i = 0; i < fire.Length; i++)
                {
                    fire[i].startLifetime += Time.deltaTime;
                }
            }
        }
    }


    //starts extinguishing the fire and turns Eberhardt depending on where the player looks at
    public override void OnGazeEnter(RaycastHit hit)
    {
        peeing = true;
        player.transform.LookAt(gameObject.transform);
    }

    public override void OnGazeStay(RaycastHit hit)
    {
   
    }

    //stops extinguishing the fire, if the player stops looking at it
    public override void OnGazeExit()
    {
        peeing = false;
        isPeeing = false;
        audio.Stop();
    }
}
