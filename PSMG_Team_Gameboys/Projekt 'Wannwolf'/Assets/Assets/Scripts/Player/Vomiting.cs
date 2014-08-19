using UnityEngine;
using System.Collections;

public class Vomiting : MonoBehaviour {

    private const float VOMIT_TIME = 5f;

    private PlayerControl playerControl;
    private ParticleSystem vomit;

    void Start()
    {
        playerControl = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<PlayerControl>();
        vomit = GameObject.FindGameObjectWithTag("Vomit").GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == TagManager.PLAYER)
        {
            setPlayerControlStatus(false);
            startVomiting();
            StartCoroutine(waitForVomitingEnd());
        }
    }

    IEnumerator waitForVomitingEnd()
    {
        yield return new WaitForSeconds(VOMIT_TIME);
        stopVomiting();
        setPlayerControlStatus(true);
        setPlayerSober();
        destroyGameObject();
    }

    void setPlayerSober()
    {
        playerControl.drankStatus = false;
    }

    void setPlayerControlStatus(bool enabled)
    {
        playerControl.enabled = enabled;
    }

    void startVomiting()
    {
        vomit.Play(true);
    }

    void stopVomiting()
    {
        vomit.Stop(true);
    }

    void destroyGameObject()
    {
        Destroy(gameObject);
    }
}
