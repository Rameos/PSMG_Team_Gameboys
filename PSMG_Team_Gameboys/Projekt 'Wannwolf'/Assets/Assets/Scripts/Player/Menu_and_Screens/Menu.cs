using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    private bool isCalibrated = false;

    private string newGame = "Neues Spiel";
    private string loadLast = "Letztes Spiel laden";
    private string gameSaved = "GameSaved";
    private string quit = "Spiel beenden";

    private GUIStyle fontStyle;
    public Font font;

    void Update()
    {
        if (!Screen.showCursor)
        {
            Screen.showCursor = true;
        }
    }

	void OnGUI(){
        fontStyle = new GUIStyle(GUI.skin.button);
        fontStyle.font = font;
        fontStyle.alignment = TextAnchor.MiddleCenter;

        if (GUI.Button(new Rect(550, 115, 200, 100), newGame, fontStyle))
        {
            startCalibration();
            LoadScene.loadFirstLevel();
        }

        if (GUI.Button(new Rect(550, 230, 200, 100), loadLast, fontStyle))
        {
            if (PlayerPrefs.HasKey(gameSaved))
            {
                startCalibration();
                LoadScene.loadLastGame();
            }
        }
        if (GUI.Button(new Rect(550, 345, 200, 100), quit, fontStyle))
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