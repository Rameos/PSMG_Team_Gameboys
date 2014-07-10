using UnityEngine;
using System.Collections;
using iViewX;



public class StopFire : MonoBehaviourWithGazeComponent
{


    private bool cursorAcvtive = false;
    public Texture2D gazeCursor;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

       

    }

    void OnGUI()
    {
        if (cursorAcvtive)
        {
            Vector3 posGaze = (gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f;
            GUI.DrawTexture(new Rect(posGaze.x, posGaze.y, gazeCursor.width, gazeCursor.height), gazeCursor);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        cursorAcvtive = true;
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
