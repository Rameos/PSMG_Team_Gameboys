using UnityEngine;
using System.Collections;

public class ColorRed : MonoBehaviour {
    
    public GameObject Object;

    void Start()
    {
		// Set object color to red
        Object.renderer.material.color = Color.red;
    }

    void Update()
    {
		// Render enemie's minimap icon only if the pizza is attacking the player
		if (!Object.GetComponent<Follow>().target.GetComponent<FollowPlayer>().isFollowing)
        {
            Object.renderer.enabled = false;
        }
        else
        {
			// Disable the pizza's renderer after the pizza has been defeated
			if(!Object.GetComponent<Follow>().target.GetComponent<startFight>().won)
			{
            	Object.renderer.enabled = true;
			}        
		}
    }
}
