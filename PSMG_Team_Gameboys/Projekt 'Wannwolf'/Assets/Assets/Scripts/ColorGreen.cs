using UnityEngine;
using System.Collections;

public class ColorGreen : MonoBehaviour {

    public GameObject Object;

    void Start()
    {
        Object.renderer.material.color = Color.green;
    }
}
