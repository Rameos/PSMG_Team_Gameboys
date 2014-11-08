using UnityEngine;
using System.Collections;

public class ReturnToMainMenu : MonoBehaviour {

    public void returnToMainMenu()
    {
        LoadScene.loadMainMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadScene.loadMainMenu();
        }
    }
}
