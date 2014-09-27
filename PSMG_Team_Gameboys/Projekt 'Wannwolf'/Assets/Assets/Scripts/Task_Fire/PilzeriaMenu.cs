using UnityEngine;
using System.Collections;

public class PilzeriaMenu : MonoBehaviour {

	private bool isMenu = false;
    private bool inMenuRadius = false;
	private Rect butRect;
	private float width = 160;
	private float height = 30;
    private MoneyManagement moneyManagement;
    private GameObject player;
    private PlayerControl control;

    private DrinkLogic drinkLogic;


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
		if (isMenu) {
            
			butRect.y = (Screen.height - height)/2 - 60;

			if(GUI.Button (butRect, "Double Jump - $30"))
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

			if(GUI.Button (butRect, "Länger sprinten - $25"))
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

            if (GUI.Button(butRect, "Vodka - 35$") && !control.vodkaStatus)
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

			if(GUI.Button (butRect, "Zurück") || Input.GetKeyDown(KeyCode.Escape))
                toggleTimeScale();
                togglePlayerControl();
        }
        else
        {
            if (!isMenu && inMenuRadius)
            {
                //informs player how to open the pilzeria menu
                GUI.Button(new Rect((Screen.width - (width* 2))/2, (float)(Screen.height * 0.2), width * 2, height), "Drücke \"F\" um das \nPilzeriamenu zu öffnen");
            }
        }
                if (control.vodkaStatus)
                {
                    //informs player how to drink the wodka
                    GUI.Button(new Rect((Screen.width - (width * 2)) / 2, (float)(Screen.height * 0.1), width * 2, height), "Drücke \"E\" um den \nVodka zu trinken");
                }
        //informs the player about Eberhardt's state
        if(control.vodkaStatus)
        {
            GUI.Button(new Rect((Screen.width - width) / 2, (float)(Screen.height * 0.8), width, height), "Eberhardt hat Vodka");
        }
        else if (control.drankStatus)
        {
            GUI.Button(new Rect((Screen.width - width) / 2, (float)(Screen.height * 0.8), width, height), "Eberhardt ist betrunken");
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
