using UnityEngine;
using System.Collections;

public class DrinkLogic : MonoBehaviour {

    public bool inFireRadius = false;
    public bool vodkaEmptied = false;
    public bool urinating = false;

    private PlayerControl control;

	// Use this for initialization
	void Awake () {
	    control = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
	}
	

    void drinkVodka()
    {
        if (control.hasVodka && Input.GetKeyDown(KeyCode.E))
        {
            setPlayerDrunk();
            setPlayerDrinkStatus();
        }
    }

    void emptyVodka()
    {
        if (control.hasVodka && Input.GetKeyDown(KeyCode.F))
        {
            setPlayerDrinkStatus();
            if (inFireRadius)
            {
                vodkaEmptied = true;
            }
        }
    }

    void setPlayerDrinkStatus()
    {
        control.hasVodka = false;
    }

    void setPlayerDrunk()
    {
           control.drunkVodka = true; 
    }
}
