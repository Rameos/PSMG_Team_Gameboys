using UnityEngine;
using System.Collections;
using iViewX;

public class PeeOnFire : MonoBehaviourWithGazeComponent
{

    private bool peeing = false;
    private ParticleSystem fire;

	// Use this for initialization
	void Awake () {
	fire = gameObject.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        shrinkFire();
        growFire();
	}

    void shrinkFire()
    {
        if (peeing)
        {
            if (fire.startLifetime <= 0.1)
            {
                GameObject.FindGameObjectWithTag("PlayerFlames").GetComponent<ParticleSystem>().Stop();
                GameObject.Destroy(fire);
            }
            else
            {
                fire.startLifetime -= 2 * Time.deltaTime;
            }
        }
    }

    void growFire()
    {
        if (!peeing)
        {
            if(fire.startLifetime < 4.5f)
            fire.startLifetime += Time.deltaTime;
        }
    }

    public override void OnGazeEnter(RaycastHit hit)
    {
        peeing = true;
    }

    public override void OnGazeStay(RaycastHit hit)
    {

    }

    public override void OnGazeExit()
    {
        peeing = false;
    }
}
