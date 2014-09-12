using UnityEngine;
using System.Collections;

public class Cut : MonoBehaviour {

    private bool startPosSet = false;
    private bool draw = false;
    private bool started = false;
    private float startPos;
    private double xMax;
    private double xMin;
    private double yMax;
    private double yMin;
    private double win = Screen.width * 0.6336;
    private float oldPos;
    private float distance;
    private GameObject pizza;

    private startFight fight;

    public Texture2D textureToDisplay;

	// Use this for initialization
	void Start () {
        

        xMax = Screen.width * 0.3809;
        xMin = Screen.width * 0.33699;
        yMax = Screen.height * 0.55;
        yMin = Screen.height * 0.3636;
	
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("y: " + Input.mousePosition.y);
        if (started)
        {
            checkPosition();
            if (draw)
            {
                getDistance();
            }
        }
	}

    public void setStarted()
    {
        started = true;
    }

    public void setPizza(GameObject obj)
    {
        pizza = obj;
    }

    void checkPosition()
    {
        if (Input.mousePosition.x <= xMax && Input.mousePosition.x >= xMin && Input.mousePosition.y <= yMax && Input.mousePosition.y >= yMin)
        {
            if (!startPosSet)
            {
                startPos = Input.mousePosition.x;
                startPosSet = true;
                oldPos = startPos;
                draw = true;
            }

        }
    }

    void getDistance()
    {
        if (Input.mousePosition.y <= yMax && Input.mousePosition.y >= yMin)
        {
            if (Input.mousePosition.x > oldPos)
            {
                oldPos = Input.mousePosition.x;
                distance = oldPos - startPos;
                if (Input.mousePosition.x >= win)
                {
                    fightWon();
                }
            }
        }
    }

    void fightWon()
    {
        fight = pizza.GetComponent<startFight>();
        draw = false;
        fight.setWon();
        distance = 0;
        oldPos = 0;
        startPos = 0;
        startPosSet = false;
    }

    void OnGUI()
    {
        if (draw)
        {
            GUI.Label(new Rect(startPos, (float)(Screen.height * 0.5), distance, 20), textureToDisplay);
        }
    }
}
