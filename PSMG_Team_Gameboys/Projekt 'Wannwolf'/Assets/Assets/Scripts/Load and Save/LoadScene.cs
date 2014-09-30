using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    private static SceneFader sceneFader;
    private static string[] levels = new string[5] {"IntroComic", "TutorialRight", "BasicMovement", "Escape_Level_Basic", "outro"};
    private static string mainMenu = "load_test_scene";
    private static int loadNum = 0;

    void Awake()
    {
        sceneFader = GetComponent<SceneFader>();
    }

    public static void loadScene()
    {
        sceneFader.switchScene(levels[loadNum]);
        increaseLoadNum();
    }

    public static void loadLastGame()
    {
        sceneFader.switchScene(PlayerPrefs.GetString("SceneToLoad"));
    }

    public static void loadEscapeLevel()
    {
        sceneFader.switchScene(levels[3]);
    }

    public static void loadFirstLevel()
    {
        resetLoadNum();
        PlayerPrefs.DeleteAll();
        sceneFader.switchScene(levels[loadNum]);
        increaseLoadNum();
    }

    public static void loadBM()
    {
        loadNum = 2;
        PlayerPrefs.DeleteAll();
        sceneFader.switchScene(levels[loadNum]);
    }

    public static void loadMainMenu()
    {
        sceneFader.switchScene(mainMenu);
    }

   static void resetLoadNum()
    {
        loadNum = 0;
    }

   static void increaseLoadNum()
   {
       if (loadNum < levels.Length - 1)
       {
           loadNum++;
       }
   }
}

