using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using iViewX;

public class Calibration : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width * 0.5f, Screen.height * 0.0f, Screen.width * 0.1f, Screen.height * 0.1f), "Start Calibration"))
            GazeControlComponent.Instance.StartCalibration();
    }
}
