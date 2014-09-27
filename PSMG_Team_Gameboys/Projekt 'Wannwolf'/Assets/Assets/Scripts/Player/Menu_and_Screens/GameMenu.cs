using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using iViewX;

public class GameMenu : MonoBehaviour {

    private bool isPaused;
    private float width;
    private float height;
    private bool showSave = false;
    //private AudioSource gameMusic;

    void Awake()
    {
        //gameMusic = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<AudioSource>().audio;
        //gameMusic.ignoreListenerPause = true;
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

            // Show cursor while game menu is opened
            if (!Screen.showCursor)
            {
                Screen.showCursor = true;
            }
            else
            {
                Screen.showCursor = false;
            }
        }
    }

    void OnGUI()
    {
        if (isPaused)
        {
            if (GUI.Button(new Rect((width-100)/2, height/2 - 75, 100, 50), "Weiterspielen"))
            {
                toggleTimeScale();
                toggleAudioListener();
            }

            if (GUI.Button(new Rect((width-100)/2, height/2, 100, 50), "Neues Spiel"))
            {
                toggleTimeScale();
                toggleAudioListener();
                LoadScene.loadFirstLevel();
            }

            if (GUI.Button(new Rect((width-100)/2, height/2 + 75, 100, 50), "Speichern"))
            {
                Save.saveGame();
                StartCoroutine(showSaveStatus());
                
            }

            //starts the eyetracker calibration
            if (GUI.Button(new Rect((width-100)/2, height/2 + 150, 100, 50), "Kalibrieren"))
            {
                toggleTimeScale();
                toggleAudioListener();
                Calibration.calibrate();
            }

            if (GUI.Button(new Rect((width - 100) / 2, height / 2 + 225, 100, 50), "Beenden"))
            {
                LoadScene.loadMainMenu();
                toggleTimeScale();
            }

            //if the game was saved the message "Spiel gespeichert" appears
            if (showSave)
            {
                GUI.color = Color.green; 
                GUI.Button(new Rect((width - 120) / 2, (float)(Screen.height * 0.2), 120, 50), "Spiel gespeichert");
            }
        }

        
    }
    

    //the "Spiel gespeichert" message disappears after 2 seconds
    IEnumerator showSaveStatus()
    {
        showSave = true;
        yield return new WaitForSeconds(2);
        showSave = false;
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
