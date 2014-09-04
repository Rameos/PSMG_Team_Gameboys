using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {

    private bool isPaused;
    private float width;
    private float height;
   private AudioSource gameMusic;

    void Awake()
    {
        gameMusic = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<AudioSource>().audio;
        gameMusic.ignoreListenerPause = true;
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
                LoadScene.loadFirstLevel();
            }

            if (GUI.Button(new Rect((width-100)/2, height/2 + 150, 100, 50), "Save Game"))
            {
                Save.saveGame();
            }

            if (GUI.Button(new Rect((width-100)/2, height/2 + 225, 100, 50), "Quit"))
            {
                LoadScene.loadMainMenu();
                toggleTimeScale();
            }
        }
    }

    void toggleTimeScale()
    {
        if (!isPaused)
        {
            setPlayerControlStatus = false;
            setCameraControlStatus = false;
            Time.timeScale = 0.0f;
        }
        else
        {
            setPlayerControlStatus = true;
            setCameraControlStatus = true;
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

    bool setPlayerControlStatus
    {
        set {GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<PlayerControl>().enabled = value;}
    }

    bool setCameraControlStatus
    {
        set { GameObject.FindGameObjectWithTag(TagManager.MAIN_CAMERA).GetComponent<CameraControl>().enabled = value; }
    }

    public bool gameMenuStatus
    {
        get { return isPaused; }
    }
}
