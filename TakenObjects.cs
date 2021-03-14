using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakenObjects :MonoBehaviour{

    public  bool key_level6;
    [SerializeField]
    GameObject hint;
    void Update()
    {
        if (key_level6 == true)
        {
            hint.SetActive(false);
        }
    }
    public TakenObjects()
    {

    }
}
