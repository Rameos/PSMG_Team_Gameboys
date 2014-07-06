using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

    public Texture2D texture;

    private string[] deathzoneTags;
    private bool dying;
    private bool respawn;
    private Color currentColor;
    private Rect screenRect;
    private float fadeSpeed;
    private GameObject player;
    private MoneyManagement money;
    private Vector3 respawnPosition;

    void Awake()
    {
        deathzoneTags = new string[2] { "DeathzoneRiver", "DeathzoneGap" };
        dying = false;
        respawn = false;
        currentColor = Color.black;
        screenRect = new Rect(0f, 0f, Screen.width, Screen.height);
        fadeSpeed = 1.0f;
        player = GameObject.FindGameObjectWithTag("Player");
        money = player.GetComponent<MoneyManagement>();
    }

    void FixedUpdate()
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
        checkDeathzone();
        if (col.gameObject.tag == player.tag)
        {
            dying = true;
            manageMoney();
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
            currentColor.a = 1f;
            dying = false;
            respawn = true;
        }
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
            player.transform.position = respawnPosition;
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
            // b) Relocate player at the begin of the level if no money is left
            respawnPosition  = new Vector3(96f, 107f, 101f);
            money.setCurrentMoney(moneyMaximum);
        }
    }

    void checkDeathzone()
    {
        string tag = gameObject.tag;
        for (int i = 0; i < deathzoneTags.Length; i++)
        {
            if (tag.Equals(deathzoneTags[i]))
            {
                respawnPosition = new Vector3(530, 101, 250);
                break;
            }
        }
    }
}
