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

    public AudioSource myAudio;
    public AudioClip pizza;

    public AudioClip[] Dialogues;
    GameObject player;
    bool anglerArrival = false;
    int fireArrival = 0;
    public static HintDialogue hint;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

	// Use this for initialization
	void Start () {
        myAudio = gameObject.AddComponent<AudioSource>();
        myAudio.playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        string tag = gameObject.tag;
        switch (tag)
        {
            case "PizzaHint": audio.clip = (AudioClip)Resources.Load("pizza");
                Debug.Log("Jetzt müsste Sound spielen");
                myAudio.Play();
                break;
            case "BierberHint": audio.clip = Dialogues[BIERBER_HINT];
                audio.Play();
                break;
            case "AnglerArrivalHint":
                if (!anglerArrival)
                {
                    audio.clip = Dialogues[SNEEK_HINT];
                    audio.Play();
                    anglerArrival = true;
                }
                break;
            case "FireArrivalHint":
                checkFireArrivalTimes();
                break;
            case "JumpHint":
                audio.clip = Dialogues[JUMP_HINT];
                audio.Play();
                break;
            case "StairBuildHint":
                audio.clip = Dialogues[STAIR_HINT];
                audio.Play();
                break;
            case "ChaseHint":
                audio.clip = Dialogues[BAUM_HINT];
                audio.Play();
                break;
        }
    }

    void checkFireArrivalTimes()
    {
        if (fireArrival == 0)
        {
            audio.clip = Dialogues[FIRE_ARRIVAL_HINT];
            audio.Play();
            fireArrival++;
        }
        else if (fireArrival == 1)
        {
            audio.clip = Dialogues[FIRE_FIGHTING_HINT];
            audio.Play();
            fireArrival++;
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
}
