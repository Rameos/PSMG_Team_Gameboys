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
        if (GameObject.FindGameObjectWithTag(TagManager.PLAYER) != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
            PlayerPrefsX.SetVector3(playerPosition, player.transform.position);
            PlayerPrefsX.SetQuaternion(playerRotation, player.transform.rotation);
        }
    }

    static void saveBierber()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.BIERBER) != null)
        {
            GameObject bierber = GameObject.FindGameObjectWithTag(TagManager.BIERBER);
            PlayerPrefsX.SetVector3(bierberPosition, bierber.transform.position);
            PlayerPrefsX.SetQuaternion(bierberRotation, bierber.transform.rotation);
        }
    }

    static void saveBierberBody()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.BIERBER_BODY) != null)
        {
            GameObject bierberBody = GameObject.FindGameObjectWithTag(TagManager.BIERBER_BODY);
            PlayerPrefsX.SetBool(bierberBodyRendered, bierberBody.renderer.enabled);
        }
    }

    static void saveBierberHead()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.BIERBER_HEAD) != null)
        {
            GameObject bierberHead = GameObject.FindGameObjectWithTag(TagManager.BIERBER_HEAD);
            PlayerPrefsX.SetBool(bierberHeadRendered, bierberHead.renderer.enabled);
        }
    }

    static void saveBierberWallStatus()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.BIERBER_INVISIBLE_WALL) != null)
        {
            GameObject invisibleWall = GameObject.FindGameObjectWithTag(TagManager.BIERBER_INVISIBLE_WALL);
            PlayerPrefsX.SetBool(bierberInvisibleWall, invisibleWall.collider.enabled);
        }
    }

    static void saveTreeStatus()
    {

        if (GameObject.FindGameObjectWithTag(TagManager.FALLEN_TREE) != null)
        {
            GameObject fallenTree = GameObject.FindGameObjectWithTag(TagManager.FALLEN_TREE);
            PlayerPrefsX.SetBool(fallenTreeRendered, fallenTree.renderer.enabled);
        }
    }

    static void saveBier()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.BEER) != null)
        {
            GameObject bier = GameObject.FindGameObjectWithTag(TagManager.BEER);
            PlayerPrefsX.SetVector3(bierPosition, bier.transform.position);
            PlayerPrefsX.SetQuaternion(bierRotation, bier.transform.rotation);
        }
    }

    static void savePizza()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.PIZZA) != null)
        {
            GameObject[] pizzas = GameObject.FindGameObjectsWithTag(TagManager.PIZZA);
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
