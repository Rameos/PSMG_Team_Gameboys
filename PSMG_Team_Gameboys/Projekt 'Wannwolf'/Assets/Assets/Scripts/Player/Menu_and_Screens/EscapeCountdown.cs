using UnityEngine;
using System.Collections;

public class EscapeCountdown : MonoBehaviour
{
    private float waitForCountdown = 1.8f;

    private float countdown;
    private bool startCountdown;

    public Font font;
    public int fontSize;
    private GUIStyle style;

    void Awake()
    {
        countdown = 5;
        startCountdown = false;
        StartCoroutine(wait());
        style = new GUIStyle();
        style.font = font;
        style.fontSize = fontSize;
    }

    void OnGUI()
    {
        if (startCountdown == true)
        {
            countdown -= Time.fixedDeltaTime;
            if (countdown > 0)
            {
                GUI.Box(new Rect(Screen.width / 2 - Screen.width / 18, Screen.height / 2, Screen.width / 9, Screen.height / 9), countdown.ToString("0"), style);
            }
            else
            {
                Time.timeScale = 1.0f;
                startCountdown = false;
            }
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(waitForCountdown);
        Time.timeScale = 0.0f;
        startCountdown = true;
    }
}
