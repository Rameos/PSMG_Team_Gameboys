using UnityEngine;
using System.Collections;

public class ColorBlue : MonoBehaviour {

    public GameObject Object;
	public bool isRendered = true;

    void Start()
    {
        Object.renderer.material.color = Color.blue;
    }

	void Update()
	{
		if (isRendered) 
		{
			Object.renderer.enabled = true;
		} else {
			Object.renderer.enabled = false;	
		}
	}

	public void setRenderer(bool b)
	{
		isRendered = b;
	}
}
