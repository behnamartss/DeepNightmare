using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSave : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Save());

    }

    private IEnumerator Save()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("saving").SendMessage("SaveGame", "riseofbullets");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
