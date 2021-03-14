using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonAnimation : MonoBehaviour {

    [SerializeField]
    GameObject player;
    Animator anim;
    Rigidbody2D body2d;
    bool facingLeft = true;
	void Start () {

        anim = GetComponent<Animator>();
          StartCoroutine(PlayLaughing());
    
    }

    private IEnumerator PlayLaughing()
    {
        while (true){

            yield return new WaitForSeconds(10f);
          //  if(facingLeft)
        GetComponent<AudioSource>().Play();
           
        }
       
    }



    // Update is called once per frame
    void FixedUpdate () {
        // GetComponent<AudioSource>().spatialBlend = 1;
        if (Mathf.Abs(transform.position.x - player.transform.position.x) < 3)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-6, 0);
        }
        else
            if (Mathf.Abs(transform.position.x - player.transform.position.x) < 9)
        {

            anim.SetBool("run", true);
            anim.SetBool("idle", false);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-4, 0);
            if (!facingLeft)
            {
                transform.Rotate(Vector3.up * 180);
                facingLeft = true;
            }
        }
        else
        {

            anim.SetBool("run", false);
            anim.SetBool("idle", true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            if (facingLeft)
            {
                transform.Rotate(Vector3.up * 180);
                facingLeft = false;
            }
        }
        //GetComponent<Rigidbody2D>().velocity = new Vector2(-3, 0);
        //   anim.SetBool("run", true);
        //    anim.SetBool("idle", false);
    }
   
}
