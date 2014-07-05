using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    private SceneFader sceneFader;
    private string[] levels = new string[3] {"BasicMovement", "Escape_Level_Basic", "BasicMovement"};
    private static int loadNum = 0;

    // Use this for initialization
    void Awake()
    {
        sceneFader = GetComponent<SceneFader>();
    }

    public void loadScene()
    {
        sceneFader.switchScene(levels[loadNum]);
        increaseLoadNum();
    }

    void increaseLoadNum()
    {
        if (loadNum < levels.Length - 1)
        {
            loadNum++;
        }
    }

    public static void resetLoadNum()
    {
        loadNum = 0;
    }
}

