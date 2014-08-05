using UnityEngine;
using System.Collections;

public class LoadGameSettings : MonoBehaviour
{

    void Awake()
    {
        if (PlayerPrefsX.GetBool("GameSaved") && PlayerPrefs.GetString("SceneToLoad").Equals(Application.loadedLevelName))
        {
            loadPlayer();
            loadBierber();
            loadBierberBody();
            loadBierberHead();
            loadFallenTree();
            loadInvisibleWall();
            loadBier();
            loadPizza();
        }
    }

    void loadPlayer()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = PlayerPrefsX.GetVector3("PlayerPosition");
            player.transform.rotation = PlayerPrefsX.GetQuaternion("PlayerRotation");
        }
    }

    void loadBierber()
    {
        if (GameObject.FindGameObjectWithTag("Bierber") != null)
        {
            GameObject bierber = GameObject.FindGameObjectWithTag("Bierber");
            bierber.transform.position = PlayerPrefsX.GetVector3("BierberPosition");
            bierber.transform.rotation = PlayerPrefsX.GetQuaternion("BierberRotation");
        }
    }

    void loadBierberBody()
    {
        if (GameObject.FindGameObjectWithTag("BierberBody") != null)
        {
            GameObject bierberBody = GameObject.FindGameObjectWithTag("BierberBody");
            bierberBody.renderer.enabled = PlayerPrefsX.GetBool("BierberBodyRendered");
        }
    }

    void loadBierberHead()
    {
        if (GameObject.FindGameObjectWithTag("BierberHead") != null)
        {
            GameObject bierberHead = GameObject.FindGameObjectWithTag("BierberHead");
            bierberHead.renderer.enabled = PlayerPrefsX.GetBool("BierberHeadRendered");
        }
    }

    void loadFallenTree()
    {
        if (GameObject.FindGameObjectWithTag("FallenTree") != null)
        {
            GameObject fallenTree = GameObject.FindGameObjectWithTag("FallenTree");
            fallenTree.renderer.enabled = PlayerPrefsX.GetBool("FallenTreeRendered");
        }
    }

    void loadInvisibleWall()
    {
        if (GameObject.FindGameObjectWithTag("BierberInvisibleWall") != null)
        {
            GameObject invisibleWall = GameObject.FindGameObjectWithTag("BierberInvisibleWall");
            invisibleWall.collider.enabled = PlayerPrefsX.GetBool("BierberInvisibleWall");
        }
    }


    void loadBier()
    {
        if (GameObject.FindGameObjectWithTag("Beer") != null)
        {
            GameObject bier = GameObject.FindGameObjectWithTag("Beer");
            bier.transform.position = PlayerPrefsX.GetVector3("BierPosition");
            bier.transform.rotation = PlayerPrefsX.GetQuaternion("BierRotation");
        }
    }

    void loadPizza()
    {
        if (GameObject.FindGameObjectWithTag("Pizza") != null)
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
}
