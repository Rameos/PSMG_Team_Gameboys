using UnityEngine;
using System.Collections;

public class PilzeriaMenu : MonoBehaviour {

	private bool isMenu = false;
    private bool inMenuRadius = false;
	
	private float width = 190f;
	private float height = 50f;

    private string pushF = "Drücke \"F\" um das \nPilzeriamenu zu öffnen";
    private string pushE = "Drücke \"E\" um den \nVodka zu trinken";
    private string hasVodka = "Eberhardt hat Vodka";
    private string isDrunk = "Eberhardt ist betrunken";

    private Rect butRect;
    private MoneyManagement moneyManagement;
    private GameObject player;
    private PlayerControl control;
    private DrinkLogic drinkLogic;
    private GUIStyle center;

    public Font font;


	// Use this for initialization
	void Start () {
		butRect = new Rect ((Screen.width - width) / 2, 0, width, height);
        moneyManagement = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<MoneyManagement>();
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
        control = player.GetComponent<PlayerControl>();
        drinkLogic = player.GetComponent<DrinkLogic>();
        
	}

    void Update()
    {
        if (inMenuRadius)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                toggleTimeScale();
                togglePlayerControl();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagManager.PLAYER)
        {
            inMenuRadius = true;
            drinkLogic.inPilzeria = true;

        }
    }

	void OnTriggerStay (Collider other) {
		
	}

    void OnTriggerExit(Collider other)
    {
        inMenuRadius = false;
        drinkLogic.inPilzeria = false;
    }

	//create menu buttons
	void OnGUI()
	{
        center = new GUIStyle(GUI.skin.textField);
        center.font = font;
        center.alignment = TextAnchor.MiddleCenter;

		if (isMenu) {
            
			butRect.y = (Screen.height - height)/2 - 60;

            if (GUI.Button(butRect, "Double Jump - $30", center))
			{
				if(moneyManagement.getCurrentMoney() > 30)
				{
					pay(30);
					//enable double jump
                    control.ableToDoubleJumpStatus = true;
                    togglePlayerControl();
                    toggleTimeScale();
				}
			}

			butRect.y += height + 20;

            if (GUI.Button(butRect, "Länger sprinten - $25", center))
			{
				if(moneyManagement.getCurrentMoney() > 25)
				{
					pay(25);
                    control.sprintTimeStatus = 2;
                    togglePlayerControl();
                    toggleTimeScale();
				}
			}

			butRect.y += height + 20;

            if (GUI.Button(butRect, "Vodka - 35$", center) && !control.vodkaStatus)
            {
                if (moneyManagement.getCurrentMoney() > 35)
                {
                    pay(35);
                    control.vodkaStatus = true;
                    toggleTimeScale();
                    togglePlayerControl();
                }
            }

            butRect.y += height + 20;

            if (GUI.Button(butRect, "Zurück", center) || Input.GetKeyDown(KeyCode.Escape))
                toggleTimeScale();
                togglePlayerControl();
        }
        else
        {
            if (!isMenu && inMenuRadius)
            {
                //informs player how to open the pilzeria menu
                GUI.TextField(new Rect((Screen.width - (width* 2))/2, (float)(Screen.height * 0.2), width * 2, height), pushF, center);
            }
        }
                if (control.vodkaStatus)
                {
                    //informs player how to drink the wodka
                    GUI.TextField(new Rect((Screen.width - (width * 2)) / 2, (float)(Screen.height * 0.1), width * 2, height), pushE, center);
                }
        //informs the player about Eberhardt's state
        if(control.vodkaStatus)
        {
            GUI.TextField(new Rect((Screen.width - width) / 2, (float)(Screen.height * 0.8), width, height), hasVodka, center);
        }
        else if (control.drankStatus)
        {
            GUI.TextField(new Rect((Screen.width - width) / 2, (float)(Screen.height * 0.8), width, height), isDrunk, center);
        }
    }

	//substracts money
	void pay (int amount) {
		int OldAmount = moneyManagement.getCurrentMoney ();
		moneyManagement.setCurrentMoney (OldAmount - amount);
	}

	//stops game
	void toggleTimeScale()
	{
		if (!isMenu)
				Time.timeScale = 0;
		else
				Time.timeScale = 1;
		isMenu = !isMenu;
	}

    void togglePlayerControl()
    {
        if (!isMenu)
        {
            GameObject.FindGameObjectWithTag(TagManager.MAIN_CAMERA).GetComponent<CameraControl>().enabled = true;
            Screen.showCursor = false; // Hide cursor ingame
        }
        else
        {
            GameObject.FindGameObjectWithTag(TagManager.MAIN_CAMERA).GetComponent<CameraControl>().enabled = false;
            Screen.showCursor = true; // Show cursor while pilzeria menu is opened
        }
    }
}
