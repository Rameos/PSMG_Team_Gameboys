using UnityEngine;
using System.Collections;
using iViewX;

public class Cut : MonoBehaviourWithGazeComponent {

    private bool startPosSet = false;
    private bool draw = false;
    private bool started = false;

    private float startPos;
    private float oldPos;
    private float distance;
    private static float X_MAX_PERCENT = 0.4f;
    private static float X_MIN_PERCENT = 0.3f;
    private static float Y_MAX_PERCENT = 0.6f;
    private static float Y_MIN_PERCENT = 0.2f;
    private static float WIN_PERCENT = 0.6f;

    private static int THICKNESS = 20;

    private double xMax;
    private double xMin;
    private double yMax;
    private double yMin;
    private double win = Screen.width * WIN_PERCENT;

    private GameObject pizza;

    private startFight fight;

    public Texture2D textureToDisplay;

	// sets the start values to the middle left edge of the pizza (OnGaze-methods don't work on guiTextures)
	void Start () {
        xMax = Screen.width * X_MAX_PERCENT;
        xMin = Screen.width * X_MIN_PERCENT;
        yMax = Screen.height * Y_MAX_PERCENT;
        yMin = Screen.height * Y_MIN_PERCENT;
	}
	
	void Update () {
        if (started == true)
        {
            //if no eyetracker is available, the player can use the mouse to cut the pizza
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
                //eyetracker is available
                checkPosition(gazeModel.posGazeRight.x, gazeModel.posGazeRight.y);
                if (draw)
                {
                    getDistance(gazeModel.posGazeRight.x, gazeModel.posGazeRight.y);
                }
            }        
        }
	}

    //sets the fight status to started
    public void setStarted(bool isStarted)
    {
        started = isStarted;
    }

    //sets the current pizza
    public void setPizza(GameObject obj)
    {
        pizza = obj;
    }

    //returns the current pizza
    public GameObject getFightingPizza()
    {
        return pizza;
    }

    void checkPosition(float x, float y)
    {
        //checks if the gaze/mouse-position is in the start area
        if (x <= xMax && x >= xMin && y <= yMax && y >= yMin)
        {
            //sets the start position
            if (!startPosSet)
            {
                startPos = x;
                startPosSet = true;
                oldPos = startPos;
                draw = true;
            }
        }
    }

    //calculates the distance from the start position to the current gaze position
    void getDistance(float x, float y)
    {
        if (y <= yMax && y >= yMin)
        {
            //just bigger distances are being considered, you can't cut the pizza "backwards"
            if (x > oldPos)
            {
                oldPos = x;
                distance = oldPos - startPos;
                //if the current gaze position reached the right middle of the pizza, the fight is over
                if (x >= win)
                {
                    fightWon();
                }
            }
        }
    }

    //if the fight is over, all values are set back to their original values
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

    //draws a red line, the length is the current distance
    void OnGUI()
    {
        if (draw)
        {
            GUI.Label(new Rect(startPos, (float)(Screen.height * 0.5), distance, THICKNESS), textureToDisplay);
        }
    }


    //OnGaze- methods do not work on guiTextures
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