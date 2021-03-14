using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLoadPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        yield return new WaitForSeconds(.2f);
        GameObject.Find("saving").SendMessage("NextEpisode", "riseofbullets");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
