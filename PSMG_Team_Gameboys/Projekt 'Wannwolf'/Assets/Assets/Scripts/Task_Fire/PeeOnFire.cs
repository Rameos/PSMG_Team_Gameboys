using UnityEngine;
using System.Collections;
using iViewX;

public class PeeOnFire : MonoBehaviourWithGazeComponent
{

    private bool peeing = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void OnGazeEnter(RaycastHit hit)
    {
        peeing = true;
        StartCoroutine(pee(2));


    }

    IEnumerator pee(float seconds)
    {


        yield return new WaitForSeconds(seconds);
        if (peeing == true)
        {

            Destroy(gameObject); 
        }





    }
    public override void OnGazeStay(RaycastHit hit)
    {

      


    }

    public override void OnGazeExit()
    {

        peeing = false;

    }
}
