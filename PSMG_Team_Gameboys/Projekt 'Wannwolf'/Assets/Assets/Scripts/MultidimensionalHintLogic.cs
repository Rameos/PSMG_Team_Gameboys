using UnityEngine;
using System.Collections;

public class MultidimensionalHintLogic : MonoBehaviour {

    private Respawn respawn;
    private GameMenu gameMenu;
    private GameObject player;
    private bool wasPlayed;
    private bool dialogueTriggered;

    public AudioClip[] dialogues;

    public GameObject invisibleWall;
    public GameObject untertitel;

    void Awake()
    {
        wasPlayed = false;
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
        respawn = GameObject.FindGameObjectWithTag(TagManager.GAME_CONTROLLER).GetComponent<Respawn>();
        gameMenu = GameObject.FindGameObjectWithTag(TagManager.GAME_CONTROLLER).GetComponent<GameMenu>();
    }

    void Update()
    {
        checkForDying();
        destroyHintAndWall();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == TagManager.PLAYER)
        {
            checkFireArrivalTimes();
        }
    }

    void checkFireArrivalTimes()
    {
        if (!player.GetComponent<PlayerControl>().vodkaStatus && !player.GetComponent<PlayerControl>().drankStatus)
        {
            audio.clip = dialogues[0];
            audio.Play();
        }
        else if (!player.GetComponent<PlayerControl>().drankStatus && player.GetComponent<PlayerControl>().vodkaStatus)
        {
            audio.clip = dialogues[1];
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
        if (respawn.dyingStatus || respawn.respawnStatus)
        {
            audio.Stop();
            dialogueTriggered = false;

        }
    }
}
