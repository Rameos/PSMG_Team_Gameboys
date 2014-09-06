﻿using UnityEngine;
using System.Collections;

public class HintLogic : MonoBehaviour {

    private Respawn respawn;
    private GameMenu gameMenu;
    private GameObject player;
    private bool wasPlayed;
    private bool dialogueTriggered;
    public GameObject untertitel;
    public AudioClip dialogue;
    public string text;

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
        destroyHintAndWall();
        checkForDying();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == TagManager.PLAYER)
        {
            controllPlaytime(wasPlayed, dialogue);   
        }
    }

    void controllPlaytime(bool wasPlayed, AudioClip sound)
    {
        if (gameObject.tag == TagManager.VODKA_HINT)
        {
            if (player.GetComponent<PlayerControl>().hadVodkaOnce)
            {
                playSound();
            }
        }
        else
        {
            playSound();
        }
        
    }

    void showTask()
    {
        untertitel.guiText.text = text;
        StartCoroutine(resetDialog(5));
    }

    IEnumerator resetDialog(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        untertitel.guiText.text = "";
    }

    void playSound()
    {
        if (!wasPlayed && !audio.isPlaying)
        {
            showTask();
            audio.clip = dialogue;
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
