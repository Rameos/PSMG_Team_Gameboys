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
        moneyManagement = GameObject.FindGameObjectWithTag("Player").GetComponent<MoneyManagement>();
        player = GameObject.Find("Player");
        control = player.GetComponent<PlayerControl>();
        drinkLogic = player.GetComponent<DrinkLogic>();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inMenuRadius = true;
            drinkLogic.inPilzeria = true;
        }
    }

	void OnTriggerStay (Collider other) {
		if (Input.GetKeyDown (KeyCode.F))
			ToggleTimeScale ();
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

			if(GUI.Button (butRect, "Double Jump - $50"))
			{
				if(moneyManagement.getCurrentMoney() > 49)
				{
					pay(50);
                    control.ableToDoubleJumpStatus = true;
                    ToggleTimeScale();
				}
			}
			butRect.y += height + 20;

			if(GUI.Button (butRect, "Länger sprinten - $50"))
			{
				if(moneyManagement.getCurrentMoney() > 49)
				{
					pay(50);
                    control.sprintTimeStatus = 2; 
					ToggleTimeScale();
				}
				else Debug.Log(moneyManagement.getCurrentMoney());
			}
			butRect.y += height + 20;

			if(GUI.Button (butRect, "Beutelvergrößerung - $50"))
			{
				if(moneyManagement.getCurrentMoney() > 49)
				{
					pay(50);
					int beutelOld = moneyManagement.getMoneyMinimum();
					moneyManagement.setMoneyMaximum(beutelOld + 50);
					ToggleTimeScale();
				}
			}
			butRect.y += height + 20;

            if (GUI.Button(butRect, "Vodka") && !control.vodkaStatus)
            {
                pay(5);
                control.vodkaStatus = true;
                ToggleTimeScale();
            }
            butRect.y += height + 20;

			if(GUI.Button (butRect, "Zurück") || Input.GetKeyDown(KeyCode.Escape))
				ToggleTimeScale();
        }
        else
        {
            if (!isMenu && inMenuRadius)
            {
                if (control.vodkaStatus && drinkLogic.diedInFire)
                {
                    GUI.Button(new Rect(Screen.width - width, 0, width, height), "Drücke \"E\" um den \nVodka zu trinken");
                }
                else
                {
                    GUI.Button(new Rect(Screen.width - width, 0, width, height), "Drücke \"F\" um das \nPilzeriamenu zu öffnen");
                }
            }
        }

        if (control.vodkaStatus)
        {
            GUI.Button(new Rect(Screen.width / 3, 0, width, height), "Norbert hat Vodka");
        }
        else if (control.drankStatus)
        {
            GUI.Button(new Rect(Screen.width / 3, 0, width, height), "Norbert ist betrunken");
        }
	}

	//substracts money
	void pay (int amount) {
		int OldAmount = moneyManagement.getCurrentMoney ();
		moneyManagement.setCurrentMoney (OldAmount - amount);
		//moneyManagement.updateMoneyView ();
	}

	//stops game
	void ToggleTimeScale()
	{
		if (!isMenu)
				Time.timeScale = 0;
		else
				Time.timeScale = 1;
		isMenu = !isMenu;
	}
}
