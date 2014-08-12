using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{
    private const int subtractValue = 15;

    public Texture2D texture;

    private string[] deathzoneTags;
    private bool dying;
    private bool respawn;
    private Color currentColor;
    private Rect screenRect;
    private GameObject player;
    private MoneyManagement money;
    LoadGameSettings loadGame;

    void Awake()
    {
        dying = false;
        respawn = false;
        currentColor = Color.black;
        screenRect = new Rect(0f, 0f, Screen.width, Screen.height);
        player = GameObject.FindGameObjectWithTag("Player");
        money = player.GetComponent<MoneyManagement>();
        loadGame = GameObject.FindGameObjectWithTag("GameController").GetComponent<LoadGameSettings>();
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
        if (dying || respawn)
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
            respawn = false;
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
            respawn = true;
        }
    }

    void setPlayerControl(bool enabled)
    {
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
            player.renderer.enabled = false;
        }
    }

    void respawnPlayer()
    {
        if (respawn)
        {
            player.renderer.enabled = true;
            fadeIn();
        }
    }

    void restartGame(){
        int currentMoney = money.getCurrentMoney();
        int minMoney = money.getMoneyMinimum();
        if(currentMoney <= minMoney){
            LoadScene.loadFirstLevel();
            setPlayerControl(true);
        }
    }

    void manageMoney()
    {
        money.subtractMoney(subtractValue);
    }

    public bool respawnStatus
    {
        get { return respawn; }
        set{respawn = value;}
    }

    public bool dyingStatus
    {
        get { return dying; }
        set { dying = value; }
    }
}

