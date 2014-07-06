using UnityEngine;
using System.Collections;

public class LoadGameSetings : MonoBehaviour {

    void Awake()
    {
        if (PlayerPrefsX.GetBool("GameSaved") && PlayerPrefs.GetString("SceneToLoad").Equals(Application.loadedLevelName))
        {
            loadPlayer();
            //loadBierber();
            //loadBier();
            //loadPizza();
        }
    }

    void loadPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = PlayerPrefsX.GetVector3("PlayerPosition");
        player.transform.rotation = PlayerPrefsX.GetQuaternion("PlayerRotation");
    }

    void loadBierber()
    {
        GameObject bierber = GameObject.FindGameObjectWithTag("Bierber");
        bierber.transform.position = PlayerPrefsX.GetVector3("BierberPosition");
        bierber.transform.rotation = PlayerPrefsX.GetQuaternion("BierberRotation");
    }

    void loadBier()
    {
        GameObject bier = GameObject.FindGameObjectWithTag("Bier");
        bier.transform.position = PlayerPrefsX.GetVector3("BierPosition");
        bier.transform.rotation = PlayerPrefsX.GetQuaternion("BierRotation");
    }

    void loadPizza()
    {
        Vector3[] pizzaPositions = PlayerPrefsX.GetVector3Array("PizzaPositions");
        Quaternion[] pizzaRotations = PlayerPrefsX.GetQuaternionArray("PizzaRotations");
        for (int i = 0; i < pizzaPositions.Length; i++)
        {
            GameObject pizza = GameObject.FindGameObjectWithTag("Pizza");
            pizza.transform.position = pizzaPositions[i];
            pizza.transform.rotation = pizzaRotations[i];
        }
    }
}
