using UnityEngine;
using System.Collections;

public class UrinFireCollision : MonoBehaviour{

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Fire")
        {
            Destroy(other);
        }
    }
}
