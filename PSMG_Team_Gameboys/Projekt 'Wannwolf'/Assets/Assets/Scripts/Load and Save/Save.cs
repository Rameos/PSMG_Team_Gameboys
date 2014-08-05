using UnityEngine;
using System.Collections;

public class Save : MonoBehaviour
{

    private const string playerPosition = "PlayerPosition";
    private const string playerRotation = "PlayerRotation";
    private const string playerMoney = "PlayerMoney";

    private const string bierberPosition = "BierberPosition";
    private const string bierberRotation = "BierberRotation";
    private const string bierberBodyRendered = "BierberBodyRendered";
    private const string bierberHeadRendered = "BierberHeadRendered";

    private const string bierberInvisibleWall = "BierberInvisibleWall";

    private const string fallenTreeRendered = "FallenTreeRendered";

    private const string bierPosition = "BierPosition";
    private const string bierRotation = "BierRotation";

    private const string pizzaPositions = "PizzaPositions";
    private const string pizzaRotations = "PizzaRotations";

    public static void saveGame()
    {
        saveScene();
        savePlayer();
        saveBierber();
        saveBierberBody();
        saveBierberHead();
        saveTreeStatus();
        saveBierberWallStatus();
        saveBier();
        savePizza();
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
        if (GameObject.FindGameObjectWithTag("Bierber") != null)
        {
            GameObject bierber = GameObject.FindGameObjectWithTag("Bierber");
            PlayerPrefsX.SetVector3(bierberPosition, bierber.transform.position);
            PlayerPrefsX.SetQuaternion(bierberRotation, bierber.transform.rotation);
        }
    }

    static void saveBierberBody()
    {
        if (GameObject.FindGameObjectWithTag("BierberBody") != null)
        {
            GameObject bierberBody = GameObject.FindGameObjectWithTag("BierberBody");
            PlayerPrefsX.SetBool(bierberBodyRendered, bierberBody.renderer.enabled);
        }
    }

    static void saveBierberHead()
    {
        if (GameObject.FindGameObjectWithTag("BierberHead") != null)
        {
            GameObject bierberHead = GameObject.FindGameObjectWithTag("BierberHead");
            PlayerPrefsX.SetBool(bierberHeadRendered, bierberHead.renderer.enabled);
        }
    }

    static void saveBierberWallStatus()
    {
        if (GameObject.FindGameObjectWithTag("BierberInvisibleWall") != null)
        {
            GameObject invisibleWall = GameObject.FindGameObjectWithTag("BierberInvisibleWall");
            PlayerPrefsX.SetBool(bierberInvisibleWall, invisibleWall.collider.enabled);
        }
    }

    static void saveTreeStatus()
    {

        if (GameObject.FindGameObjectWithTag("FallenTree") != null)
        {
            GameObject fallenTree = GameObject.FindGameObjectWithTag("FallenTree");
            PlayerPrefsX.SetBool(fallenTreeRendered, fallenTree.renderer.enabled);
        }
    }

    static void saveBier()
    {
        if (GameObject.FindGameObjectWithTag("Beer") != null)
        {
            GameObject bier = GameObject.FindGameObjectWithTag("Beer");
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
