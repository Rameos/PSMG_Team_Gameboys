using UnityEngine;
using System.Collections;

public class StopUrinating : MonoBehaviour {

    void OnTriggerEnter()
    {
        GameObject.FindGameObjectWithTag(TagManager.URINSTRAHL).GetComponent<ParticleSystem>().Stop();
    }
}
