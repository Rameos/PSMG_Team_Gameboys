using UnityEngine;
using System.Collections;
using iViewX;

//[RequireComponent(typeof(CameraControl))]
[RequireComponent(typeof(RecyclePizza))]

public class startFight : MonoBehaviourWithGazeComponent
{

 //CameraControl cam;
    public Camera MainCamera;
    public Camera StaticCamera;
    public Transform pizza;

 
    private bool draw = false;
    private bool drawNext = false;
    private float xMaxMouse;
    private float xMinMouse;
    private float xMaxEye;
    private float xMinEye;
    private float yMax;
    private float yMin;
    private float xLinePos;
    private float xLineMaxPos;
    private float yLinePos;
    private int countCuts;
    private bool stat = false;
    private int mouseCuts = 1;
    private int eyeCuts = 2;
    private float mousePos = 50;
    private float eyePos = 100;
    private RecyclePizza recycle;
    private bool fClicked = false;
    bool inTrigger = false;



    void Start()
    {
       // cam = GetComponent<CameraControl>();
        //Debug.Log(cam);
        StaticCamera.enabled = false;
        MainCamera.enabled = true;
        setValues();
        recycle = GetComponent<RecyclePizza>();
        

    }

    void setValues()
    {
        xLinePos = (Screen.width - Screen.width / 2) - 250;
        yLinePos = (Screen.height - Screen.height / 2) - 50;
        xMaxMouse = xLinePos + 50;
        xMinMouse = xLinePos - 50;
        xMaxEye = xLinePos + 80;
        xMinEye = xLinePos - 80;
        yMax = yLinePos + 200;
        yMin = yLinePos - 100;
        stat = false;
        draw = false;
        countCuts = 0;
        fClicked = false;

    }

    void Update()
    {
        if (countCuts == 10)
        {
            MainCamera.enabled = true;
            StaticCamera.enabled = false;
            setValues();
            StopAllCoroutines();
            recycle.recycleEnemy();
        }
      
            checkMousePosition();
            checkGazePosition();
        
    }

   


    void OnTriggerEnter(Collider col)
    {

       

        if (col.gameObject.tag == "Player")
        {
            inTrigger = true;
            StartCoroutine(startPizzaFight(5));
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            inTrigger = true;
            if (Input.GetKeyDown("f"))
            {
                Debug.Log("f clicked");
                StopAllCoroutines();
                fight();
            }
        }

    }

    void OnTriggerExit(Collider col)
    {
        inTrigger = false;

    }

    IEnumerator startPizzaFight(float seconds)
    {
        
    
        yield return new WaitForSeconds(seconds);
        if (inTrigger == true)
        {
            if (fClicked == false)
            {
                fight();
            }
        }
       
 


        
    }

    void fight()
    {
        MainCamera.enabled = false;
        StaticCamera.enabled = true;

        GetComponent<FollowPlayer>().enabled = false;
        rotatePizza();

        stat = true;
        draw = true;

    }

    void rotatePizza()
    {
        float currentX = pizza.eulerAngles.x;
        float currentY = pizza.eulerAngles.y;
        float currentZ = pizza.eulerAngles.z;
        pizza.Rotate(currentX - 90, currentY - 180, currentZ -0);
        print("" + currentX + ", " + currentY + ", " + currentZ);

    }

    void OnGUI()
    {
        if (draw == true && countCuts <11)
        {
            xLinePos = (Screen.width - Screen.width / 2) - 250; 
            for (int i = 0; i < 10; i++)
            {
                GUI.color = Color.yellow;
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

        //checkGazePosition();
       

    }

    void checkGazePosition()
    {
        if (gazeModel.posGazeRight.x >= xMinEye && gazeModel.posGazeRight.x <= xMaxEye && gazeModel.posGazeRight.y >= yMin && gazeModel.posGazeRight.y <= yMax)
        {
            drawLine(eyePos, eyeCuts);

        }

    }


    void checkMousePosition()
    {
        if (Input.mousePosition.x >= xMinMouse && Input.mousePosition.x <= xMaxMouse && Input.mousePosition.y >= yMin && Input.mousePosition.y <= yMax)
        {
            drawLine(mousePos, mouseCuts);
        }

    }

    void drawLine(float pos, int cuts)
    {
        if (stat == true)
        {

            xMinMouse += pos;
            xMaxMouse += pos;
            xMinEye += pos;
            xMaxEye += pos;
            countCuts += cuts;
            drawNext = true;
        }
               
            

    }

    //Reset the Element.Transform when the gaze leaves the Collider
    public override void OnGazeExit()
    {
       
    }
}
