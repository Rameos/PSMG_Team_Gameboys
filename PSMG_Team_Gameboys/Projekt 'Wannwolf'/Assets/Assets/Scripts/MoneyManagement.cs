using UnityEngine;
using System.Collections;

public class MoneyManagement : MonoBehaviour {
	
	// Instance variables
	int moneyMinimum;
	int moneyMaximum;
	int currentMoney;
	public GUIText moneyText;
	
	// Initialize instance variables
	void Start () {
		moneyMinimum = 0;
		moneyMaximum = 100;
		currentMoney = moneyMaximum;
		updateGuiText();
	}
	
	// Update current money once per frame
	void Update () {
		
		// Set current money to the minimum/maximum whenever it exceeds these values
		if (currentMoney < moneyMinimum) { currentMoney = moneyMinimum; }
		if (currentMoney > moneyMaximum) { currentMoney = moneyMaximum; }
		updateGuiText();
	}
	
	// Update the money shown in the GUI
	void updateGuiText()
	{
		moneyText.text = currentMoney.ToString();
	}
	
	// Add Money to current money 
	public void addMoney(int value) { currentMoney += value; }
	
	// Subtract money from current money
	public void subtractMoney(int value) { currentMoney -= value; }
	
}
