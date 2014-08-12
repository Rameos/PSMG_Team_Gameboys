using UnityEngine;
using System.Collections;
using iViewX;

public class PeeOnFire : MonoBehaviourWithGazeComponent
{

    private bool peeing = false;
    private ParticleSystem fire;
    private GameObject player;
    private float rotation;

	// Use this for initialization
	void Awake () {
	fire = gameObject.GetComponent<ParticleSystem>();
    player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        shrinkFire();
        //growFire();
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
                fire.startLifetime -= Time.deltaTime;
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
        Debug.Log("Hallihallo");
        peeing = true;
        
    }

    public override void OnGazeStay(RaycastHit hit)
    {
        //Vector3 rotate = new Vector3(gazeModel.posGazeRight.x / 10,0, 0 );
        rotation = (500 - gazeModel.posGazeRight.x) / 10;

            player.transform.Rotate(0, rotation, 0);
            player.transform.rotation.y = rotation;
        
     
        //player.transform.Rotate(gazeModel.posGazeRight.x / 10, 0, 0);
        //Debug.Log(player.transform.rotation);
        
    }

    public override void OnGazeExit()
    {
        //peeing = false;
    }
}
