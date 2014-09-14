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
            GUI.Button(new Rect((Screen.width - 200) / 2, (float)(Screen.height * 0.7), 200, 50), "Spiel automatisch gespeichert");
        }
    }




}
