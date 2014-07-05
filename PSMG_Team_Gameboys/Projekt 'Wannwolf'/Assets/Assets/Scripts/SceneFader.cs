using UnityEngine;
using System.Collections;

public class SceneFader : MonoBehaviour {

    public Texture2D texture;

    private float fadeSpeed;
    private string nextLevel;
    private Rect screenRect;
    private Color currentColor;
    private bool isStarting;
    private bool isEnding;

    void Awake()
    {
        fadeSpeed = 1.0f;
        isStarting = true;
        isEnding = false;
        screenRect = new Rect(0, 0, Screen.width, Screen.height);
        currentColor = Color.black;
    }
	
	// Update is called once per frame
	void Update () {
        if (isStarting)
        {
            fadeIn();
        }
        if (isEnding)
        {
            fadeOut();
        }
	}

    void OnGUI()
    {
        if (isStarting || isEnding)
        {
            GUI.depth = 0;
            GUI.color = currentColor;
            GUI.DrawTexture(screenRect, texture, ScaleMode.StretchToFill);
        }
    }

    void fadeIn()
    {
        currentColor = Color.Lerp(currentColor, Color.clear, fadeSpeed * Time.deltaTime);

        if (currentColor.a <= 0.05f)
        {
            currentColor = Color.clear;
            isStarting = false;
        }
    }

    void fadeOut()
    {
        currentColor = Color.Lerp(currentColor, Color.black, fadeSpeed * Time.deltaTime);

        if(currentColor.a >= 0.95f){
            currentColor.a = 1f;
            Application.LoadLevel(nextLevel);
        }
    }

    public void switchScene(string nextSceneString)
    {
        nextLevel = nextSceneString;
        isEnding = true;
        isStarting = false;
    }
}
