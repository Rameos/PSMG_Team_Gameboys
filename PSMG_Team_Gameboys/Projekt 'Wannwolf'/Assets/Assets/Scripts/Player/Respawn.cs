using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{

    public Texture2D texture;

    private string[] deathzoneTags;
    private bool dying;
    private bool respawn;
    private Color currentColor;
    private Rect screenRect;
    private float fadeSpeed;
    private GameObject player;
    private MoneyManagement money;
    LoadGameSettings loadGame;

    void Awake()
    {
        dying = false;
        respawn = false;
        currentColor = Color.black;
        screenRect = new Rect(0f, 0f, Screen.width, Screen.height);
        fadeSpeed = 1.0f;
        player = GameObject.FindGameObjectWithTag("Player");
        money = player.GetComponent<MoneyManagement>();
        loadGame = GameObject.FindGameObjectWithTag("GameController").GetComponent<LoadGameSettings>();
    }

    void Update()
    {
        dyingPlayer();
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

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == player.tag)
        {
            dying = true;
        }
    }

    void fadeIn()
    {
        currentColor = Color.Lerp(currentColor, Color.clear, fadeSpeed * Time.deltaTime);

        if (currentColor.a <= 0.05f)
        {
            currentColor = Color.clear;
            respawn = false;
        }
    }

    void fadeOut()
    {
        currentColor = Color.Lerp(currentColor, Color.black, fadeSpeed * Time.deltaTime);

        if (currentColor.a >= 0.95f)
        {
            setGameSettings();
            currentColor.a = 1f;
            dying = false;
            respawn = true;
        }
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

    void manageMoney()
    {
        // Subtract money from the players account on death
        money.subtractMoney(15);

        // Decide where to relocate the player to after death
        int curMoney = money.getCurrentMoney();
        int moneyMinimum = money.getMoneyMinimum();
        int moneyMaximum = money.getMoneyMaximum();

        if (curMoney <= moneyMinimum)
        {
            LoadScene.loadFirstLevel();
            // b) Relocate player at the begin of the level if no money is left
            money.setCurrentMoney(moneyMaximum);
        }
    }
}

