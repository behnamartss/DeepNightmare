using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHitPlay : MonoBehaviour {
   
    AudioSource audio;
	// Use this for initialization
	void Start () {
     audio=   GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.transform.tag == "Player")
        {
            
            audio.Play();

            StartCoroutine(Invisible());
        }
    }

    private IEnumerator Invisible()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(4f);
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }
}
