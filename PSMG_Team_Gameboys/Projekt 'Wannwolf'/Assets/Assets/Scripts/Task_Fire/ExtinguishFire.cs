using UnityEngine;
using System.Collections;

public class ExtinguishFire : MonoBehaviour {

    private GameObject fireRadiusTrigger;
    private DrinkLogic drinkLogic;
    private PlayerControl control;
    private ParticleSystem urin;
    private CameraSwitcher switcher;
    public GUIStyle message;

    private float width = 160;
    private float height = 30;
   
    private bool extinguishable;
    public bool startPeeing = false;

    private string pressE = "Drücke \"E\" um das Feuer zu auszupinkeln";

    
    void Awake()
    {
        switcher = gameObject.GetComponent<CameraSwitcher>();
        fireRadiusTrigger = GameObject.FindGameObjectWithTag(TagManager.FIRE_RADIUS_TRIGGER);
        control = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<PlayerControl>();
        extinguishable = true;
        drinkLogic = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<DrinkLogic>();
        extinguishable = true;
        urin = GameObject.FindGameObjectWithTag(TagManager.URINSTRAHL).GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag(TagManager.FIRE) == null)
        {
            GameObject.Destroy(fireRadiusTrigger);
        }

        if (drinkLogic.inFireRadius)
        {
            if (drinkLogic.ableToUrinate && Input.GetKeyDown(KeyCode.E))
            {
                urin.particleSystem.Play(true);
                GameObject.FindGameObjectWithTag(TagManager.PLAYER).transform.position = GameObject.FindGameObjectWithTag(TagManager.PEEING_POSITION).transform.position;
                control.enabled = false;
                switcher.setCameraStatic();
                switcher.setFireTaskStatic(GameObject.FindGameObjectWithTag(TagManager.PLAYER));
                startPeeing = true;
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        drinkLogic.inFireRadius = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (drinkLogic.vodkaEmptied && extinguishable)
        {
            drinkLogic.diedInFire = true;
            drinkLogic.vodkaEmptied = false;
            extinguishable = false;
        }

       
    }

    void OnGUI()
    {
        if (drinkLogic.inFireRadius && drinkLogic.ableToUrinate)
        {
            GUI.Button(new Rect((Screen.width - (width * 2)) / 2, (float)(Screen.height * 0.2), width * 2, height), pressE, message);
        }
    }

    void OnTriggerExit(Collider other)
    {
       drinkLogic.inFireRadius = false;
       extinguishable = true;
    }
}
