using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(MyDelay());	
	}

    private IEnumerator MyDelay()
    {
        yield return new WaitForSeconds(2);
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
