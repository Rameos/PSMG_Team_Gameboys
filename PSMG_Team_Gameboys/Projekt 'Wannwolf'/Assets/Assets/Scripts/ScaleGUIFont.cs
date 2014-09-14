using UnityEngine;
using System.Collections;

public class ScaleGUIFont : MonoBehaviour {

    public int ratio;
    public GUIText text;

    void Update()
    {
		// Scale the font size in relation to the screen resolution
        text.fontSize = Mathf.Min(Screen.width, Screen.height) / ratio;
    }
}
