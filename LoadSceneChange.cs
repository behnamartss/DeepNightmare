using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;

public class LoadSceneChange : MonoBehaviour {
   public
    string sceneToLoad;
	// Use this for initialization

    private void Awake()
    {

         GetComponent<Button>().onClick.AddListener(LoadScene);
     
    }

    private void LoadScene()
    {
        gameObject.SetActive(false);
        FindObjectOfType<ProgressSceneLoader>().LoadScene(sceneToLoad);
    }

   
}
