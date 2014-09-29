using UnityEngine;
using System.Collections;

public class Clicked : MonoBehaviour {

    private string gameSaved = "GameSaved";

    private bool isCalibrated = false;

	void Update () {

	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.tag == "NewGame")
            {
                //startCalibration();
                LoadScene.loadFirstLevel();
            }
            if (gameObject.tag == "LoadLast")
            {
                if (PlayerPrefs.HasKey(gameSaved))
                {
                    startCalibration();
                    LoadScene.loadLastGame();
                }
            }
            if (gameObject.tag == "NewGameQuit")
            {
                Application.Quit();
            }
        }
    }

    void startCalibration()
    {
        if (!isCalibrated)
        {
            isCalibrated = true;
            Calibration.calibrate();
        }
    }
}
