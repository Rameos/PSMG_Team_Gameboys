using UnityEngine;
using System.Collections;

public class DrinkLogic : MonoBehaviour {

    public bool inFireRadius = false;
    public bool vodkaEmptied = false;
    public bool ableToUrinate = false;

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
        if (control.hasVodka && Input.GetKeyDown(KeyCode.E))
        {
            setPlayerDrunk();
            setPlayerDrinkStatus();
            
        }
    }

    void emptyVodka()
    {
        if (inFireRadius && control.hasVodka && Input.GetKeyDown(KeyCode.F))
        {
            setPlayerDrinkStatus();
            vodkaEmptied = true;
        }
    }

    void setPlayerDrinkStatus()
    {
        control.hasVodka = false;
    }

    void setPlayerDrunk()
    {
        control.drunkVodka = true;
        ableToUrinate = true;
    }
}
