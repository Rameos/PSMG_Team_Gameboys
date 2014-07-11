using UnityEngine;
using System.Collections;

public class EscapeCountdown : MonoBehaviour
{
    private float waitForCountdown = 1.8f;

    private float countdown;
    private bool startCountdown;

    void Awake()
    {
        countdown = 5;
        startCountdown = false;
        StartCoroutine(wait());
    }

    void OnGUI()
    {
        if (startCountdown == true)
        {
            countdown -= Time.fixedDeltaTime;
            if (countdown > 0)
            {
                GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 5, Screen.height / 2), countdown.ToString("0"));
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
