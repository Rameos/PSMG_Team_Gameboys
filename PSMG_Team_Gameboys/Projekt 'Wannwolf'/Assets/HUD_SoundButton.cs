using UnityEngine;
using System.Collections;

public class HUD_SoundButton : MonoBehaviour {

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 130, Screen.height/60, Screen.width / 40, Screen.height / 18), ""))
        {
            // Mute all ingame sounds
            if (AudioListener.pause)
            {
                AudioListener.pause = false;
            }
            else
            {
                AudioListener.pause = true;
            }
        }
    }
}
