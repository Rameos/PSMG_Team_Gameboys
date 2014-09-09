using UnityEngine;
using System.Collections;

public class CheckForWin : MonoBehaviour
{

    private int cuts = 0;
    private int currentCut = 1;
    private int nextCut = 2;

    private bool fightStarted = false;
    private bool started = true;

    private float[] sPos = new float[2];
    private float[] ePos = new float[2];



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cuts == 8)
        {
            cuts = 0;
            started = true;
            sPos[0] = 0;
            sPos[1] = 0;
            ePos[0] = 0;
            ePos[1] = 0;
            fightStarted = false;
        }
    }

    public void countCuts()
    {
        cuts++;
    }

    public int getCuts()
    {
        return cuts;
    }

    public bool getStarted()
    {
        return started;
    }

    public void setStarted(bool value)
    {
        started = value;
    }

    public float[] getStartPos()
    {
        return sPos;
    }

    public void setStartPos(float[] startPosition)
    {
        sPos = startPosition;
    }

    public float[] getEndPos()
    {
        return ePos;
    }

    public void setEndPos(float[] endPosition)
    {
        ePos = endPosition;
    }

    public bool getFightStarted()
    {
        return fightStarted;
    }

    public void setFightStarted(bool started)
    {
        fightStarted = started;
    }

    public int getCurrentCut()
    {
        return currentCut;
    }

    public void increaseCurrentCut()
    {
        currentCut++;
    }

    public int getNextCut()
    {
        return nextCut;
    }

    public void increaseNextCut()
    {
        nextCut++;
    }
}
