using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    bool isZero = false;
    //bool isFull = true;
    [SerializeField]
    float time;
    [SerializeField]
    string destinationScene;
    [SerializeField]
    bool transition;
    // Use this for initialization
    void Start()
    {
        
    }

    private IEnumerator transitionn()
    {
        yield return new WaitForSeconds(time);
        //   Debug.Log("wrong");
        //  isFull = true;
        //     if (!isFull)
        //  {
        while(true){
            GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r,
                 GetComponent<SpriteRenderer>().color.g,
                 GetComponent<SpriteRenderer>().color.b,
                   GetComponent<SpriteRenderer>().color.a + 1 * Time.deltaTime);
            if(GetComponent<SpriteRenderer>().color.a>=250)
                SceneManager.LoadScene(destinationScene);
           
                // {
                yield return null;
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(destinationScene);
        }
        

        //  }


        //  }


    }

    // Update is called once per frame
    void Update()
    {
        if (!isZero)
        {
            if ((GetComponent<SpriteRenderer>().color.a > 0))
                GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r,
                  GetComponent<SpriteRenderer>().color.g,
                  GetComponent<SpriteRenderer>().color.b,
                    GetComponent<SpriteRenderer>().color.a - 1 * Time.deltaTime);

            else
            {
                isZero = true;
              //  isFull = false;
             
            }
        }
        else
            if(transition)
            StartCoroutine(transitionn());

      

    }
}
