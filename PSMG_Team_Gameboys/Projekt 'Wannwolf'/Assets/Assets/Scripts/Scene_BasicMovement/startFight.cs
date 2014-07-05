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
    private float xMax;
    private float xMin;
    private float yMax;
    private float yMin;
    private float xLinePos;
    private float xLineMaxPos;
    private float yLinePos;
    private int countCuts = 0;
    private bool stat = false;



    void Start()
    {
       // cam = GetComponent<CameraControl>();
        //Debug.Log(cam);
        StaticCamera.enabled = false;
        MainCamera.enabled = true;
        xLinePos = (Screen.width - Screen.width / 2) - 250;
        yLinePos = (Screen.height - Screen.height / 2) - 50;
        xMax = xLinePos + 50;
        xMin = xLinePos - 50;
        yMax = yLinePos + 200;
        yMin = yLinePos - 100;
        

    }

    void Update()
    {
        if (countCuts == 10)
        {
            MainCamera.enabled = true;
            StaticCamera.enabled = false;
            Destroy(gameObject);

        }
        checkMousePosition();
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
            xLinePos = (Screen.width - Screen.width / 2) - 250; 
            for (int i = 0; i < 10; i++)
            {
                GUI.color = Color.yellow;
                string pos = Input.mousePosition.x.ToString();
                GUI.Box(new Rect(xLinePos, yLinePos, 50, 50), "---------");
                xLinePos += 50;
            }
           
 
        }
        if (drawNext == true )
        {
            xLinePos = (Screen.width - Screen.width / 2) - 250;
            for (int i = 0; i < countCuts; i++)
            {
                GUI.color = Color.red;
                GUI.Box(new Rect(xLinePos, yLinePos, 50, 50), "---------");
                xLinePos += 50;
            }
           
        }
    }

    public override void OnGazeEnter(RaycastHit hit)
    {
       

    }
    public override void OnGazeStay(RaycastHit hit)

    {
        if (gazeModel.posGazeRight.x >= xMin && gazeModel.posGazeRight.x <= xMax && gazeModel.posGazeRight.y >= yMin && gazeModel.posGazeRight.y <= yMax)
        {
            drawLine();
        
        }
        
       

    }


    void checkMousePosition()
    {
        if (Input.mousePosition.x >= xMin && Input.mousePosition.x <= xMax && Input.mousePosition.y >= yMin && Input.mousePosition.y <= yMax)
        {
            drawLine();
        }

    }

    void drawLine()
    {
        if (stat == true)
        {

                xMin += 50;
                xMax += 50;
                countCuts++;
                //draw = false;
                drawNext = true;
               
            
        }

    }

    //Reset the Element.Transform when the gaze leaves the Collider
    public override void OnGazeExit()
    {
       
    }
}
