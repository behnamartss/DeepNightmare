using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DoorBroke : MonoBehaviour {
    Rigidbody2D rb;
    [SerializeField]
    bool Brokable;
    TakenObjects takenObjects;
    // Use this for initialization
    void Start () {
        if(Brokable)
        StartCoroutine(broke());
        takenObjects = new TakenObjects();



        rb = GetComponent<Rigidbody2D>();
    
        
    }
    
    private IEnumerator broke()
    {
        yield return new WaitForSeconds(1f) ;
        GetComponent<AudioSource>().Play();
   GetComponent<Rigidbody2D>().AddForce(new Vector2(-270, 0));
        yield return new WaitForSeconds(2f);
         GetComponent<BoxCollider2D>().enabled = false;
        Destroy(GetComponent<Rigidbody2D>());

    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D target)
    {
       
        if (target.transform.tag == "Player")
        {
            
            switch (SceneManager.GetActiveScene().name)
            {

                case "Level6":
                    if (GameObject.Find("takenObjects").GetComponent<TakenObjects>().key_level6 == true)
                    {
                      //  GetComponent<BoxCollider2D>().enabled = false;
                      //  GameObject.Find("keyicon").GetComponent<Image>().enabled = false;
                      //  Debug.Log("workin");
                        SceneManager.LoadScene("Level7");
                    }
                    
                    break;
            }

        }
    }
}
