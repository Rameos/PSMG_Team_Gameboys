using UnityEngine;
using System.Collections;
using iViewX;

//[RequireComponent(typeof(CameraControl))]
[RequireComponent(typeof(RecyclePizza))]
[RequireComponent(typeof(FollowPlayer))]

public class startFight : MonoBehaviour
{
    private const float TIME_BEFORE_SUB_MUSHROOMS = 2f;

    public Transform pizza;
    public GameObject prefab;
    public Texture2D gazeCursor;
    public GameObject cutLine;

    private bool cursorAcvtive;
    private bool draw; 
    private bool drawNext; 
    private bool stat;
    private bool inTrigger;
    private bool fighting;
    private bool fClicked;
    public bool won = false;

    private int countCuts;
    private int mouseCuts = 1;
    private int eyeCuts = 2;

    private float x = 0f;
    private float y = 0f;
    private float pizzarollerScale = 0.15f;

    private RecyclePizza recycle;
    private GameObject player;
    private CameraSwitcher switcher;
    private Vector3 mushroomPosition;
    private Cut cut;



    void Start()
    {
        //cam = GetComponent<CameraControl>();
        //Debug.Log(cam);
        setValues();
        recycle = GetComponent<RecyclePizza>();
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
        switcher = pizza.GetComponent<CameraSwitcher>();
        cut = gameObject.GetComponent<Cut>();
        cutLine = GameObject.Find("PizzaCutParent");
    }

    //resets the values to its original value
    void setValues()
    {
        countCuts = 0;
        won = false;
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
        if (inTrigger)
        {
            //if f is clicked, start fight immediately
            if (Input.GetKeyDown("f"))
            {
                StopAllCoroutines();
                fight();
            }
        }
     
    }

    void checkGazePosition()
    {
        Vector3 posGaze = (gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f;
        if (posGaze.x == 0 && posGaze.y == 0)
        {
            x = Input.mousePosition.x;
            y = Input.mousePosition.y;
        }
        else
        {
            x = posGaze.x;
            y = posGaze.y;
        }
    }

    //check if fight is won
    void checkFightEndStatus()
    {
        if (won == true)
        {
            setNotFightingStatus();
            cut.setStarted(false);
            setValues();
            StopAllCoroutines();
            recycle.recycleEnemy();
            removeCut();
        }
    }

    //set status won
    public void setWon()
    {
        won = true;
    }

    //subtract mushrooms after a few seconds
    void checkPassedTimeInFight()
    {
        if (fighting)
        {
            StartCoroutine(subtractMushrooms());
        }
    }

    //substract mushrooms
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

    //if player is in radius for 5 seconds, start fight
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
        
    }

    //if player leaves the pizza radius, he is not able to fight anymore
    void OnTriggerExit(Collider col)
    {
        inTrigger = false;
        cut.setStarted(false);
    }

    //start fight after 5 seconds
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
        fighting = true;
        cut.setStarted(true);
        drawCut();   
    }

    //draws a white area where the pizza should be cut
    void drawCut()
    {
        cut.setPizza(gameObject);
        cutLine.transform.position = new Vector3(0.5f , 0.5f , 1f);
    }

    //removes white area after the fight is won
    void removeCut()
    {
        cutLine.transform.position = new Vector3(-10f, -10f, -10f);
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
        instantiateMushroom();
        fighting = false;
        GetComponent<FollowPlayer>().enabled = true;
        player.GetComponent<PlayerControl>().enabled = true;
        switcher.setCameraDynamic();
    }

    //a mushroom appears after the pizza is killed
    private void instantiateMushroom()
    {
        Instantiate(prefab, mushroomPosition, new Quaternion(0, 0, 0, 0));
    }

    void OnGUI()
    {
        //draws the gazecursor
        if (cursorAcvtive)
        {
            GUI.DrawTexture(new Rect(x, y, gazeCursor.width * pizzarollerScale, gazeCursor.height * pizzarollerScale), gazeCursor);
        }

    }
}
