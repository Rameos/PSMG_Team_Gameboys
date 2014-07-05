using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {

    private bool isPaused;
    private float width;
    private float height;

    void Awake()
    {
        width = Screen.width;
        height = Screen.height;
        isPaused = false;
    }

   void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggleTimeScale();
            toggleAudioListener();
        }
    }

    void OnGUI()
    {
        if (isPaused)
        {
            if (GUI.Button(new Rect((width-100)/2, height/2, 100, 50), "Resume"))
            {
                toggleTimeScale();
                toggleAudioListener();
            }

            if (GUI.Button(new Rect((width-100)/2, height/2 + 75, 100, 50), "New Game"))
            {
                toggleTimeScale();
                toggleAudioListener();
                Menu.loadFirstLevel();
            }

            if (GUI.Button(new Rect((width-100)/2, height/2 + 150, 100, 50), "Save Game"))
            {
                Save.saveGame();
            }

            if (GUI.Button(new Rect((width-100)/2, height/2 + 225, 100, 50), "Exit Game"))
            {
                Application.Quit();
            }
        }
    }

    void toggleTimeScale()
    {
        if (!isPaused)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
        isPaused = !isPaused;
    }

    void toggleAudioListener()
    {
        if(isPaused){
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = false;
        }
    }
}
