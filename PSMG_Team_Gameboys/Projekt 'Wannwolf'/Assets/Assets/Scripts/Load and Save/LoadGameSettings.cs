using UnityEngine;
using System.Collections;

public class LoadGameSettings : MonoBehaviour
{

    void Awake()
    {
        if (PlayerPrefsX.GetBool("GameSaved") && PlayerPrefs.GetString("SceneToLoad").Equals(Application.loadedLevelName))
        {
            loadAll();
        }
    }

    public void loadAll()
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

    void loadPlayer()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.PLAYER) != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
            player.transform.position = PlayerPrefsX.GetVector3("PlayerPosition");
            player.transform.rotation = PlayerPrefsX.GetQuaternion("PlayerRotation");
        }
    }

    void loadBierber()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.BIERBER) != null)
        {
            GameObject bierber = GameObject.FindGameObjectWithTag(TagManager.BIERBER);
            bierber.transform.position = PlayerPrefsX.GetVector3("BierberPosition");
            bierber.transform.rotation = PlayerPrefsX.GetQuaternion("BierberRotation");
        }
    }

    void loadBierberBody()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.BIERBER_BODY) != null)
        {
            GameObject bierberBody = GameObject.FindGameObjectWithTag(TagManager.BIERBER_BODY);
            bierberBody.renderer.enabled = PlayerPrefsX.GetBool("BierberBodyRendered");
        }
    }

    void loadBierberHead()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.BIERBER_HEAD) != null)
        {
            GameObject bierberHead = GameObject.FindGameObjectWithTag(TagManager.BIERBER_HEAD);
            bierberHead.renderer.enabled = PlayerPrefsX.GetBool("BierberHeadRendered");
        }
    }

    void loadFallenTree()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.FALLEN_TREE) != null)
        {
            GameObject fallenTree = GameObject.FindGameObjectWithTag(TagManager.FALLEN_TREE);
            fallenTree.renderer.enabled = PlayerPrefsX.GetBool("FallenTreeRendered");
        }
    }

    void loadInvisibleWall()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.BIERBER_INVISIBLE_WALL) != null)
        {
            GameObject invisibleWall = GameObject.FindGameObjectWithTag(TagManager.BIERBER_INVISIBLE_WALL);
            invisibleWall.collider.enabled = PlayerPrefsX.GetBool("BierberInvisibleWall");
        }
    }


    void loadBier()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.BEER) != null)
        {
            GameObject bier = GameObject.FindGameObjectWithTag(TagManager.BEER);
            bier.transform.position = PlayerPrefsX.GetVector3("BierPosition");
            bier.transform.rotation = PlayerPrefsX.GetQuaternion("BierRotation");
        }
    }

    void loadPizza()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.PIZZA) != null)
        {
            Vector3[] pizzaPositions = PlayerPrefsX.GetVector3Array("PizzaPositions");
            Quaternion[] pizzaRotations = PlayerPrefsX.GetQuaternionArray("PizzaRotations");
            for (int i = 0; i < pizzaPositions.Length; i++)
            {
                GameObject pizza = GameObject.FindGameObjectWithTag(TagManager.PIZZA);
                pizza.transform.position = pizzaPositions[i];
                pizza.transform.rotation = pizzaRotations[i];
            }
        }
    }
}
