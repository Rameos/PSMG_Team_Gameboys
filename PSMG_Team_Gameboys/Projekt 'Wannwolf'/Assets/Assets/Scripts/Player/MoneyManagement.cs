﻿using UnityEngine;
using System.Collections;

public class MoneyManagement : MonoBehaviour {
	
	// Instance variables
	int moneyMinimum;
	int moneyMaximum;
    public int startMoney = 60;
	int currentMoney;
	public GUIText moneyText;

    // Initialize instance variables on gamestart
    void Awake()
    {
        init();

        if (!PlayerPrefs.HasKey("PlayerMoney"))
        {
            currentMoney = PlayerPrefs.GetInt("PlayerMoney");
        }
        else
        {
            currentMoney = startMoney;
        }
    }

    void init()
    {
        moneyMinimum = 0;
        moneyMaximum = 150;
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

    // Getter methods for instance variables
    public int getCurrentMoney() { return currentMoney; }    
    public int getMoneyMinimum() { return moneyMinimum; }    
    public int getMoneyMaximum() { return moneyMaximum; }

    // Setter methods for instance variables
    public void setCurrentMoney(int value) { currentMoney = value; }
	public void setMoneyMaximum(int newMax) { moneyMaximum = newMax; } 
	public void updateMoneyView (){ updateGuiText (); }



}
