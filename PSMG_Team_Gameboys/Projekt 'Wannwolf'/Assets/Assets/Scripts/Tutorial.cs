using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

    private GameObject player;

    public AudioClip tutorialAwake;
    public AudioClip tutorialStart;
    public AudioClip tutorialEnd;

    bool finished = false;

    private LoadHelper helper;

    bool audioIsPlaying = false;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
        helper = GameObject.FindGameObjectWithTag(TagManager.MAIN_CAMERA).GetComponent<LoadHelper>();
    }

	// Use this for initialization
	void Start () {
        audio.clip = tutorialAwake;
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (audio.isPlaying)
        {
            player.GetComponent<PlayerControl>().enabled = false;
        }
        else if (Input.GetKey(KeyCode.Space) || !audio.isPlaying)
        {
            player.GetComponent<PlayerControl>().enabled = true;
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            audio.Stop();
            player.GetComponent<PlayerControl>().enabled = true;
        }
        checkdForLoader();
	}

    private void checkdForLoader()
    {
        if (!audio.isPlaying && finished)
        {
            helper.LoadBasicMovement();
        }
    }

    public void playTutorialStart()
    {
            audio.Stop();
            audio.clip = tutorialStart;
            audio.Play();
    }

    public void playTutorialEnd()
    {
        audio.Stop();
        audio.clip = tutorialEnd;
        audio.Play();
        finished = true;
    }

}
