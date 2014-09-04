using UnityEngine;
using System.Collections;

public class ScaleGUIFont : MonoBehaviour {

    public int ratio;
    public GUIText text;

    void Update()
    {
        text.fontSize = Mathf.Min(Screen.width, Screen.height) / ratio;
    }
}
