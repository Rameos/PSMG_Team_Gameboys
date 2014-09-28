using UnityEngine;
using System.Collections;

public class LoadGameSettings : MonoBehaviour
{
    private const string playerPosition = "PlayerPosition";
    private const string playerRotation = "PlayerRotation";
    private const string playerMoney = "PlayerMoney";

    private const string bierberPosition = "BierberPosition";
    private const string bierberRotation = "BierberRotation";
    private const string bierberBodyRendered = "BierberBodyRendered";
    private const string bierberHeadRendered = "BierberHeadRendered";

    private const string destroyBierberInvisibleWall = "DestroyBierberInvisibleWall";

    private const string fallenTreeRendered = "FallenTreeRendered";
    private const string fallenTreePosition = "FallenTreePosition";
    private const string fallenTreeRotation = "FallenTreeRotation";

    private const string bierPosition = "BierPosition";
    private const string bierRotation = "BierRotation";
    private const string bierActiveStatus = "BierActiveStatus";

    private const string pizzaPositions = "PizzaPositions";
    private const string pizzaRotations = "PizzaRotations";

    private const string norbertPosition = "NorbertPosition";
    private const string norbertRotation = "NorbertRotation";

    private const string stelzePositions = "StelzePosition";
    private const string stelzeRotations = "StelzeRotation";

    private const string replacementPositions = "ReplacementPosition";
    private const string replacementRotations = "ReplacementRotation";

    private const string destroyFireInvisibleWall = "DestroyFireInvisibleWall";

    private const string destroyPizzaHint = "DestroyPizzaHint";
    private const string destroyPilzeriaHint = "DestroyPilzeriaHint";
    private const string destroyFireHint = "DestroyFireHint";
    private const string destroyBierberHint = "DestroyBierberHint";
    private const string destroySneakingHint = "DestroySneakingHint";
    private const string destroyJumpHint = "DestroyJumpHint";
    private const string destroyStairBuildHint = "DestroySTairBuildHint";
    private const string destroyEndOFJourneyHint = "DestroyEndOfJourneyHint";

    private const string destroyFire = "DestroyFire";

    private const string stelzesSaved = "StelzesSaved";

    void Awake()
    {
        if (PlayerPrefsX.GetBool("GameSaved") && PlayerPrefs.GetString("SceneToLoad").Equals(Application.loadedLevelName))
        {
            loadAll();
        }
    }

    public void loadAll()
    {
        Debug.Log("LoadAll");
        loadPlayer();
        loadBierber();
        loadBierberBody(); 
        loadBierberHead();
        loadFallenTree();
        loadInvisibleWall();
        loadBier();
        loadPizza();
        loadNorbert();
        loadStelzes();
        loadReplacements();
        loadPilzeriaHint();
        loadPizzaHint();
        loadJumpHint();
        loadBierberHint();
        loadStairBuildHint();
        loadEndOfJourneyHint();
        loadSneakingHint();
        loadFireHint();
        loadFireInvisibleWall();
        loadFire();
    }

    void loadPlayer()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.PLAYER) != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
            player.transform.position = PlayerPrefsX.GetVector3(playerPosition);
            player.transform.rotation = PlayerPrefsX.GetQuaternion(playerRotation);
            player.GetComponent<MoneyManagement>().setCurrentMoney(PlayerPrefs.GetInt(playerMoney));
        }
    }

    void loadBierber()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.BIERBER) != null)
        {
            GameObject bierber = GameObject.FindGameObjectWithTag(TagManager.BIERBER);
            bierber.transform.position = PlayerPrefsX.GetVector3(bierberPosition);
            bierber.transform.rotation = PlayerPrefsX.GetQuaternion(bierberRotation);
        }
    }

    void loadBierberBody()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.BIERBER_BODY) != null)
        {
            GameObject bierberBody = GameObject.FindGameObjectWithTag(TagManager.BIERBER_BODY);
            bierberBody.renderer.enabled = PlayerPrefsX.GetBool(bierberBodyRendered);
        }
    }

    void loadBierberHead()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.BIERBER_HEAD) != null)
        {
            GameObject bierberHead = GameObject.FindGameObjectWithTag(TagManager.BIERBER_HEAD);
            bierberHead.renderer.enabled = PlayerPrefsX.GetBool(bierberHeadRendered);
        }
    }

    void loadFallenTree()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.FALLEN_TREE) != null)
        {
            GameObject fallenTree = GameObject.FindGameObjectWithTag(TagManager.FALLEN_TREE);
            fallenTree.renderer.enabled = PlayerPrefsX.GetBool(fallenTreeRendered);
        }
    }

    void loadInvisibleWall()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.BIERBER_INVISIBLE_WALL) != null && PlayerPrefsX.GetBool(destroyBierberInvisibleWall))
        {
            Destroy(GameObject.FindGameObjectWithTag(TagManager.BIERBER_INVISIBLE_WALL));
        }
    }


    void loadBier()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.BEER) != null)
        {
            GameObject bier = GameObject.FindGameObjectWithTag(TagManager.BEER);
            bier.transform.position = PlayerPrefsX.GetVector3(bierPosition);
            bier.transform.rotation = PlayerPrefsX.GetQuaternion(bierRotation);
            bier.GetComponent<DragByPlayer>().enabled = PlayerPrefsX.GetBool(bierActiveStatus);
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

    void loadNorbert()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.NORBERT) != null)
        {
            GameObject norbert = GameObject.FindGameObjectWithTag(TagManager.NORBERT);
            norbert.transform.position = PlayerPrefsX.GetVector3(norbertPosition);
            norbert.transform.rotation = PlayerPrefsX.GetQuaternion(norbertRotation);
        }
    }

    void loadStelzes()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.STELZE) != null)
        {
            GameObject[] stelzes = GameObject.FindGameObjectsWithTag(TagManager.STELZE);
            Quaternion[] rotations = PlayerPrefsX.GetQuaternionArray(stelzeRotations);
            Vector3[] positions = PlayerPrefsX.GetVector3Array(stelzePositions);
            for (int i = 0; i < stelzes.Length; i++)
            {
                stelzes[i].transform.position = positions[i];
                stelzes[i].transform.rotation = rotations[i];
            }
        }
    }

    void loadReplacements()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.REPLACEMENT) != null)
        {
            GameObject[] replacements = GameObject.FindGameObjectsWithTag(TagManager.REPLACEMENT);
            Quaternion[] rotations = PlayerPrefsX.GetQuaternionArray(replacementRotations);
            Vector3[] positions = PlayerPrefsX.GetVector3Array(replacementPositions);
            for (int i = 0; i < replacements.Length; i++)
            {
                replacements[i].transform.position = positions[i];
                replacements[i].transform.rotation = rotations[i];
            }
        }
    }

    void loadPizzaHint()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.PIZZA_HINT) != null && PlayerPrefsX.GetBool(destroyPizzaHint))
        {
            Destroy(GameObject.FindGameObjectWithTag(TagManager.PIZZA_HINT));
        }
    }

    void loadJumpHint()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.JUMP_HINT) != null && PlayerPrefsX.GetBool(destroyJumpHint))
        {
            Destroy(GameObject.FindGameObjectWithTag(TagManager.JUMP_HINT));
        }
    }

    void loadSneakingHint()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.ANGLER_ARRIVAL_HINT) != null && PlayerPrefsX.GetBool(destroySneakingHint))
        {
            Destroy(GameObject.FindGameObjectWithTag(TagManager.ANGLER_ARRIVAL_HINT));
        }
    }

    void loadEndOfJourneyHint()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.CHASE_HINT) != null && PlayerPrefsX.GetBool(destroyEndOFJourneyHint))
        {
            Destroy(GameObject.FindGameObjectWithTag(TagManager.CHASE_HINT));
        }
    }

    void loadPilzeriaHint()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.VODKA_HINT) != null && PlayerPrefsX.GetBool(destroyPilzeriaHint))
        {
            Destroy(GameObject.FindGameObjectWithTag(TagManager.VODKA_HINT));
        }
    }

    void loadFireHint()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.FIRE_ARRIVAL_HINT) != null && PlayerPrefsX.GetBool(destroyFireHint))
        {
            Destroy(GameObject.FindGameObjectWithTag(TagManager.FIRE_ARRIVAL_HINT));
        }
    }

    void loadStairBuildHint()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.STAIR_BUILD_HINT) != null && PlayerPrefsX.GetBool(destroyStairBuildHint))
        {
            Destroy(GameObject.FindGameObjectWithTag(TagManager.STAIR_BUILD_HINT));
        }
    }

    void loadBierberHint()
    {
        Debug.Log("Laden: " + PlayerPrefsX.GetBool(destroyBierberHint));
        if (GameObject.FindGameObjectWithTag(TagManager.BIERBER_HINT) != null && PlayerPrefsX.GetBool(destroyBierberHint))
        {
            Debug.Log("Destroy: " + PlayerPrefsX.GetBool(destroyBierberHint));
            Destroy(GameObject.FindGameObjectWithTag(TagManager.BIERBER_HINT));
        }
    }

    void loadFireInvisibleWall()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.FIRE_INVISIBLE_WALL) != null && PlayerPrefsX.GetBool(destroyFireInvisibleWall))
        {
            Destroy(GameObject.FindGameObjectWithTag(TagManager.FIRE_INVISIBLE_WALL));
        }
    }

    void loadFire()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.FIRE) != null && PlayerPrefsX.GetBool(destroyFire))
        {
            Destroy(GameObject.FindGameObjectWithTag(TagManager.FIRE));
        }
    }
}
