using UnityEngine;
using System.Collections;

public class ColorBlue : MonoBehaviour {

    public GameObject Object;
	public bool isRendered = true;

    void Start()
    {
		// Set object color to blue
        Object.renderer.material.color = Color.blue;
    }

	void Update()
	{
		// Enable/Disable the object's renderer
		if (isRendered) 
		{
			Object.renderer.enabled = true;
		} else {
			Object.renderer.enabled = false;	
		}
	}

	// Make it possible to set the isRendered variable from other Scripts
	public void setRenderer(bool b)
	{
		isRendered = b;
	}
}
