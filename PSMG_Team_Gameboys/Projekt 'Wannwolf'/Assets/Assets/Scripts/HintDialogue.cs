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

    const string pizzaHint = "Du kannst die Pizza mit deinen Augen zerschneiden. Den Kampf startest du mit 'f'";
    const string bierberHint = "Stehle ein Bier von dem Angler Flussaufwärts.";
    const string sneekHint = "Du musst dich anschleichen, damit der Angler nicht aufwacht. Mit 'f' kannst du das Bier aufheben.";
    const string beerToBierberHint = "Bringe das Bier zurück zum Bierber.";
    const string fireArrivalHint = "Gehe zur Pilzeria und kaufe eine Löschflüssigkeit.";
    const string fireFightingHint = "Trinke den Wodka, um das Feuer auszupinkeln";
    const string vodkaHint = "Trink den Wodka gleich, damit du am Feuer pinkeln kannst. Den Strahl kannst du mit deinen Augen steuern.";
    const string jumpHint = "Kaufe die ein PowerUp in der PIlzeria, um höher springen zu können.";
    const string stairHint = "Du kannst dir aus den Baumstämmen eine Treppe bauen.";
    const string baumHint = "Gehe in den Baumstamm hinein.";
    const string chaseHint = "Du wirst vefolgt, schau zu, dass du wegkommst!";
    const string anglerAwakeHint = "";

	bool pizza = false;
	bool bierber = false;
	bool sneek = false;
	bool vodka = false;
	bool stair = false;
	bool edge = false;
	bool chase = false;

	int fireArrival = 0;
	int vodkaArrival = 0;

    private GameObject playerControl;

    public AudioClip[] Dialogues;

    public GameObject untertitel;
    
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
                untertitel.guiText.text = pizzaHint;
                StartCoroutine(resetDialog(5));
				pizza = true;
                break;
			case "BierberHint":
                checkIsAudioPlaying();
				controllPlaytime(bierber, Dialogues[BIERBER_HINT]);
                untertitel.guiText.text = bierberHint;
                StartCoroutine(resetDialog(8));
				bierber = true;    
				break;
        	case "AnglerArrivalHint":
                checkIsAudioPlaying();
                controllPlaytime(sneek, Dialogues[SNEEK_HINT]);
                untertitel.guiText.text = sneekHint;
                StartCoroutine(resetDialog(5));
				sneek = true;
                pizza = true;
                break;
            
            case "FireArrivalHint":
                checkIsAudioPlaying();
                checkFireArrivalTimes();
                break;
            case "VodkaHint":
                checkIsAudioPlaying();
				if(vodkaArrival == 2){
					controllPlaytime(vodka, Dialogues[VODKA_HINT]);
                    untertitel.guiText.text = vodkaHint;
                    StartCoroutine(resetDialog(5));
				}
				vodkaArrival++;
				break;
			case "JumpHint":
                checkIsAudioPlaying();
                controllPlaytime(stair, Dialogues[JUMP_HINT]);
                untertitel.guiText.text = jumpHint;
                StartCoroutine(resetDialog(5));
				stair = true;
                break;
            case "StairBuildHint":
                checkIsAudioPlaying();
                controllPlaytime(edge, Dialogues[STAIR_HINT]);
                untertitel.guiText.text = stairHint;
                StartCoroutine(resetDialog(5));
				edge = true;
                break;
            case "ChaseHint":
                checkIsAudioPlaying();
                controllPlaytime(chase, Dialogues[CHASE_HINT]);
                untertitel.guiText.text = chaseHint;
                StartCoroutine(resetDialog(5));
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
            untertitel.guiText.text = fireArrivalHint;
            StartCoroutine(resetDialog(5));
            audio.clip = Dialogues[FIRE_ARRIVAL_HINT];
            audio.Play();
            fireArrival = 1;
        }
        else if (playerControl.GetComponent<PlayerControl>().drankStatus)
        {
            untertitel.guiText.text = fireFightingHint;
            StartCoroutine(resetDialog(5));
            StartCoroutine(resetDialog(5));
            audio.clip = Dialogues[FIRE_FIGHTING_HINT];
            audio.Play();
        }
    }

    public void playAnglerAwakeSound()
    {
        untertitel.guiText.text = anglerAwakeHint;
        StartCoroutine(resetDialog(5));
        audio.clip = Dialogues[ANGLER_AWAKE_HINT];
        audio.Play();
    }

    public void playNorbertBeerHint()
    {
        Debug.Log(Dialogues[BEER_TO_BIERBER_HINT]);
        untertitel.guiText.text = beerToBierberHint;
        StartCoroutine(resetDialog(5));
        audio.clip = Dialogues[BEER_TO_BIERBER_HINT];
        audio.Play();
    }

	public void playBierberAngry()
	{
        untertitel.guiText.text = bierberHint;
        StartCoroutine(resetDialog(5));
		audio.clip = Dialogues[BIERBER_HINT];
		audio.Play();
	}

    IEnumerator resetDialog(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        untertitel.guiText.text = "";
    }
}
