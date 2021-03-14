using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlternativeSound : MonoBehaviour {
 
    bool temp;
    // Use this for initialization
    void Start () {
        if(SceneManager.GetActiveScene().name=="Level3")
         temp = GameObject.Find("mainsong")?true:false;
        //if (SceneManager.GetActiveScene().name == "Level4")
        //    temp = GameObject.Find("alternativesound") ? true : false;
        if (temp == false)
            GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
       
    
        if (SceneManager.GetActiveScene().name == "Level4" || SceneManager.GetActiveScene().name == "MainMenu")
            Destroy(gameObject);
        else if (temp == false)
            DontDestroyOnLoad(gameObject);
    }
}
