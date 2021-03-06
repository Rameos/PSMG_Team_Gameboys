﻿using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    private string newGame = "Neues Spiel";
    private string loadLast = "Letztes Spiel laden";
    private string gameSaved = "GameSaved";
    private string quit = "Spiel beenden";

    private bool isCalibrated = false;
  
    public GUIStyle customButton;

    void Update()
    {
        if (!Screen.showCursor)
        {
            Screen.showCursor = true;
        }
    }

	void OnGUI(){
        if (GUI.Button(new Rect(550, 100, 200, 100), newGame, customButton))
        {
            startCalibration();
            LoadScene.loadFirstLevel();
        }
        
        if (GUI.Button(new Rect(550, 250, 200, 100), loadLast, customButton))
        {
            if (PlayerPrefs.HasKey(gameSaved))
            {
                startCalibration();
                LoadScene.loadLastGame();
            }
        }
        if (GUI.Button(new Rect(550, 400, 200, 100), quit, customButton))
        {
            Application.Quit();
        }
    }

    //starts the calibration when a player starts/loads a game
    void startCalibration()
    {
        if (!isCalibrated)
        {
            isCalibrated = true;
            Calibration.calibrate();
        }
    }
}