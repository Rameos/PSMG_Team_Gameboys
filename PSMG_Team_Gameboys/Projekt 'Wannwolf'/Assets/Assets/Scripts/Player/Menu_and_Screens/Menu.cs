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

    void startCalibration()
    {
        if (!isCalibrated)
        {
            if (gazeModel.posGazeRight.x != 0 && gazeModel.posGazeRight.y != 0)
            {
                isCalibrated = true;
                Calibration.calibrate();
            }

        }
    }
}