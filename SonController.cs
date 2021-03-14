using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonController : MonoBehaviour {
    [SerializeField]
    GameObject player;
    Rigidbody2D body2d;
	// Use this for initialization
	void Start () {
        body2d = GetComponent<Rigidbody2D>();
	}


	void Update()
{
    if (Mathf.Abs(transform.position.x - player.transform.position.x) < 6)
    {
       body2d.velocity = new Vector2(-3, 0);
  
    }
    else
    {
      body2d.velocity = new Vector2(0, 0);
       
    }
}
	// Update is called once per frame
	
}

