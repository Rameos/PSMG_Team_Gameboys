using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    private static string firstLevel = "BasicMovement";
    private static LoadScene loadScene;
    private SceneFader sceneFader;

    void Awake()
    {
        sceneFader = GetComponent<SceneFader>();
        loadScene = GetComponent<LoadScene>();
    }

	void OnGUI(){
        if (GUI.Button(new Rect(15, 15, 200, 100), "New Game"))
        {
            loadFirstLevel();
        }

        if (GUI.Button(new Rect(15, 130, 200, 100), "Load Last"))
        {
            if (PlayerPrefs.HasKey("GameSaved"))
            {
                sceneFader.switchScene(PlayerPrefs.GetString("SceneToLoad"));
            }
        }
    }

    public static void loadFirstLevel()
    {
        PlayerPrefs.DeleteAll();
        LoadScene.resetLoadNum();
        loadScene.loadScene();
    }
}
