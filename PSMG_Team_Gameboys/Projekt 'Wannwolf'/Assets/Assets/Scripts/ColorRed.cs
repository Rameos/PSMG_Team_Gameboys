﻿using UnityEngine;
using System.Collections;

public class ColorRed : MonoBehaviour {
    
    public GameObject Object;

    void Start()
    {
        Object.renderer.material.color = Color.red;
    }

    void Update()
    {
		if (!Object.GetComponent<Follow>().target.GetComponent<FollowPlayer>().isFollowing)
        {
            Object.renderer.enabled = false;
        }
        else
        {
			if(!Object.GetComponent<Follow>().target.GetComponent<startFight>().won)
			{
            	Object.renderer.enabled = true;
			}        
		}
    }
}
