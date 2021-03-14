using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrenadeController : MonoBehaviour {
    GameObject grenade;
    GameObject player;
    [SerializeField]
    ParticleSystem explosionParticle;
    string currentScene;
	// Use this for initialization
	void Start () {
         currentScene = SceneManager.GetActiveScene().name;

        // scalingClass.ChooseScale(explosionParticle.transform, currentScene);
        ScalingClass scalingClass = new ScalingClass();
        scalingClass.ChooseScale(transform, currentScene);
        // GameObject.Find("scalingobject").GetComponent<ScalingClass>().ChooseScale(transform, currentScene);

        player = GameObject.Find("Player");
       GetComponent<Rigidbody2D>().velocity =transform.rotation * Vector2.up * (Mathf.Abs((player.transform.position.x - transform.position.x)));
    
        Invoke("Explosion", 3);
   
    }

  void Explosion()
    {
      //< 4.5
            if (Mathf.Abs(player.transform.position.x - transform.position.x) < transform.localScale.x * 10+.5 & (player.transform.position.y - transform.position.y) < transform.localScale.y * 10 + .5)
                player.gameObject.SendMessage("Damage", 6);
        GetComponent<SpriteRenderer>().sprite = null;
        GetComponent<AudioSource>().Play();
        Instantiate(explosionParticle, transform);
        Invoke("Die", .3f);

        //    explosionParticle.GetComponentInChildren<ParticleSystem>().Play();


    }
    void Die()
    {
        
          Destroy(transform.gameObject);
    }



    // Update is called once per frame
    void Update () {
      
    }
}
