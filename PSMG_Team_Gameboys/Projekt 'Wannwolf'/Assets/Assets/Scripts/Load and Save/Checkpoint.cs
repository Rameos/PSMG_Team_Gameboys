using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    private bool gameSaved;
    private bool firstTimeOnCheckpoint;

    void Start()
    {
        firstTimeOnCheckpoint = true;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == TagManager.PLAYER && firstTimeOnCheckpoint)
        {
            Save.saveGame();
            gameSaved = true;
            firstTimeOnCheckpoint = false;
            Debug.LogWarning("Saved");
        }
    }

    void OnTriggerExit(Collider col)
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<Checkpoint>().enabled = false;
    }

    void OnGUI()
    {
        if (gameSaved)
        {
            GUI.Button(new Rect(Screen.width * 0.9f, 10, Screen.width / 10, Screen.height / 12), "Checkpoint");
        }
    }




}
