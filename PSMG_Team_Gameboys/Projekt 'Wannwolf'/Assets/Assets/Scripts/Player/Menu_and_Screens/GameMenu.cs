using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using iViewX;

public class GameMenu : MonoBehaviour {

    private bool isPaused;
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
    private float width;
    private float height;
    private float buttonWidth;
    private float buttonHeight;
    private float buttonDistance;

    private GUIStyle center;
    private GUIStyle fontStyle;
    public Font font;

    void Awake()
    {
        //gameMusic = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<AudioSource>().audio;
        //gameMusic.ignoreListenerPause = true;

        width = Screen.width;
        height = Screen.height;
        buttonWidth = width / 10;
        buttonHeight = height / 15;
        buttonDistance = height / 12;

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
        fontStyle = new GUIStyle(GUI.skin.button);
        fontStyle.font = font;
        fontStyle.alignment = TextAnchor.MiddleCenter;

        if (isPaused)
        {
            if (GUI.Button(new Rect((width - buttonWidth) / 2, height / 2 - 2 * buttonDistance, buttonWidth, buttonHeight), keepPlaying, fontStyle))
            {
                toggleTimeScale();
                toggleAudioListener();
            }

            // Sound on/off button
            if (allSoundsDisabled)
            {
                if (GUI.Button(new Rect((width - buttonWidth) / 2, height / 2 - buttonDistance, buttonWidth, buttonHeight), soundOn, fontStyle))
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
                if (GUI.Button(new Rect((width - buttonWidth) / 2, height / 2 - buttonDistance, buttonWidth, buttonHeight), soundOff, fontStyle))
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
            if (GUI.Button(new Rect((width - buttonWidth) / 2, height / 2, buttonWidth, buttonHeight), newGame, fontStyle))
            {
                toggleTimeScale();
                toggleAudioListener();
                LoadScene.loadFirstLevel();
            }

            // Save button
            if (GUI.Button(new Rect((width - buttonWidth) / 2, height / 2 + buttonDistance, buttonWidth, buttonHeight), save, fontStyle))
            {
                Save.saveGame();
                StartCoroutine(showSaveStatus());
                
            }

            // Starts the eyetracker calibration
            if (GUI.Button(new Rect((width - buttonWidth) / 2, height / 2 + 2 * buttonDistance, buttonWidth, buttonHeight), calibrate, fontStyle))
            {
                toggleTimeScale();
                toggleAudioListener();
                Calibration.calibrate();
            }

            // Close button
            if (GUI.Button(new Rect((width - buttonWidth) / 2, height / 2 + 3 * buttonDistance, buttonWidth, buttonHeight), quit, fontStyle))
            {
                LoadScene.loadMainMenu();
                toggleTimeScale();
            }

            // If the game was saved the message "Spiel gespeichert" appears
            if (showSave)
            {
                center = new GUIStyle(GUI.skin.textField);
                center.alignment = TextAnchor.MiddleCenter;
                center.font = font;

                GUI.color = Color.green;
                GUI.TextField(new Rect((width - buttonWidth) / 2, (float)(height * 0.1), buttonWidth, buttonHeight), gameSaved, center);
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
