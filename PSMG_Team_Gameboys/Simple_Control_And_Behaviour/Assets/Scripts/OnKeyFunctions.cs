using UnityEngine;
using System.Collections;

public class OnKeyFunctions : MonoBehaviour {

    public static bool OnKeyDownPositive(string axis){
        if (Input.GetAxis(axis) > 0)
        {
            return true;
        }
        return false;
    }

    public static bool OnKeyDownNegative(string axis)
    {
        if (Input.GetAxis(axis) < 0)
        {
            return true;
        }
        return false;
    }

    public static bool OnKeyUp(string axis){
        if (Input.GetAxis(axis) == 0)
        {
            return true;
        }
        return false;
    }
}
