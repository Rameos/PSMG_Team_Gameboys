using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using iViewX;

public class GameMenu : MonoBehaviour {

    private bool isPaused;
    private float width;
    private float height;
    private bool showSave = false;
    private bool allSoundsDisabled;
    //private AudioSource gameMusic;

    private string keepPlaying = "Weiterspielen";
    private string soundOn = "Ton anschalten";
    private string soundOff = "Ton ausschalten";
    private string newGame = "Neues Spiel";
    private string save = "Speichern";
    private string calibrate = "Kalibrieren";
    private string quit = "Beenden";
    private string gameSaved = "Spiel gespeichert";



    // Game menu button values
    private float BUTTON_WIDTH = 150;
    private float BUTTON_HEIGHT = 50;

    private GUIStyle center;

    void Awake()
    {
        //gameMusic = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<AudioSource>().audio;
        //gameMusic.ignoreListenerPause = true;
        width = Screen.width;
        height = Screen.height;
        isPaused = false;
        allSoundsDisabled = false;
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
            if (GUI.Button(new Rect((width - BUTTON_WIDTH) / 2, height / 2 - 150, BUTTON_WIDTH, BUTTON_HEIGHT), keepPlaying))
            {
                toggleTimeScale();
                toggleAudioListener();
            }

            // Sound on/off button
            if (allSoundsDisabled)
            {
                if (GUI.Button(new Rect((width - BUTTON_WIDTH) / 2, height / 2 - 75, BUTTON_WIDTH, BUTTON_HEIGHT), soundOn))
                {

                    // Mute/Unmute all ingame sounds
                    if (allSoundsDisabled)
                    {
                        allSoundsDisabled = false;
                        AudioListener.pause = false;
                    }
                    else
                    {
                        allSoundsDisabled = true;
                        AudioListener.pause = true;
                    }
                }
            }
            else
            {
                if (GUI.Button(new Rect((width - BUTTON_WIDTH) / 2, height / 2 - 75, BUTTON_WIDTH, BUTTON_HEIGHT), soundOff))
                {

                    // Mute/Unmute all ingame sounds
                    if (allSoundsDisabled)
                    {
                        allSoundsDisabled = false;
                        AudioListener.pause = false;
                    }
                    else
                    {
                        allSoundsDisabled = true;
                        AudioListener.pause = true;
                    }
                }
            }

            // Button to start a new game
            if (GUI.Button(new Rect((width - BUTTON_WIDTH) / 2, height / 2, BUTTON_WIDTH, BUTTON_HEIGHT), newGame))
            {
                toggleTimeScale();
                toggleAudioListener();
                LoadScene.loadFirstLevel();
            }

            // Save button
            if (GUI.Button(new Rect((width - BUTTON_WIDTH) / 2, height / 2 + 75, BUTTON_WIDTH, BUTTON_HEIGHT), save))
            {
                Save.saveGame();
                StartCoroutine(showSaveStatus());
                
            }

            // Starts the eyetracker calibration
            if (GUI.Button(new Rect((width - BUTTON_WIDTH) / 2, height / 2 + 150, BUTTON_WIDTH, BUTTON_HEIGHT), calibrate))
            {
                toggleTimeScale();
                toggleAudioListener();
                Calibration.calibrate();
            }

            // Close button
            if (GUI.Button(new Rect((width - BUTTON_WIDTH) / 2, height / 2 + 225, BUTTON_WIDTH, BUTTON_HEIGHT), quit))
            {
                LoadScene.loadMainMenu();
                toggleTimeScale();
            }

            // If the game was saved the message "Spiel gespeichert" appears
            if (showSave)
            {
                center = new GUIStyle(GUI.skin.textField);
                center.alignment = TextAnchor.MiddleCenter;
                GUI.color = Color.green; 
                GUI.TextField(new Rect((width - 120) / 2, (float)(Screen.height * 0.1), 120, 50),gameSaved, center);
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
            Screen.showCursor = true; // Show mouse cursor while in game menu
        }
        else
        {
            setPlayerControlStatus = true;
            setCameraControlStatus = true;
            Time.timeScale = 1.0f;
            Screen.showCursor = false; // Hide mouse cursor ingame
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
            if (!allSoundsDisabled)
            {
                AudioListener.pause = false;
            }
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
