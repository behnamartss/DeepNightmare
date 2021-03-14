using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level1Sound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "Level6" || SceneManager.GetActiveScene().name == "MainMenu")
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }
}
