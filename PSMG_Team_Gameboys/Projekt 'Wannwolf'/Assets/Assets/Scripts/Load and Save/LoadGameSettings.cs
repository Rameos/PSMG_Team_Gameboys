using UnityEngine;
using System.Collections;

public class LoadGameSettings : MonoBehaviour
{
    private const string playerPosition = "PlayerPosition";
    private const string playerRotation = "PlayerRotation";
    private const string playerMoney = "PlayerMoney";
    private const string playerDrunk = "PlayerDrunk";
    private const string playerDoubleJump = "PlayerDoubleJump";
    private const string playerStamina = "PlayerStamina";
    private const string playerVodka = "PlayerVodka";

    private const string bierberPosition = "BierberPosition";
    private const string bierberRotation = "BierberRotation";
    private const string bierberBodyRendered = "BierberBodyRendered";
    private const string bierberHeadRendered = "BierberHeadRendered";

    private const string destroyBierberInvisibleWall = "DestroyBierberInvisibleWall";

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

    private const string destroyReplacementRad = "DestroyReplacementRad";
    private const string destroyReplacementLenker = "DestroyReplacementLenker";
    private const string destroyReplacementTurbine = "DestroyReplacementTurbine";

    private const string destroyVomitZone = "DestroyVomitZone";

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

    private const string replacementPieces = "ReplacemetPieces";

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
        loadPlayer();
        loadBierber();
        loadBierberBody(); 
        loadBierberHead();
        loadFallenTree();
        loadBier();
        loadPizza();
        loadNorbert();
        loadStelzes();
        loadReplacementLenker();
        loadReplacementRad();
        loadReplacementTurbine();
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
        loadVomitZone();
        loadReplacementPieces();
    }

    void loadPlayer()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.PLAYER) != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
            player.transform.position = PlayerPrefsX.GetVector3(playerPosition);
            player.transform.rotation = PlayerPrefsX.GetQuaternion(playerRotation);
            if (PlayerPrefs.HasKey(playerMoney))
            {
                player.GetComponent<MoneyManagement>().setCurrentMoney(PlayerPrefs.GetInt(playerMoney));
            }

            if (GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<PlayerControl>() != null)
            {
                PlayerControl playerControl = player.GetComponent<PlayerControl>();

                if (PlayerPrefs.HasKey(playerDrunk))
                {
                    playerControl.drankStatus = PlayerPrefsX.GetBool(playerDrunk);
                }

                if (PlayerPrefs.HasKey(playerDoubleJump))
                {
                    playerControl.ableToDoubleJumpStatus = PlayerPrefsX.GetBool(playerDoubleJump);
                }

                if (PlayerPrefs.HasKey(playerVodka))
                {
                    playerControl.vodkaStatus = PlayerPrefsX.GetBool(playerVodka);
                }

                if (PlayerPrefs.HasKey(playerStamina))
                {
                    playerControl.sprintTimeStatus = PlayerPrefs.GetFloat(playerStamina);
                }
            }
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
        if (GameObject.FindGameObjectWithTag(TagManager.STAMM) != null)
        {
            GameObject fallenTree = GameObject.FindGameObjectWithTag(TagManager.STAMM);
            fallenTree.transform.position = PlayerPrefsX.GetVector3(fallenTreePosition);
            fallenTree.transform.rotation = PlayerPrefsX.GetQuaternion(fallenTreeRotation);
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
            Vector3[] pizzaPos = PlayerPrefsX.GetVector3Array(pizzaPositions);
            Quaternion[] pizzaRot = PlayerPrefsX.GetQuaternionArray(pizzaRotations);
            for (int i = 0; i < pizzaPos.Length; i++)
            {
                GameObject pizza = GameObject.FindGameObjectWithTag(TagManager.PIZZA);
                pizza.transform.position = pizzaPos[i];
                pizza.transform.rotation = pizzaRot[i];
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

    void loadReplacementRad()
    {
        if (GameObject.FindGameObjectsWithTag(TagManager.ERSATZTEIL_RAD) != null  && PlayerPrefsX.GetBool(destroyReplacementRad))
        {
            Destroy(GameObject.FindGameObjectWithTag(TagManager.ERSATZTEIL_RAD));
        }
    }

    void loadReplacementLenker()
    {
        if (GameObject.FindGameObjectsWithTag(TagManager.ERSATZTEIL_LENKER) != null  && PlayerPrefsX.GetBool(destroyReplacementLenker))
        {
            Destroy(GameObject.FindGameObjectWithTag(TagManager.ERSATZTEIL_LENKER));
        }
    }

    void loadReplacementTurbine()
    {
        if (GameObject.FindGameObjectsWithTag(TagManager.ERSATZTEIL_TURBINE) != null  && PlayerPrefsX.GetBool(destroyReplacementTurbine))
        {
            Destroy(GameObject.FindGameObjectWithTag(TagManager.ERSATZTEIL_TURBINE));
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
        if (GameObject.FindGameObjectWithTag(TagManager.BIERBER_HINT) != null && PlayerPrefsX.GetBool(destroyBierberHint))
        {
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

    void loadVomitZone()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.VOMIT_ZONE) != null && PlayerPrefsX.GetBool(destroyVomitZone))
        {
            Destroy(GameObject.FindGameObjectWithTag(TagManager.VOMIT_ZONE));
        }
    }

    void loadFire()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.FIRE) != null && PlayerPrefsX.GetBool(destroyFire))
        {
            Destroy(GameObject.FindGameObjectWithTag(TagManager.FIRE));
        }
    }

    void loadReplacementPieces()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.GAME_CONTROLLER) != null)
        {
            ReplacementHUDLogic replacementLogic = GameObject.FindGameObjectWithTag(TagManager.GAME_CONTROLLER).GetComponent<ReplacementHUDLogic>();
            replacementLogic.hasPieces = PlayerPrefs.GetInt(replacementPieces);
        }
    }
}
