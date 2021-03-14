using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if(GetComponentInParent<EnemyKnifeController>().hit==true)
           target.GetComponentInParent<PlayerController>().gameObject.SendMessage("Damage", 1);
        }
    }
}
