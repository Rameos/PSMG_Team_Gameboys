﻿using UnityEngine;
using System.Collections;

public class ReplacementHUDLogic : MonoBehaviour {

    public int hasPieces = 0;

    public Texture2D lenker;
    public Texture2D rad;
    public Texture2D turbine;

    private int animationPlayed;

	// Use this for initialization
	void Start () {
        animationPlayed = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        updateHUD(hasPieces);
	}

    // Display the picked ersatzteil with 100% opacity instead of 50%
    void updateHUD(int counter)
    {
        print("counter: " + counter);
        switch (counter)                
        {
            case 1:
                caseOnePiece();
                break;
            case 2:
                caseOnePiece();
                casePieceTwo();
                break;
            case 3:
                caseOnePiece();
                casePieceTwo();
                casePieceThree();
                break;
        }
    }

    void caseOnePiece()
    {
        GameObject.FindGameObjectWithTag(TagManager.LENKER).GetComponent<GUITexture>().texture = lenker;
        if (animationPlayed == 0)
        {
            GameObject.FindGameObjectWithTag(TagManager.LENKER).animation.CrossFade("Highlight_Lenker", 0f);
            animationPlayed++;
        }
    }

    void casePieceTwo()
    {
        GameObject.FindGameObjectWithTag(TagManager.RAD).GetComponent<GUITexture>().texture = rad;

        if (animationPlayed == 1)
        {
            GameObject.FindGameObjectWithTag(TagManager.RAD).animation.CrossFade("Highlight_Rad", 0f);
            animationPlayed++;
        }
    }

    void casePieceThree()
    {
        GameObject.FindGameObjectWithTag(TagManager.TURBINE).GetComponent<GUITexture>().texture = turbine;
        if (animationPlayed == 2)
        {
            GameObject.FindGameObjectWithTag(TagManager.TURBINE).animation.CrossFade("Highlight_Turbine", 0f);
        }
    }
}
