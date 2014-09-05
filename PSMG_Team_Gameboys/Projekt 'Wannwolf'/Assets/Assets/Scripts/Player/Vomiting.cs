using UnityEngine;
using System.Collections;

public class Vomiting : MonoBehaviour {

    private const float VOMIT_TIME = 5f;

    private PlayerControl playerControl;
    private CameraSwitcher switcher;
    private ParticleSystem vomit;

    void Start()
    {
        playerControl = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<PlayerControl>();
        vomit = GameObject.FindGameObjectWithTag("Vomit").GetComponent<ParticleSystem>();
        switcher = gameObject.GetComponent<CameraSwitcher>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == TagManager.PLAYER)
        {
            setPlayerControlStatus(false);
            setVomitingCamera();
            startVomiting();
            StartCoroutine(waitForVomitingEnd());
        }
    }

    IEnumerator waitForVomitingEnd()
    {
        yield return new WaitForSeconds(VOMIT_TIME);
        stopVomiting();
        unsetVomitingCamera();
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

    void setVomitingCamera()
    {
        switcher.setVomitStatic();
    }

    void unsetVomitingCamera()
    {
        switcher.setCameraDynamic();
    }

    void destroyGameObject()
    {
        Destroy(gameObject);
    }
}
