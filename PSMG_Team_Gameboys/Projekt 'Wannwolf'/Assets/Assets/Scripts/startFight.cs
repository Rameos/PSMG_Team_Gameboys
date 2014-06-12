using UnityEngine;
using System.Collections;
using iViewX;

//[RequireComponent(typeof(CameraControl))]

public class startFight : MonoBehaviourWithGazeComponent
{

 //CameraControl cam;
    public Camera MainCamera;
    public Camera StaticCamera;
    private GameObject pizza;

    public Rect position = new Rect(16, 16, 128, 24);
    public Color color = Color.yellow;

    private bool draw = false;
    private bool drawNext = false;
    private float xMax = 400f;
    private float xMin = 00f;
    private float yMax = 550f;
    private float yMin = 350f;
    private float xLinePos = 250f;
    private float xLineMaxPos = 700f;
    private int countCuts = 0;



    void Start()
    {
       // cam = GetComponent<CameraControl>();
        //Debug.Log(cam);
        StaticCamera.enabled = false;
        MainCamera.enabled = true;

    }


    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(startPizzaFight(5));
        }
    }

    IEnumerator startPizzaFight(float seconds)
    {
        
    
        yield return new WaitForSeconds(seconds);
        Debug.Log("5 Sekunden");

        MainCamera.enabled = false;
        StaticCamera.enabled = true;
        draw = true;
 


        
    }

    void OnGUI()
    {
        if (draw == true)
        {

            GUI.color = Color.yellow;
            GUI.Box(new Rect(xLinePos, 400, 50, 50), "---------");
 
        }
        if (drawNext == true && xLinePos <= xLineMaxPos)
        {
            xLinePos = 250f;
            for (int i = 0; i < countCuts; i++)
            {
                GUI.color = Color.red;
                GUI.Box(new Rect(xLinePos, 400, 50, 50), "---------");
                xLinePos += 50;
            }
            GUI.color = Color.yellow;
            GUI.Box(new Rect(xLinePos, 400, 50, 50), "---------");
        }
    }

    public override void OnGazeEnter(RaycastHit hit)
    {

        if (gazeModel.posGazeRight.x >= xMin && gazeModel.posGazeRight.x <= xMax && gazeModel.posGazeRight.y >= yMin && gazeModel.posGazeRight.y <= yMax)
        {
            Debug.Log("cut");
            xMin += 50;
            xMax += 50;
            countCuts++;
            draw = false;
            drawNext = true;
        }

    }
    public override void OnGazeStay(RaycastHit hit)
    {

    }

    //Reset the Element.Transform when the gaze leaves the Collider
    public override void OnGazeExit()
    {
       
    }
}
