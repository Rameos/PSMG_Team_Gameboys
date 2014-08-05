using UnityEngine;
using System.Collections;

public class DrinkLogic : MonoBehaviour {

    public bool inFireRadius = false;
    public bool vodkaEmptied = false;
    public bool ableToUrinate = false;

    public bool inPilzeria = false;
    public bool diedInFire = false;

    private PlayerControl control;

	// Use this for initialization
	void Awake () {
	    control = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
	}

    void Update()
    {
        drinkVodka();
        emptyVodka();
    }

    void drinkVodka()
    {
        if (control.vodkaStatus && inPilzeria && Input.GetKeyDown(KeyCode.E))
        {
            setPlayerDrunk();
            setPlayerDrinkStatus(); 
        }
    }

    void emptyVodka()
    {
        if (inFireRadius && control.vodkaStatus && Input.GetKeyDown(KeyCode.F))
        {
            setPlayerDrinkStatus();
            vodkaEmptied = true;
        }
    }

    void setPlayerDrinkStatus()
    {
        control.vodkaStatus = false;
    }

    void setPlayerDrunk()
    {
        control.drankStatus = true;
        ableToUrinate = true;
    }
}
