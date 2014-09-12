using UnityEngine;
using System.Collections;
using iViewX;


public class CutPizza : MonoBehaviourWithGazeComponent
{

    private bool cut = false;
    private bool draw = false;
    private bool start = true;
    private bool ended = true;

    private CheckForWin check;

    private int width = 50;

    private float oldPos = 0f;
    private float newPos = 0f;
    private float startPosition;
    private float eyePos = 0;
    private float maxEyePos = 0;

    private float[] pos1 = new float[2];
    private float[] pos2 = new float[2];
    private float[] startPos = new float[2];
    private float[] endPos = new float[2];
    

    public Texture2D textureToDisplay;


	void Start () {
        check = GameObject.Find("PizzaCutParent").GetComponent<CheckForWin>();
	}

    void Update()
    {
        checkForWin();
        if (check.getFightStarted() == true)
        {
            if (gazeModel.posGazeRight.x != 0 && gazeModel.posGazeRight.y != 0)
            {
                checkEyetracker();
            }
        }
    }

    void checkForWin()
    {
        if (check.getCuts() == 8)
        {
            cut = false;
            draw = false;
            oldPos = 0f;
        }

    }

    void checkEyetracker()
    {
        if (gazeModel.posGazeRight.y <= 510 && gazeModel.posGazeRight.y >= 350)
        {
            if (gazeModel.posGazeRight.x <= 400 && gazeModel.posGazeRight.x >= 300)
            {
                enter(gazeModel.posGazeRight.x, gazeModel.posGazeRight.y);
                
            }

            if (draw == true)
            {
                eyeOver();
            }
        }
    }



    void eyeOver()
    {
        if (gazeModel.posGazeRight.x >= eyePos && gazeModel.posGazeRight.x <= maxEyePos)
        {

            eyePos = gazeModel.posGazeRight.x;
            eyePos += 10;
            maxEyePos = eyePos + 50;
            endPos[0] = maxEyePos;
            endPos[1] = gazeModel.posGazeRight.y;
            check.setEndPos(endPos);
            if (eyePos >= 800)
            {
                for (int i = 0; i < 8; i++)
                {
                    check.countCuts();
                }
            }
            eyePos += 50;
            maxEyePos += 70;
        }
    }

    void checkEnter(float x)
    {
        if (gameObject.transform.name == "1")
        {
            Debug.Log("enter");
            enter(Input.mousePosition.x, Input.mousePosition.y);
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

    void OnMouseEnter()
    {
        checkCuts();
        if (gazeModel.posGazeRight.x == 0 && gazeModel.posGazeRight.y == 0)
        {
            checkEnter(Input.mousePosition.x);
        }
        
    }

    void checkCuts()
    {
        string a = gameObject.transform.name.ToString();
        int i = int.Parse(a);
        if (i == check.getCurrentCut())
        {
            if (cut == false)
            {
                check.countCuts();
                cut = true;
            }
            check.increaseCurrentCut();
        }
    }

    void enter(float x, float y)
    {
        if (check.getStarted() == true)
        {
            draw = true;
            startPosition = x;
            startPos[0] = x;
            startPos[1] = y;
            eyePos = startPosition + 20;
            maxEyePos = eyePos + 20;
            check.setStartPos(startPos);
            check.setStarted(false);
        }
    }


    void OnMouseOver()
    {
        if (gazeModel.posGazeRight.x == 0 && gazeModel.posGazeRight.y == 0)
        {
            over(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    void over(float x, float y)
    {
        endPos[0] = x;
        endPos[1] = y;
        newPos = x;

        string a = gameObject.transform.name.ToString();

        int i = int.Parse(a);
        if (i == check.getNextCut())
        {
            if (endPos[0] > oldPos)
            {
                check.setEndPos(endPos);
                oldPos = endPos[0];

            }
            
            check.increaseNextCut();
        }
        
    }

   
    void OnGUI()
    {
        pos1 = check.getStartPos();
        pos2 = check.getEndPos();
        if (draw == true && pos2[0] != 0)
        {
            float distance = pos2[0] - startPosition;
            if (distance < 0)
            {
                distance *= -1;
            }
            GUI.backgroundColor = Color.red;
            GUI.Label(new Rect(startPosition, 440, distance, 10), textureToDisplay);
            
           
        }
    }
}