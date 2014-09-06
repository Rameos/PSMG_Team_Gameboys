using UnityEngine;
using System.Collections;

public class LoadHelper : MonoBehaviour {

    public void LoadBasicMovement()
    {
        animation.Stop();
        LoadScene.loadScene();
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadBasicMovement();
        }
	}
}
