using UnityEngine;
using System.Collections;

public class StopPeeing : MonoBehaviour {

    private GameObject pee;

	// Update is called once per frame
	void Update () {
        checkFireStatus();
	}

    void checkFireStatus(){
        if (GameObject.FindGameObjectWithTag(TagManager.FIRE) == null)
        {
            GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<PlayerControl>().enabled = true;
            GameObject.FindGameObjectWithTag(TagManager.MAIN_CAMERA).GetComponent<CameraControl>().enabled = true;
            pee = GameObject.FindGameObjectWithTag(TagManager.URINSTRAHL);
            pee.GetComponent<ParticleSystem>().Stop();
            destroyInvisibleWall();
        }
    }

    void destroyInvisibleWall()
    {
        Destroy(gameObject);
    }
}
