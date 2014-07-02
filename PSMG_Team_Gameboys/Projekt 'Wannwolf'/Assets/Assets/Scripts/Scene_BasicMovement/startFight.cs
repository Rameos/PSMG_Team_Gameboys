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

 
    private bool draw = false;
    private bool drawNext = false;
    private float xMax = 550f;
    private float xMin = 400f;
    private float yMax = 700f;
    private float yMin = 100f;
    private float xLinePos = 430f;
    private float xLineMaxPos = 700f;
    private int countCuts = 0;
    private bool stat = false;



    void Start()
    {
       // cam = GetComponent<CameraControl>();
        //Debug.Log(cam);
        StaticCamera.enabled = false;
        MainCamera.enabled = true;

    }

    void Update()
    {
        if (countCuts == 10)
        {
            MainCamera.enabled = true;
            StaticCamera.enabled = false;
            Destroy(gameObject);

        }
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
        stat = true;
        draw = true;
 


        
    }

    void OnGUI()
    {
        if (draw == true && countCuts <11)
        {
            xLinePos = 430f;
            for (int i = 0; i < 10; i++)
            {
                GUI.color = Color.yellow;
                GUI.Box(new Rect(xLinePos, 280, 50, 50), "---------");
                xLinePos += 50;
            }
           
 
        }
        if (drawNext == true )
        {
            xLinePos = 430f;
            for (int i = 0; i < countCuts; i++)
            {
                GUI.color = Color.red;
                GUI.Box(new Rect(xLinePos, 280, 50, 50), "---------");
                xLinePos += 50;
            }
           
        }
    }

    public override void OnGazeEnter(RaycastHit hit)
    {
       

    }
    public override void OnGazeStay(RaycastHit hit)
    {
        drawLine();
       

    }

    public void OnMouseDown()
    {
        drawLine();

    }

    void drawLine()
    {
        if (stat == true)
        {
            Debug.Log("Gaze");

            if (gazeModel.posGazeRight.x >= xMin && gazeModel.posGazeRight.x <= xMax && gazeModel.posGazeRight.y >= yMin && gazeModel.posGazeRight.y <= yMax)
            {
                Debug.Log("cut");
                xMin += 50;
                xMax += 50;
                countCuts++;
                //draw = false;
                drawNext = true;
            }
        }

    }

    //Reset the Element.Transform when the gaze leaves the Collider
    public override void OnGazeExit()
    {
       
    }
}
