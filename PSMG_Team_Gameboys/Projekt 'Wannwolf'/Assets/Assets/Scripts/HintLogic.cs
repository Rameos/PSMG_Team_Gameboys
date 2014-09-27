using UnityEngine;
using System.Collections;

public class HintLogic : MonoBehaviour {

    private Respawn respawn;
    private GameMenu gameMenu;
    private GameObject player;
    private bool wasPlayed;
    private bool dialogueTriggered;
    private bool isPlaying;
    public GameObject untertitel;
    public GameObject hint;
    public AudioClip dialogue;
    public string text;

    public Texture2D texture;

    public GameObject invisibleWall;

    void Awake()
    {
        wasPlayed = false;
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
        respawn = GameObject.FindGameObjectWithTag(TagManager.GAME_CONTROLLER).GetComponent<Respawn>();
        gameMenu = GameObject.FindGameObjectWithTag(TagManager.GAME_CONTROLLER).GetComponent<GameMenu>();
    }

    void Update()
    {
        if (isPlaying)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                player.GetComponent<PlayerControl>().enabled = true;
                wasPlayed = true;
                Destroy(gameObject);
                if (invisibleWall != null)
                {
                    Destroy(invisibleWall);
                }
            }
        }
        destroyHintAndWall();
        checkForDying();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == TagManager.PLAYER)
        {
            checkForNeed();
            if (gameObject.tag == TagManager.BIERBER_HINT)
            {
                isPlaying = true;
                player.GetComponent<PlayerControl>().enabled = false;
            }
        }
    }

    void controllPlaytime(bool wasPlayed, AudioClip sound)
    {
        /*if (gameObject.tag == TagManager.VODKA_HINT)
        {
            if (player.GetComponent<PlayerControl>().hadVodkaOnce)
            {
                playSound();
            }
        }
        else
        {
            playSound();
        }*/
        playSound();
    }


    //shows current task
    void showTask()
    {
        untertitel.guiTexture.texture = texture;
        hint.guiText.text = text;
        StartCoroutine(resetDialog(5));
    }

    //removes the current task after 5 seconds
    IEnumerator resetDialog(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        hint.guiText.text = "";
        untertitel.guiTexture.texture = null;
    }

    void playSound()
    {
        if (!wasPlayed && !audio.isPlaying)
        {
            audio.clip = dialogue;
            audio.Play();
            showTask();
            dialogueTriggered = true;
        }
    }

    void destroyHintAndWall()
    {
        if (dialogueTriggered && !audio.isPlaying && !gameMenu.gameMenuStatus)
        {
            player.GetComponent<PlayerControl>().enabled = true;
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
    void checkForNeed()
    {
        if (gameObject.tag == TagManager.FIRE_ARRIVAL_HINT && player.GetComponent<PlayerControl>().drankStatus || player.GetComponent<PlayerControl>().vodkaStatus)
        {
            Destroy(gameObject);
        }
        else if (gameObject.tag == TagManager.JUMP_HINT && player.GetComponent<PlayerControl>().ableToDoubleJumpStatus)
        {
            Destroy(gameObject);
        }
        else
        {
            controllPlaytime(wasPlayed, dialogue); 
        }
    }
}
