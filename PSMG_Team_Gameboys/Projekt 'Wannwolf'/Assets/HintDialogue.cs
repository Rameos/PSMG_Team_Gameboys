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

    const string pizzaHint = "Norbert: Scheisse Alter, die Pizzen greifen uns an, aber gut, dass wir den \n Pizzaroller dabei haben. Mit dem kannst du sie sicher toeten, wenn du sie zerteilst. \n Du kannst den Pizzaroller mit deinen Augen steuern. \n Eberhardt: ja verrueckt, mit den Augen? So wie mit einem Eyetracker, quasi? \n Norbert: was?";
    const string bierberHint = "Bierber: Ey pass mal auf du! Was suchst du auf meinem Dosendamm? \n Das ist kein Spielplatz hier, du praepubertaere Eichfotze! Wenn du unbedingt ueber denn Fluss willst, \n dann organisier mir ein Bier und zwar vom schlafenden Angler, den FLuss aufwaerts. \n Und dann nage ich dir, vielleicht, wahrscheinlich schon, einen Baum um. Ok? \n Norbert: So ein bloeder, unfreundlicher Bierber! \n Eberhardt:Ja Ultra! Das letzte mal, als dem jemand einen Witz erzaehlt hat, war wahrscheinlich 18-hundert-sonst noch was...";
    const string sneekHint = "Norbert: Eberhardt, du musst dich anschleichen, damit der Angler nicht aufwacht. \n Sonst verpruegelt der uns doch!";
    const string beerToBierberHint = "Norbert: Jetzt bring das Bier schnell zum Bierber! \n Eberhardt: Alles klar, los geht's!";
    const string fireArrivalHint = "Norbert: Alter Eberhardt, wir sind doch gerade an einer Pilzeria vorbeigekommen, \n schau da doch mal rein. Da gibt es bestimmt was zum Loeschen, \n irgendeine Fluessigkeit oder so..";
    const string fireFightingHint = "Norbert: Also ich glaube, du haettest den Wodka gleich trinken sollen, \n damit du das Feuer auspinkeln kannst.";
    const string vodkaHint = "Norbert: Trink den Wodka doch gleich, dann musst du am Feuer nicht so lange warten, \n bis du pinkeln kannst. Und uebrigens, deinen Urinstrahl kannst du wieder mit deinen Augen steuern.";
    const string jumpHint = "Norbert: Warte mal, wahrscheinlich musst du dir ein PowerUp in der Pilzeria kaufen, \n damit du die Treppen hochhuepfen kannst. \n Eberhardt: Willst du Hipsternuss mir jetzt erzaehlen, dass ich zugenommen habe? \n Norbert: Was?";
    const string stairHint = "Norbert:Schau mal her, ich glaube, du kannst dir sicher aus diesen Baumstaemmen da eine Treppe bauen. \n Eberhardt: Ja, das hoert sich nach einem Plan an! So machen wir das! \n Norbert: Was ist?";
    const string baumHint = "Norbert: Alter Eberhardt, ich habe irgendwie das Gefuehl, dass der Baumstamm die Tuer \n zum Ende unserer Reise ist. Jetzt gehe mal rein und schaue, was passiert. \n Eberhardt: Alles klar, machen wir! \n Norbert: was?";
    const string chaseHint = "Norbert: Alter scheisse, jetzt verfolgen die uns auch noch. \n Schnell, siehzu, dass du hier wegkommst!";
    const string anglerAwakeHint = "";
    private string currentText = "blaaaaa";

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

    public AudioClip[] Dialogues;

    public GameObject untertitel;
    
    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {
        
	}
	
    void OnTriggerEnter(Collider col)
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

        if (fireArrival == 0)
        {
            untertitel.guiText.text = fireArrivalHint;
            StartCoroutine(resetDialog(5));
            audio.clip = Dialogues[FIRE_ARRIVAL_HINT];
            audio.Play();
            
        }
        else if (fireArrival == 2)
        {
            untertitel.guiText.text = fireFightingHint;
            StartCoroutine(resetDialog(5));
            StartCoroutine(resetDialog(5));
            audio.clip = Dialogues[FIRE_FIGHTING_HINT];
            audio.Play();
            
        }
        fireArrival++;
        Debug.Log("Times: " + fireArrival);
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
