using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{
    private const int subtractValue = 15;

    public static Respawn respawn;

    public Texture2D texture;

    private string[] deathzoneTags;
    private bool dying;
    private bool respawning;
    private Color currentColor;
    private Rect screenRect;
    private GameObject player;
    private MoneyManagement money;
    LoadGameSettings loadGame;

    void Awake()
    {
        respawn = GameObject.FindGameObjectWithTag(TagManager.GAME_CONTROLLER).GetComponent<Respawn>();
        dying = false;
        respawning = false;
        currentColor = Color.black;
        screenRect = new Rect(0f, 0f, Screen.width, Screen.height);
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
        money = player.GetComponent<MoneyManagement>();
        loadGame = GameObject.FindGameObjectWithTag(TagManager.GAME_CONTROLLER).GetComponent<LoadGameSettings>();
    }

    void Start()
    {
        Save.saveGame();
    }

    void Update()
    {
        dyingPlayer();
        restartGame();
        respawnPlayer();
    }

    void OnGUI()
    {
        if (dying || respawning)
        {
            GUI.depth = 0;
            GUI.color = currentColor;
            GUI.DrawTexture(screenRect, texture, ScaleMode.StretchToFill);
        }
    }

    void fadeIn()
    {
        currentColor = Color.Lerp(currentColor, Color.clear, Time.deltaTime);

        if (currentColor.a <= 0.3f)
        {
            currentColor = Color.clear;
            respawning = false;
            setPlayerControl(true);
        }
    }

    void fadeOut()
    {
        currentColor = Color.Lerp(currentColor, Color.black, Time.deltaTime);
        setPlayerControl(false);

        if (currentColor.a >= 0.95f)
        {
            currentColor.a = 1f;
            setGameSettings();
            manageMoney();
            dying = false;
            respawning = true;
        }
    }

    void setPlayerControl(bool enabled)
    {
        if(player.GetComponent<PlayerControl>() != null)
            player.GetComponent<PlayerControl>().enabled = enabled;
    }

    //Reloads the last-saved version of the Game and manages the money
    void setGameSettings()
    {
        loadGame.loadAll();
    }

    void dyingPlayer()
    {
        if (dying)
        {
            fadeOut();
        }
    }

    void respawnPlayer()
    {
        if (respawning)
        {
            fadeIn();
        }
    }

    void restartGame(){
        int currentMoney = money.getCurrentMoney();
        int minMoney = money.getMoneyMinimum();
        if(currentMoney <= minMoney){
            LoadScene.loadLastGame();
            PlayerPrefs.SetInt("PlayerMoney", 60);
            setPlayerControl(true);
        }
    }

    void manageMoney()
    {
        money.subtractMoney(subtractValue);
        PlayerPrefs.SetInt("PlayerMoney", money.getCurrentMoney());
    }

    public bool respawnStatus
    {
        get { return respawning; }
        set{respawning = value;}
    }

    public bool dyingStatus
    {
        get { return dying; }
        set { dying = value; }
    }
}

