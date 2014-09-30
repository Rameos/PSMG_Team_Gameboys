using UnityEngine;
using System.Collections;

public class Save : MonoBehaviour
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

    private const string destroyReplacements = "DestroyReplacements";

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


    public static void saveGame()
    {
        saveScene();
        saveStelzes();
        savePlayer();
        saveBierber();
        saveBierberBody();
        saveBierberHead();
        saveTreeStatus();
        saveBier();
        savePizza();
        saveNorbert();
        saveFireInvisibleWall();
        saveFire();
        savePilzeriaHint();
        savePizzaHint();
        saveSneakingHint();
        saveJumpHint();
        saveEndOFJourneyHint();
        saveFireHint();
        saveBierberHint();
        saveStairBuildHint();
        saveFire();
        saveVomitZone();
        saveReplacementPieces();
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
            PlayerPrefs.SetInt(playerMoney, player.GetComponent<MoneyManagement>().getCurrentMoney());

            if (player.GetComponent<PlayerControl>() != null)
            {
                PlayerControl playerControl = player.GetComponent<PlayerControl>();

                if (playerControl.onStelze)
                {
                    PlayerPrefsX.SetVector3(playerPosition, playerControl.stelzePosition);
                }

                PlayerPrefsX.SetBool(playerDrunk, playerControl.drankStatus);
                PlayerPrefsX.SetBool(playerDoubleJump, playerControl.ableToDoubleJumpStatus);
                PlayerPrefs.SetFloat(playerStamina, playerControl.sprintTimeStatus);
                PlayerPrefsX.SetBool(playerVodka, playerControl.vodkaStatus);
            }
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

    static void saveTreeStatus()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.STAMM) != null)
        {
            GameObject fallenTree = GameObject.FindGameObjectWithTag(TagManager.STAMM);
            PlayerPrefsX.SetVector3(fallenTreePosition, fallenTree.transform.position);
            PlayerPrefsX.SetQuaternion(fallenTreeRotation, fallenTree.transform.rotation);
        }
    }

    static void saveBier()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.BEER) != null)
        {
            GameObject bier = GameObject.FindGameObjectWithTag(TagManager.BEER);
            PlayerPrefsX.SetVector3(bierPosition, bier.transform.position);
            PlayerPrefsX.SetQuaternion(bierRotation, bier.transform.rotation);
            PlayerPrefsX.SetBool(bierActiveStatus, bier.GetComponent<DragByPlayer>().enabled);
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

    static void saveNorbert()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.NORBERT) != null)
        {
            GameObject norbert = GameObject.FindGameObjectWithTag(TagManager.NORBERT);
            PlayerPrefsX.SetVector3(norbertPosition, norbert.transform.position);
            PlayerPrefsX.SetQuaternion(norbertRotation, norbert.transform.rotation);
        }
    }

    static void saveStelzes()
    {
        if(!PlayerPrefs.HasKey(stelzesSaved))
        {
            if (GameObject.FindGameObjectWithTag(TagManager.STELZE) != null)
            {
                GameObject[] stelzes = GameObject.FindGameObjectsWithTag(TagManager.STELZE);
                Vector3[] stelzePos = new Vector3[stelzes.Length];
                Quaternion[] stelzeRot = new Quaternion[stelzes.Length];
                for (int i = 0; i < stelzes.Length; i++)
                {
                    stelzePos[i] = stelzes[i].transform.position;
                    stelzeRot[i] = stelzes[i].transform.rotation;
                }
                PlayerPrefsX.SetVector3Array(stelzePositions, stelzePos);
                PlayerPrefsX.SetQuaternionArray(stelzeRotations, stelzeRot);

                setStelzesSaved();
            }
        }
    }

    static void setStelzesSaved()
    {
        PlayerPrefs.SetString(stelzesSaved ,"True");
    }

    static void saveReplacements()
    {
        if (GameObject.FindGameObjectsWithTag(TagManager.REPLACEMENT) != null)
        {
           
        }
    }

    static void saveFireInvisibleWall()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.FIRE_INVISIBLE_WALL) != null && (!PlayerPrefsX.GetBool(destroyFireInvisibleWall) || !PlayerPrefs.HasKey(destroyFireInvisibleWall)))
        {
            PlayerPrefsX.SetBool(destroyFireInvisibleWall, false);
        }
        else PlayerPrefsX.SetBool(destroyFireInvisibleWall, true);
    }

    static void savePizzaHint()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.PIZZA_HINT) != null && (!PlayerPrefsX.GetBool(destroyPizzaHint) || !PlayerPrefs.HasKey(destroyPizzaHint)))
        {
            PlayerPrefsX.SetBool(destroyPizzaHint, false);
        }
        else PlayerPrefsX.SetBool(destroyPizzaHint, true);
    }

    static void saveBierberHint()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.BIERBER_HINT) != null && (!PlayerPrefsX.GetBool(destroyBierberHint) || !PlayerPrefs.HasKey(destroyBierberHint)))
        {
            PlayerPrefsX.SetBool(destroyBierberHint, false);
        }
        else PlayerPrefsX.SetBool(destroyBierberHint, true);
    }

    static void saveFireHint()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.FIRE_ARRIVAL_HINT) != null && (!PlayerPrefsX.GetBool(destroyFireHint) || !PlayerPrefs.HasKey(destroyFireHint)))
        {
            PlayerPrefsX.SetBool(destroyFireHint, false);
        }
        else PlayerPrefsX.SetBool(destroyFireHint, true);
    }

    static void saveJumpHint()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.JUMP_HINT) != null && (!PlayerPrefsX.GetBool(destroyJumpHint) || !PlayerPrefs.HasKey(destroyJumpHint)))
        {
            PlayerPrefsX.SetBool(destroyJumpHint, false);
        }
        else PlayerPrefsX.SetBool(destroyJumpHint, true);
    }

    static void saveSneakingHint()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.ANGLER_ARRIVAL_HINT) != null && (!PlayerPrefsX.GetBool(destroySneakingHint) || !PlayerPrefs.HasKey(destroySneakingHint)))
        {
            PlayerPrefsX.SetBool(destroySneakingHint, false);
        }
        else PlayerPrefsX.SetBool(destroySneakingHint, true);
    }

    static void savePilzeriaHint()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.VODKA_HINT) != null && (!PlayerPrefsX.GetBool(destroyPilzeriaHint) || !PlayerPrefs.HasKey(destroyPilzeriaHint)))
        {
            PlayerPrefsX.SetBool(destroyPilzeriaHint, false);
        }
        else PlayerPrefsX.SetBool(destroyPilzeriaHint, true);
    }

    static void saveStairBuildHint()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.STAIR_BUILD_HINT) != null && (!PlayerPrefsX.GetBool(destroyStairBuildHint) || !PlayerPrefs.HasKey(destroyStairBuildHint)))
        {
            PlayerPrefsX.SetBool(destroyStairBuildHint, false);
        }
        else PlayerPrefsX.SetBool(destroyStairBuildHint, true);
    }

    static void saveEndOFJourneyHint()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.CHASE_HINT) != null && (!PlayerPrefsX.GetBool(destroyEndOFJourneyHint) || !PlayerPrefs.HasKey(destroyEndOFJourneyHint)))
        {
            PlayerPrefsX.SetBool(destroyEndOFJourneyHint, false);
        }
        else PlayerPrefsX.SetBool(destroyEndOFJourneyHint, true);
    }

    static void saveVomitZone()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.VOMIT_ZONE) != null && (!PlayerPrefsX.GetBool(destroyVomitZone) || !PlayerPrefs.HasKey(destroyVomitZone)))
        {
            PlayerPrefsX.SetBool(destroyVomitZone, false);
        }
        else PlayerPrefsX.SetBool(destroyVomitZone, true);
    }

    static void saveFire()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.FIRE) != null && (!PlayerPrefsX.GetBool(destroyFireHint) || !PlayerPrefs.HasKey(destroyFireHint)))
        {
            PlayerPrefsX.SetBool(destroyFire, false);
        }
        else PlayerPrefsX.SetBool(destroyFire, true);
    }

    static void saveReplacementPieces()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.GAME_CONTROLLER) != null)
        {
            ReplacementHUDLogic replacementLogic = GameObject.FindGameObjectWithTag(TagManager.GAME_CONTROLLER).GetComponent<ReplacementHUDLogic>();
            PlayerPrefs.SetInt(replacementPieces, replacementLogic.hasPieces);
        }
    }
}
