using UnityEngine;
using System.Collections;

public class ColorBlue : MonoBehaviour {

    public GameObject Object;

    void Start()
    {
        Object.renderer.material.color = Color.blue;
    }
}
