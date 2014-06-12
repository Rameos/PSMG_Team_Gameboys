using UnityEngine;
using System.Collections;

public class ColorRed : MonoBehaviour {

    public GameObject Object;

    void Start()
    {
        Object.renderer.material.color = Color.red;
    }
}
