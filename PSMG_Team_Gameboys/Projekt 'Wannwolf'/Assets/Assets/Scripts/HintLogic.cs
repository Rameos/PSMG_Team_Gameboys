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
            }
        }
        stopShowingTask();
        destroyHintAndWall();
        checkForDying();
    }

    void stopShowingTask()
    {
        if (wasPlayed)
        {
            Debug.Log("InStopTask");
            StartCoroutine(resetDialog(5));
            wasPlayed = false;
            dialogueTriggered = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == TagManager.PLAYER)
        {
            if (player.GetComponent<PlayerControl>().vodkaStatus || player.GetComponent<PlayerControl>().drankStatus)
            {
                Destroy(gameObject);
            }else playSound();
            
            if (gameObject.tag == TagManager.BIERBER_HINT && !isPlaying)
            {
                isPlaying = true;
                player.GetComponent<PlayerControl>().enabled = false;
            }
        }
    }

    //shows current task
    void showTask()
    {
        untertitel.guiTexture.texture = texture;
        hint.guiText.text = text;
    }

    //removes the current task after 5 seconds
    IEnumerator resetDialog(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        hint.guiText.text = "";
        untertitel.guiTexture.texture = null;
        Destroy(gameObject);
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
