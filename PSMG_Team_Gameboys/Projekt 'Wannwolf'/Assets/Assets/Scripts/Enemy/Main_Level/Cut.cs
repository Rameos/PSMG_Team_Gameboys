using UnityEngine;
using System.Collections;
using iViewX;

public class Cut : MonoBehaviourWithGazeComponent {

    private bool startPosSet = false;
    private bool draw = false;
    private bool started = false;
    private float startPos;
    private double xMax;
    private double xMin;
    private double yMax;
    private double yMin;
    private double win = Screen.width * 0.652;
    private float oldPos;
    private float distance;
    private GameObject pizza;

    private startFight fight;

    public Texture2D textureToDisplay;

	// Use this for initialization
	void Start () {
        

        xMax = Screen.width * 0.373;
        xMin = Screen.width * 0.315;
        yMax = Screen.height * 0.575;
        yMin = Screen.height * 0.35;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (started == true)
        {
            if (gazeModel.posGazeRight.x == 0 && gazeModel.posGazeRight.y == 0)
            {
                checkPosition(Input.mousePosition.x, Input.mousePosition.y);
                if (draw)
                {
                    getDistance(Input.mousePosition.x, Input.mousePosition.y);
                }
            }
            else
            {
                checkPosition(gazeModel.posGazeRight.x, gazeModel.posGazeRight.y);
                if (draw)
                {
                    getDistance(gazeModel.posGazeRight.x, gazeModel.posGazeRight.y);
                }
            }
            
           
        }
	}

    public void setStarted(bool isStarted)
    {
        
        started = isStarted;
    }

    public void setPizza(GameObject obj)
    {
        pizza = obj;
    }

    public GameObject getFightingPizza()
    {
        return pizza;
    }

    void checkPosition(float x, float y)
    {
        if (x <= xMax && x >= xMin && y <= yMax && y >= yMin)
        {
            if (!startPosSet)
            {
                startPos = x;
                startPosSet = true;
                oldPos = startPos;
                draw = true;
            }

        }
    }

    void getDistance(float x, float y)
    {
        if (y <= yMax && y >= yMin)
        {
            if (x > oldPos)
            {
                oldPos = x;
                distance = oldPos - startPos;
                if (x >= win)
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
        started = false;
    }

    void OnGUI()
    {
        if (draw)
        {
            GUI.Label(new Rect(startPos, (float)(Screen.height * 0.5), distance, 20), textureToDisplay);
        }
    }

    public override void OnGazeEnter(RaycastHit hit)
    {

    }

    public override void OnGazeStay(RaycastHit hit)
    {

    }

    public override void OnGazeExit()
    {

    }
}
