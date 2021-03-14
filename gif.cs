using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gif : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    Texture[] frames;
    int framesPerSecond = 10;

    void Update()
    {
        //int index  = System.Convert.ToInt32( Time.time * framesPerSecond);
        //index = index % frames.Length;
        // GetComponent<Renderer>().material.mainTexture = frames[index];
    }



    //void OnGUI()
    //{
    //    int index = (int)(Time.time * 10) % 4;
    //    GetComponent<Renderer>().material.mainTexture = frames[index];
    //}
}
