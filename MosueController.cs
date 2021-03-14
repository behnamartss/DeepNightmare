using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MosueController : MonoBehaviour {
   public GameObject player;
    
    // Use this for initialization
    void Start () {
        try
        {

            player = GameObject.Find("Player");
            
        }
        catch { }
      
        
	}

    // Update is called once per frame
    void Update() {
        try {
            if (player.GetComponent<PlayerController>().point >= 3 & player.GetComponent<PlayerController>().handgun
                & player.GetComponent<PlayerController>().handgunJump == false


                )
            {
                GetComponent<Button>().image.enabled = true;
                GetComponent<Button>().interactable = true;
            }
            //  if (player.GetComponent<PlayerController>().handgunJump == true)
            else
            {
                GetComponent<Button>().image.enabled = false;
                GetComponent<Button>().interactable = false;
            }


        }
        catch { }
        }
}
