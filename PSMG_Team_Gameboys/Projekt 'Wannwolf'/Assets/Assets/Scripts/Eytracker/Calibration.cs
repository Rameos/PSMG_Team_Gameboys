using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using iViewX;

public class Calibration : MonoBehaviour
{
    //starts calibration
    public static void calibrate()
    {
        GazeControlComponent.Instance.StartCalibration();
    }
}
