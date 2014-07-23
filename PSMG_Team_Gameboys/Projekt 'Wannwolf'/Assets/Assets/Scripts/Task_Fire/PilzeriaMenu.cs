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


	// Use this for initialization
	void Start () {
		butRect = new Rect ((Screen.width - width) / 2, 0, width, height);
        moneyManagement = GameObject.FindGameObjectWithTag("Player").GetComponent<MoneyManagement>();
        player = GameObject.Find("Player");
        control = player.GetComponent<PlayerControl>();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inMenuRadius = true;
        }
    }

	void OnTriggerStay (Collider other) {
		if (Input.GetKeyDown (KeyCode.F))
			ToggleTimeScale ();
	}

    void OnTriggerExit(Collider other)
    {
        inMenuRadius = false;
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
					//enable double jump
                    ToggleTimeScale();
				}
			}
			butRect.y += height + 20;

			if(GUI.Button (butRect, "Länger sprinten - $50"))
			{
				if(moneyManagement.getCurrentMoney() > 49)
				{
					pay(50);
					float currentTime = PlayerControl.getSprintTime();
					PlayerControl.setSprintTime(currentTime + 4f);
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

            if (GUI.Button(butRect, "Vodka"))
            {
                pay(5);
                control.hasVodka = true;
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
                GUI.Button(new Rect (Screen.width - width, 0, width, height), "Drücke \"F\" um das \nPilzeriamenu zu öffnen");
            }
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
