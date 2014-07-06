using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    private static string firstLevel = "BasicMovement";

	void OnGUI(){
        if (GUI.Button(new Rect(15, 15, 100, 50), "New Game"))
        {
            LoadScene.loadFirstLevel();
        }

        if (GUI.Button(new Rect(15, 130, 100, 50), "Load Last"))
        {
            if (PlayerPrefs.HasKey("GameSaved"))
            {
                LoadScene.loadSavedGame();
            }
        }

        if (GUI.Button(new Rect(15, 245, 100, 50), "Quit Game"))
        {
            Application.Quit();
        }
    }
}
