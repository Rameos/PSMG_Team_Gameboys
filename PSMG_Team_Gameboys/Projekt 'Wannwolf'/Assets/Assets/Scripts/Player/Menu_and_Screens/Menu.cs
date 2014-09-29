using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    private string newGame = "Neues Spiel";
    private string loadLast = "Letztes Spiel laden";
    private string gameSaved = "GameSaved";
    private string quit = "Spiel beenden";

    private GUIStyle fontStyle;
    public Font font;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    void Start()
    {
        //leave = GameObject.Find("LeaveButton");
    }

    void Update()
    {
        if (!Screen.showCursor)
        {
            Screen.showCursor = true;
        }
        showLeaves();
    }

    void showLeaves()
    {
        button1.transform.position = new Vector3(0.475f, 0.325f, 1f);
        button2.transform.position = new Vector3(0.475f, 0.525f, 1f);
        button3.transform.position = new Vector3(0.475f, 0.725f, 1f);
    }

	void OnGUI(){
        fontStyle = new GUIStyle(GUI.skin.button);
        fontStyle.font = font;
        fontStyle.alignment = TextAnchor.MiddleCenter;

       /* if (GUI.Button(new Rect(550, 115, 200, 100), newGame, fontStyle))
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
        * */
    }

    //starts the calibration when a player starts/loads a game
    
}