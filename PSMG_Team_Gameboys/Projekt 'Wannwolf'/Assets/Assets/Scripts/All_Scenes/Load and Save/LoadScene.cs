using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    private string[] levels = new string[2] {"Escape_Level_Basic", "BasicMovement"};
    private static int loadNum = 0;

    // Use this for initialization
    void Awake()
    {   
        StartCoroutine(load());
    }

    IEnumerator load()
    {
        yield return new WaitForSeconds(10);
        Application.LoadLevel(levels[loadNum]);
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

