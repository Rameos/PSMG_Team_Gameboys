using UnityEngine;
using System.Collections;

public class Cut : MonoBehaviour {

    private bool fightStarted = true;
    private bool startPosSet = false;
    private bool draw = false;
    private float startPos;
    private double xMax;
    private double xMin;
    private double yMax;
    private double yMin;
    private double win = Screen.width * 0.6336;
    private float oldPos;
    private float distance;

    private startFight fight;

    public Texture2D textureToDisplay;

	// Use this for initialization
	void Start () {
        fight = GameObject.FindGameObjectWithTag("Pizza").GetComponent<startFight>();

        xMax = Screen.width * 0.3809;
        xMin = Screen.width * 0.33699;
        yMax = Screen.height * 0.4895;
        yMin = Screen.height * 0.3636;
	
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("y: " + Input.mousePosition.y);
        if (fightStarted == true)
        {
            checkPosition();
            if (draw)
            {
                getDistance();
            }
        }
	
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
                Debug.Log(Input.mousePosition.x);
            }
        }
    }

    void fightWon()
    {
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
