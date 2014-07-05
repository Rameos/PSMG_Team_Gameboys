using UnityEngine;
using System.Collections;

public class Save : MonoBehaviour {

    private const string playerPosition = "PlayerPosition";
    private const string playerRotation = "PlayerRotation";
    private const string playerMoney = "PlayerMoney";

    private const string bierberPosition = "BierberPosition";
    private const string bierberRotation = "BierberRotation";
    private const string bierberRendered = "BierberRendered";

    private const string bierPosition = "BierPosition";
    private const string bierRotation = "BierRotation";

    private const string pizzaPositions = "PizzaPositions";
    private const string pizzaRotations = "PizzaRotations";

    public static void saveGame()
    {
        saveScene();
        savePlayer();
        saveBierber();
        //saveBier();
        //savePizza();
        PlayerPrefs.Save();
    }

   static void saveScene()
    {
        PlayerPrefs.SetString("SceneToLoad", Application.loadedLevelName);
        PlayerPrefsX.SetBool("GameSaved", true);
    }

   static void savePlayer()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerPrefsX.SetVector3("PlayerPosition", player.transform.position);
            PlayerPrefsX.SetQuaternion("PlayerRotation", player.transform.rotation);
        }
    }

   static void saveBierber()
    {
       if(GameObject.FindGameObjectWithTag("Bierber") !=null)
       {
            GameObject bierber = GameObject.FindGameObjectWithTag("Bierber");
            PlayerPrefsX.SetVector3(bierberPosition, bierber.transform.position);
            PlayerPrefsX.SetQuaternion(bierberRotation, bierber.transform.rotation);
       }
    }

   static void saveBierberWallStatus()
   {

   }

   static void saveTreeStatus()
   {

   }

   static void saveBier()
    {
        if(GameObject.FindGameObjectWithTag("Bier") !=null)
        {
            GameObject bier = GameObject.FindGameObjectWithTag("Bier");
            PlayerPrefsX.SetVector3(bierPosition, bier.transform.position);
            PlayerPrefsX.SetQuaternion(bierRotation, bier.transform.rotation);
        }
    }

    static void savePizza()
    {
        if (GameObject.FindGameObjectWithTag("Pizza") != null)
        {
            GameObject[] pizzas = GameObject.FindGameObjectsWithTag("Pizza");
            Vector3[] pizzaPos = new Vector3[pizzas.Length];
            Quaternion[] pizzaRot = new Quaternion[pizzas.Length];
            for (int i = 0; i < pizzas.Length; i++)
            {
                pizzaPos[i] = pizzas[i].transform.position;
                pizzaRot[i] = pizzas[i].transform.rotation;
            }
            PlayerPrefsX.SetVector3Array(pizzaPositions, pizzaPos);
            PlayerPrefsX.SetQuaternionArray(pizzaRotations, pizzaRot);
        }
    }
}
