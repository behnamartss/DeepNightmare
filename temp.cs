using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class temp : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
      player=  GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text>().text=player.GetComponent<PlayerController>().health.ToString();
    }
}
