using UnityEngine;
using System.Collections;

public class UrinFireCollision : MonoBehaviour{

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Fire")
        {
            if (other.GetComponent<ParticleSystem>().startLifetime <= 0.1)
            {
                GameObject.FindGameObjectWithTag("PlayerFlames").GetComponent<ParticleSystem>().Stop();
                GameObject.Destroy(other);
            }
            else
            {
                other.GetComponent<ParticleSystem>().startLifetime -= Time.deltaTime;
            }
        }
    }
}
