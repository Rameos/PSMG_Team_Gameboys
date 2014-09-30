using UnityEngine;
using System.Collections;

public class PilzeriaMenu : MonoBehaviour {

	private bool isMenu = false;
    private bool inMenuRadius = false;
	
	private float width = 200f;
	private float height = 50f;

    private string pushF = "Drücke \"F\" um das \nPilzeriamenu zu öffnen";
    private string hasVodka = "Eberhardt hat Vodka, \ndrücke \"E\", um ihn zu trinken";
    private string isDrunk = "Eberhardt ist betrunken";
    private string doubleJump = "Double Jump - $30";
    private string sprintLonger = "Länger sprinten - $25";
    private string vodka = "Vodka - 35$";
    private string back = "Zurück";

    private Rect butRect;
    private MoneyManagement moneyManagement;
    private GameObject player;
    private PlayerControl control;
    private DrinkLogic drinkLogic;
    private GUIStyle center;
    public GUIStyle message;

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

            if (GUI.Button(butRect, doubleJump, center))
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

            if (GUI.Button(butRect, sprintLonger, center))
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

            if (GUI.Button(butRect, vodka, center) && !control.vodkaStatus)
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

            if (GUI.Button(butRect, back, center) || Input.GetKeyDown(KeyCode.Escape))
                toggleTimeScale();
                togglePlayerControl();
        }
        else
        {
            if (!isMenu && inMenuRadius)
            {
                //informs player how to open the pilzeria menu
                GUI.Label(new Rect((Screen.width - (width* 2))/2, (float)(Screen.height * 0.2), width * 2, height), pushF, message);
            }
        }
                
        //informs the player about Eberhardt's state and how to drink the vodka
        if(control.vodkaStatus)
        {
            GUI.Label(new Rect((Screen.width - 2* width) / 2, (float)(Screen.height * 0.8), 2 * width, height), hasVodka, message);
        }
        else if (control.drankStatus)
        {
            GUI.Label(new Rect((Screen.width - width) / 2, (float)(Screen.height * 0.8), width, height), isDrunk, message);
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
