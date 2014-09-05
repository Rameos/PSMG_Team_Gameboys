using UnityEngine;
using System.Collections;
using iViewX;
[RequireComponent(typeof(ExtinguishFire))]
public class PeeOnFire : MonoBehaviourWithGazeComponent
{

    private bool peeing = false;
    private ParticleSystem fire;
    private GameObject player;
    private float rotation;
    private ExtinguishFire exFire;
    private float currentY;


	// Use this for initialization
	void Awake () {
    exFire = GameObject.FindGameObjectWithTag(TagManager.FIRE_RADIUS_TRIGGER).GetComponent<ExtinguishFire>();
    fire = gameObject.GetComponent<ParticleSystem>();
    player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        shrinkFire();
        growFire();
	}

    void shrinkFire()
    {
        if (peeing && exFire.startPeeing)
        {
            player.transform.LookAt(gameObject.transform);
            if (fire.startLifetime <= 0.1)
            {
                GameObject.FindGameObjectWithTag(TagManager.PLAYER_FLAMES).GetComponent<ParticleSystem>().Stop();
                GameObject.Destroy(gameObject);
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
            if (fire.startLifetime < 3.5f)
            {
                fire.startLifetime += Time.deltaTime;
            }
        }
    }

    public override void OnGazeEnter(RaycastHit hit)
    {
        Debug.Log("Hallihallo");
        peeing = true;
        currentY = player.transform.rotation.y;
        player.transform.LookAt(gameObject.transform);
    }

    public override void OnGazeStay(RaycastHit hit)
    {
        //Vector3 rotate = new Vector3(gazeModel.posGazeRight.x / 10,0, 0 );

        //rotation = (player.transform.position.x - gazeModel.posGazeRight.x) / 10;

          //  player.transform.Rotate(0, currentY - rotation, 0);

        
     
        //player.transform.Rotate(gazeModel.posGazeRight.x / 10, 0, 0);
        //Debug.Log(player.transform.rotation);
        
    }

    public override void OnGazeExit()
    {
        peeing = false;
    }
}
