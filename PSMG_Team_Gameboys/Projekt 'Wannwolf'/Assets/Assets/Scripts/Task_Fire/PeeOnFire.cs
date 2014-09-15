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

	void Awake () {
    exFire = GameObject.FindGameObjectWithTag(TagManager.FIRE_RADIUS_TRIGGER).GetComponent<ExtinguishFire>();
    fire = gameObject.GetComponentsInChildren<ParticleSystem>();
    player = GameObject.FindGameObjectWithTag("Player");
	}
	

	void Update () {
        shrinkFire();
        growFire();
	}

    void shrinkFire()
    {
        if (peeing && exFire.startPeeing)
        {
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

    public override void OnGazeEnter(RaycastHit hit)
    {
        peeing = true;
        player.transform.LookAt(gameObject.transform);
    }

    public override void OnGazeStay(RaycastHit hit)
    {
   
    }

    public override void OnGazeExit()
    {
        peeing = false;
    }
}
