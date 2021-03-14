using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(move());
	}

    private IEnumerator move()
    {
         
        while (true)
        {
           
            yield return new WaitForSeconds(.5f);
            gameObject.transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, 5, 0),Time.deltaTime);
            yield return new WaitForSeconds(.5f);
            gameObject.transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, -10, 0), Time.deltaTime);
            yield return new WaitForSeconds(.01f);
            gameObject.transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, 5, 0), Time.deltaTime);





        }
       
    }

    // Update is called once per frame
    void Update () {
		
	}
}
