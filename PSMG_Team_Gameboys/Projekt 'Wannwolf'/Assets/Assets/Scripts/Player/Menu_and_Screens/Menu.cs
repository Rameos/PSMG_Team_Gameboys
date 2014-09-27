using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    private bool isCalibrated = false;
 

	void OnGUI(){
        if (GUI.Button(new Rect(550, 115, 200, 100), "New Game"))
        {
            startCalibration();
            LoadScene.loadFirstLevel();
        }

        if (GUI.Button(new Rect(550, 230, 200, 100), "Load Last"))
        {
            if (PlayerPrefs.HasKey("GameSaved"))
            {
                startCalibration();
                LoadScene.loadLastGame();
            }
        }
        if (GUI.Button(new Rect(550, 345, 200, 100), "Quit Game"))
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