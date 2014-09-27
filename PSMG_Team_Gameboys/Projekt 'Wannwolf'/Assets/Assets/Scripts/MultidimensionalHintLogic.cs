using UnityEngine;
using System.Collections;

public class MultidimensionalHintLogic : MonoBehaviour {

    private Respawn respawn;
    private GameMenu gameMenu;
    private GameObject player;
    private bool dialogueTriggered;
    private int fireArrival;

    public AudioClip[] dialogues;
    public string fire1;
    public string fire2;

    public GameObject invisibleWall;
    public GameObject untertitel;
    public GameObject hint;

    public Texture2D texture;

    void Awake()
    {
        fireArrival = 0;
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
        if (!player.GetComponent<PlayerControl>().vodkaStatus && !player.GetComponent<PlayerControl>().drankStatus && fireArrival == 0)
        {
            showTask(fire1);
            audio.clip = dialogues[0];
            audio.Play();
            fireArrival = 1;
        }
        else if (!player.GetComponent<PlayerControl>().drankStatus && player.GetComponent<PlayerControl>().hadVodkaOnce)
        {
            showTask(fire2);
            audio.clip = dialogues[1];
            audio.Play();
            dialogueTriggered = true;
        }
    }

    void destroyHintAndWall()
    {
        if (dialogueTriggered && !audio.isPlaying && !gameMenu.gameMenuStatus)
        {
            Destroy(gameObject);
            if (invisibleWall != null)
            {
                Destroy(invisibleWall);
            }
        }
    }


    //shows the current task
    void showTask(string text)
    {
        untertitel.guiTexture.texture = texture;
        hint.guiText.text = text;
        StartCoroutine(resetDialog(5));
    }

    void checkForDying()
    {
        if (respawn.dyingStatus || respawn.respawnStatus)
        {
            audio.Stop();
            dialogueTriggered = false;

        }
    }

    //removes the current task after 5 seconds
    IEnumerator resetDialog(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        untertitel.guiText.text = ""; 
        untertitel.guiTexture.texture = null;
    }
}
