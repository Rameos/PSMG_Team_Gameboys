using UnityEngine;
using System.Collections;

public class LoadHelper : MonoBehaviour
{

    public void LoadBasicMovement()
    {
        LoadScene.loadBM();
    }

    public void LoadBasicTutorial()
    {
        animation.Stop();
        LoadScene.loadScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadBasicTutorial();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == TagManager.ESCAPE_TRIGGER)
        {
            LoadScene.loadEscapeLevel();
        }
    }
}
