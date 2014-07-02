using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    private string firstLevel = "BasicMovement";

	void OnGUI(){
        if (GUI.Button(new Rect(15, 15, 200, 100), "New Game"))
        {
            PlayerPrefs.DeleteAll();
            LoadScene.resetLoadNum();
            Application.LoadLevel(firstLevel);
        }

        if (GUI.Button(new Rect(15, 130, 200, 100), "Load Last"))
        {
            if (PlayerPrefs.HasKey("GameSaved"))
            {
                Application.LoadLevel(PlayerPrefs.GetString("SceneToLoad"));
            }
        }
    }
}
