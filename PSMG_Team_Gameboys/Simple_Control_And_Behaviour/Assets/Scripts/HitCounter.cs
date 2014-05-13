using UnityEngine;
using System.Collections;

public class HitCounter : MonoBehaviour {

    private int hitNumber;

    void Awake()
    {
        hitNumber = 0;
    }
    
    public int HitNumber
    {
        set 
        {
            hitNumber += value;
        }
        get
        {
            return hitNumber;
        }
    }

    public void increaseHitNumber()
    {
        hitNumber++;
    }
}
