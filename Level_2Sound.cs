using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level_2Sound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "Level0")
            GetComponent<AudioSource>().volume = .3f;
            if (SceneManager.GetActiveScene().name == "Level1"|| SceneManager.GetActiveScene().name == "MainMenu" )
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);

    }
}
