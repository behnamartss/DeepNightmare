using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyingAnimations : MonoBehaviour
{
    public bool idleMode = true;
    public bool damage = false;
    public bool death = false;
    Animator anim;

    bool temp1 = false;
   
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (idleMode)
        {
            anim.SetBool("idle", true);
            anim.SetBool("damage", false);
        }
    
        if (damage)
        {
            anim.SetBool("idle", false);
            anim.SetBool("damage", true);
        }
        if (death)
        {
            anim.SetBool("idle", false);
            anim.SetBool("damage", false);
            anim.SetBool("death", true);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(GoToDamageAndReturn());
        }

    }

    private IEnumerator GoToDamageAndReturn()
    {
        temp1 = false;
       
        //   var temp = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).GetHashCode();
        if (idleMode)
            temp1 = true;
      

        damage = true;
       
        idleMode = false;
        yield return new WaitForSeconds(.8f);
        damage = false;
        if (temp1)
            idleMode = true;

            
        
           
    
        
        //     GetComponent<Animator>().CrossFade(temp, 0.2f);



    }

  
}
