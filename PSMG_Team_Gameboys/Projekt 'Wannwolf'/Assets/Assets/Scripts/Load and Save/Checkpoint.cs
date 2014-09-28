using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    private bool gameSaved;
    private bool firstTimeOnCheckpoint;

    private string savedGame = "Spiel automatisch gespeichert";

    private GUIStyle center;



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


    //if the player reaches a checkpoint, the message "Spiel automatisch gespeichert" appears
    void OnGUI()
    {
        if (gameSaved)
        {
            center = new GUIStyle(GUI.skin.textField);
            center.alignment = TextAnchor.MiddleCenter;
            GUI.TextField(new Rect((Screen.width - 200) / 2, (float)(Screen.height * 0.2), 200, 50), "Spiel automatisch gespeichert" , center);
        }
    }




}
