using UnityEngine;
using System.Collections;

public class HintLogic : MonoBehaviour {

    private GameObject playerControl;
    private Respawn respawn;
    private GameMenu gameMenu;
    private bool wasPlayed;
    private bool dialogueTriggered;

    public AudioClip dialogue;

    public GameObject invisibleWall;
    public GameObject untertitel;

    void Awake()
    {
        wasPlayed = false;
        respawn = GameObject.FindGameObjectWithTag(TagManager.GAME_CONTROLLER).GetComponent<Respawn>();
        gameMenu = GameObject.FindGameObjectWithTag(TagManager.GAME_CONTROLLER).GetComponent<GameMenu>();
        playerControl = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
    }

    void Update()
    {
        destroyHintAndWall();
        checkForDying();
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.LogWarning("TRIGGER ENTER");
        if (col.tag == TagManager.PLAYER)
        {
            controllPlaytime(wasPlayed, dialogue);   
        }
    }

    void controllPlaytime(bool wasPlayed, AudioClip sound)
    {
        if (!wasPlayed && !audio.isPlaying)
        {
            audio.clip = sound;
            audio.Play();
            dialogueTriggered = true;
        }
    }

    void destroyHintAndWall()
    {
        if (dialogueTriggered && !audio.isPlaying && !gameMenu.gameMenuStatus)
        {
            wasPlayed = true;
            Destroy(gameObject);
            if (invisibleWall != null)
            {
                Destroy(invisibleWall);
            }
        }
    }

    void checkForDying()
    {
        if (respawn.dyingStatus)
        {
            dialogueTriggered = false;
            audio.Stop();
        }
    }
}
