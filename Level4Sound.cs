using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level4Sound : MonoBehaviour {
    bool mainsong;
	// Use this for initialization
	void Start () {
        mainsong = GameObject.Find("mainsong") ? true : false;
        if (mainsong == false)
            GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "Level6" || SceneManager.GetActiveScene().name == "MainMenu")
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }
}
