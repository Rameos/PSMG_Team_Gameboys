using UnityEngine;
using System.Collections;

public class LoadList : MonoBehaviour{
    
    private static string[] loadList = new string[2]{"BasicMovement", "Escape_Level_Basic"};
    private static int loadNum = 0;

    public static string getLoadString()
    {
        return loadList[loadNum];
    }

    public static void increaseLoadNum()
    {
        loadNum++;
    }

    public static int getLoadNumber(){
        return loadNum;
    }

}
