using UnityEngine;
using System.Collections;

public class Loadscreen : MonoBehaviour {

    private const string loadScreen = "Matze_Debug_Level";
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
        if (col.gameObject.tag == "Player")
        {
            Application.LoadLevel(loadScreen);
        }
    }
}
