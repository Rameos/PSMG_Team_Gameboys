using UnityEngine;
using System.Collections;

public class HintDialogue : MonoBehaviour {

    const int PIZZA_HINT = 0;
    const int BIERBER_HINT = 1;
    const int SNEEK_HINT = 2;
    const int BEER_TO_BIERBER_HINT = 3;
    const int FIRE_ARRIVAL_HINT = 4;
    const int FIRE_FIGHTING_HINT = 5;
    const int VODKA_HINT = 6;
    const int JUMP_HINT = 7;
    const int STAIR_HINT = 8;
    const int BAUM_HINT = 9;
    const int CHASE_HINT = 10;
    const int ANGLER_AWAKE_HINT = 11;

	bool pizza = false;
	bool bierber = false;
	bool sneek = false;
	bool retrieve = false;
	bool vodka = false;
	bool stair = false;
	bool edge = false;
	bool tree = false;
	bool chase = false;
	bool anglerAwake = false;

	int fireArrival = 0;
	int vodkaArrival = 0;

    private GameObject playerControl;

    public AudioClip[] Dialogues;
    
    void Awake()
    {
        playerControl = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
    }
	
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == TagManager.PLAYER)
        {
            checkTags();
        }
    }

    void checkTags()
    {
        string tag = gameObject.tag;
        switch (tag)
        {
            case "PizzaHint":
                checkIsAudioPlaying();
                controllPlaytime(pizza, Dialogues[PIZZA_HINT]);
                pizza = true;
                break;
            case "BierberHint":
                controllPlaytime(bierber, Dialogues[BIERBER_HINT]);
                bierber = true;
                break;
            case "AnglerArrivalHint":
                checkIsAudioPlaying();
                controllPlaytime(sneek, Dialogues[SNEEK_HINT]);
                sneek = true;
                break;
            case "FireArrivalHint":
                checkIsAudioPlaying();
                checkFireArrivalTimes();
                break;
            case "VodkaHint":
                checkIsAudioPlaying();
                if (vodkaArrival == 2)
                {
                    controllPlaytime(vodka, Dialogues[VODKA_HINT]);
                }
                vodkaArrival++;
                break;
            case "JumpHint":
                checkIsAudioPlaying();
                controllPlaytime(stair, Dialogues[JUMP_HINT]);
                stair = true;
                break;
            case "StairBuildHint":
                checkIsAudioPlaying();
                controllPlaytime(edge, Dialogues[STAIR_HINT]);
                edge = true;
                break;
            case "ChaseHint":
                checkIsAudioPlaying();
                controllPlaytime(chase, Dialogues[CHASE_HINT]);
                chase = true;
                break;
        }
    }

	void controllPlaytime (bool state, AudioClip sound){
		if (!state)
		{
			audio.clip = sound;
			audio.Play();
		}
	}

    void checkIsAudioPlaying(){
        if (audio.isPlaying)
        {
            audio.Stop();
        }
    }

    void checkFireArrivalTimes()
    {
        if (!playerControl.GetComponent<PlayerControl>().vodkaStatus && !playerControl.GetComponent<PlayerControl>().drankStatus && fireArrival == 0)
        {
            audio.clip = Dialogues[FIRE_ARRIVAL_HINT];
            audio.Play();
            fireArrival = 1;
        }
        else if (playerControl.GetComponent<PlayerControl>().drankStatus)
        {
            audio.clip = Dialogues[FIRE_FIGHTING_HINT];
            audio.Play();
        }
    }

    public void playAnglerAwakeSound()
    {
        audio.clip = Dialogues[ANGLER_AWAKE_HINT];
        audio.Play();
    }

    public void playNorbertBeerHint()
    {
        audio.clip = Dialogues[BEER_TO_BIERBER_HINT];
        audio.Play();
    }

	public void playBierberAngry()
	{
		audio.clip = Dialogues[BIERBER_HINT];
		audio.Play();
	}
}
