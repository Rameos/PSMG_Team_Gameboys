using UnityEngine;
using System.Collections;

public class StopUrinating : MonoBehaviour {

    void OnTriggerEnter()
    {
        GameObject.FindGameObjectWithTag("Urinstrahl").GetComponent<ParticleSystem>().Stop();
    }
}
