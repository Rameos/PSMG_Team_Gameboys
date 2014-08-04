using UnityEngine;
using System.Collections;

public class DrinkLogic : MonoBehaviour {

    public bool inFireRadius = false;
    public bool vodkaEmptied = false;
    public bool ableToUrinate = false;
<<<<<<< HEAD

=======
    public bool inPilzeria = false;
    public bool diedInFire = false;
>>>>>>> origin/Drunk-Player
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
<<<<<<< HEAD
        if (control.hasVodka && Input.GetKeyDown(KeyCode.E))
        {
            setPlayerDrunk();
            setPlayerDrinkStatus();
            
=======
        if (control.vodkaStatus && inPilzeria && Input.GetKeyDown(KeyCode.E))
        {
            setPlayerDrunk();
            setPlayerDrinkStatus(); 
>>>>>>> origin/Drunk-Player
        }
    }

    void emptyVodka()
    {
<<<<<<< HEAD
        if (inFireRadius && control.hasVodka && Input.GetKeyDown(KeyCode.F))
=======
        if (inFireRadius && control.vodkaStatus && Input.GetKeyDown(KeyCode.F))
>>>>>>> origin/Drunk-Player
        {
            setPlayerDrinkStatus();
            vodkaEmptied = true;
        }
    }

    void setPlayerDrinkStatus()
    {
<<<<<<< HEAD
        control.hasVodka = false;
=======
        control.vodkaStatus = false;
>>>>>>> origin/Drunk-Player
    }

    void setPlayerDrunk()
    {
<<<<<<< HEAD
        control.drunkVodka = true;
=======
        control.drankStatus = true;
>>>>>>> origin/Drunk-Player
        ableToUrinate = true;
    }
}
