using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using iViewX;

public class Calibration : MonoBehaviour
{

    public static void calibrate()
    {
        Debug.Log("calibrate");
        GazeControlComponent.Instance.StartCalibration();
    }
}
