using UnityEngine;
using System.Collections;

public class PilzeriaMenu : MonoBehaviour {

	private bool isMenu = false;
	private Rect butRect;
	private float width = 160;
	private float height = 30;


	// Use this for initialization
	void Start () {
		butRect = new Rect ((Screen.width - width) / 2, 0, width, height);
	}

	void OnTriggerStay (Collider other) {
		if (Input.GetKeyDown (KeyCode.F))
			ToggleTimeScale ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	//create menu buttons
	void OnGUI()
	{
		MoneyManagement moneyManagement = GetComponent<MoneyManagement>();
		if (isMenu) {
			butRect.y = (Screen.height - height)/2 - 60;

			if(GUI.Button (butRect, "Double Jump - $50"))
			{
				if(moneyManagement.getCurrentMoney() > 49)
				{
					pay(50);
					//enable double jump
				}
				ToggleTimeScale();
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

			if(GUI.Button (butRect, "Zurück"))
				ToggleTimeScale();
		}
	}

	//substracts money
	void pay (int amount) {
		MoneyManagement moneyManagement = GetComponent<MoneyManagement>();
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
