using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

 
	void OnGUI(){
        if (GUI.Button(new Rect(550, 115, 200, 100), "New Game"))
        {
            LoadScene.loadFirstLevel();
        }

        if (GUI.Button(new Rect(550, 230, 200, 100), "Load Last"))
        {
            if (PlayerPrefs.HasKey("GameSaved"))
            {
                LoadScene.loadLastGame();
            }
        }
        if (GUI.Button(new Rect(550, 345, 200, 100), "Quit Game"))
        {
            Application.Quit();
        }
    }
}