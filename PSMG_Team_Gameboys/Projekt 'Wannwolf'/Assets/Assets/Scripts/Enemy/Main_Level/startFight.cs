using UnityEngine;
using System.Collections;
using iViewX;

//[RequireComponent(typeof(CameraControl))]
[RequireComponent(typeof(RecyclePizza))]
[RequireComponent(typeof(FollowPlayer))]

public class startFight : MonoBehaviourWithGazeComponent
{
    private const float TIME_BEFORE_SUB_MUSHROOMS = 2f;

    public Transform pizza;
    public GameObject prefab;
    public Texture2D gazeCursor;

    private bool cursorAcvtive;
    private bool draw; 
    private bool drawNext; 
    private bool stat;
    private bool inTrigger;
    private bool fighting;
    private bool fClicked;

    private float xMaxMouse;
    private float xMinMouse;
    private float xMaxEye;
    private float xMinEye;
    private float yMax;
    private float yMin;
    private float xLinePos;
    private float xLineMaxPos;
    private float yLinePos;
    private float mousePos = 50;
    private float eyePos = 100;

    private int countCuts;
    private int mouseCuts = 1;
    private int eyeCuts = 2;

    private RecyclePizza recycle;
    private GameObject player;
    private CameraSwitcher switcher;
    private Vector3 mushroomPosition;



    void Start()
    {
        //cam = GetComponent<CameraControl>();
        //Debug.Log(cam);
        setValues();
        recycle = GetComponent<RecyclePizza>();
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
        switcher = pizza.GetComponent<CameraSwitcher>();
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

        countCuts = 0;
        
        stat = false;
        draw = false;
        fClicked = false;
        cursorAcvtive = false;
        fighting = false;
        inTrigger = false;
        drawNext = false;

    }

    void Update()
    {
        checkPassedTimeInFight();
        checkFightEndStatus();
        checkEyetrackerAvailable();      
    }

    void checkEyetrackerAvailable()
    {
        if (gazeModel.posGazeRight.x == 0 && gazeModel.posGazeRight.y == 0)
        {
            checkMousePosition();
        }
        checkGazePosition();
    }

    void checkFightEndStatus()
    {
        if (countCuts == 10)
        {
            setNotFightingStatus();
            setValues();
            StopAllCoroutines();
            recycle.recycleEnemy();
        }
    }

    void checkPassedTimeInFight()
    {
        if (fighting)
        {
            StartCoroutine(subtractMushrooms());
        }
    }

    IEnumerator subtractMushrooms()
    {
        yield return new WaitForSeconds(TIME_BEFORE_SUB_MUSHROOMS);
        if(Time.fixedDeltaTime >= 1)
        {
            player.GetComponent<MoneyManagement>().subtractMoney(1);
            Time.fixedDeltaTime = 0;
        }
        Time.fixedDeltaTime += Time.deltaTime;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == TagManager.PLAYER)
        {
            inTrigger = true;
            StartCoroutine(startPizzaFight(5));
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == TagManager.PLAYER)
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
        cursorAcvtive = true;
        setFightStatus();
        stat = true;
        draw = true;
        fighting = true;
    }

    void rotatePizza()
    {
        pizza.rotation = new Quaternion(0,0,0,0);
        /*float currentX = pizza.eulerAngles.x;
        float currentY = pizza.eulerAngles.y;
        float currentZ = pizza.eulerAngles.z;
        pizza.Rotate(currentX - 90, currentY - 180, currentZ -0);
        print("" + currentX + ", " + currentY + ", " + currentZ);*/
    }

    void setFightStatus()
    {
        GetComponent<FollowPlayer>().enabled = false;
        //rotatePizza();
        player.GetComponent<PlayerControl>().enabled = false;
        switcher.setCameraStatic();
        switcher.setCameraFocus(gameObject);
        mushroomPosition = pizza.transform.position;
    }

    void setNotFightingStatus()
    {
        fighting = false;
        instantiateMushroom();
        GetComponent<FollowPlayer>().enabled = true;
        player.GetComponent<PlayerControl>().enabled = true;
        switcher.setCameraDynamic();
    }

    private void instantiateMushroom()
    {
        Instantiate(prefab, mushroomPosition, new Quaternion(0, 0, 0, 0));
    }

    void OnGUI()
    {
        if (cursorAcvtive)
        {
            Vector3 posGaze = (gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f;
            GUI.DrawTexture(new Rect(posGaze.x, posGaze.y, gazeCursor.width, gazeCursor.height), gazeCursor);
        }

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
