using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour
{

    // Use this for initialization
    void Awake()
    {
        StartCoroutine(load());
    }

    IEnumerator load()
    {
        yield return new WaitForSeconds(10);
        Application.LoadLevel(LoadList.getLoadString());
    }
}

