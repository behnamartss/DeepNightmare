using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PersianClass : MonoBehaviour {
    void Start()
    {
     GetComponent<Text>().text=  Fa.faConvert(GetComponent<Text>().text);
        if (SceneManager.GetActiveScene().name == "Level0")
            StartCoroutine(SubtitleLevel0());
        if (SceneManager.GetActiveScene().name=="Level2")
        StartCoroutine(SubtitleLevel2());

      //  LeanTween.move(gameObject,new Vector2(transform.position.x+20,transform.position.y), 3);
    }

    private IEnumerator SubtitleLevel0()
    {
      
        GetComponent<Text>().text = "باراد:پدر قرار قول میدی فردا منو ببری پیش مامان";
        GetComponent<Text>().text = Fa.faConvert(GetComponent<Text>().text);
        yield return new WaitForSeconds(2f);
        GetComponent<Text>().text = "آبتین:معلومه که میبیرمت پسرم";
        GetComponent<Text>().text = Fa.faConvert(GetComponent<Text>().text);
        yield return new WaitForSeconds(4f);
        GetComponent<Text>().text = "باراد:پس کی صبح میشه؟";
        GetComponent<Text>().text = Fa.faConvert(GetComponent<Text>().text);
        yield return new WaitForSeconds(4f);
        GetComponent<Text>().text = "پسرم،زود بخواب،میریم،باشه؟شب بخیر پسرم.";
        GetComponent<Text>().text = Fa.faConvert(GetComponent<Text>().text);
    }

    private IEnumerator SubtitleLevel2()
    {
        yield return new WaitForSeconds(3f);
        GetComponent<Text>().text = "پسرم کجاست؟؟";
        GetComponent<Text>().text = Fa.faConvert(GetComponent<Text>().text);
        yield return new WaitForSeconds(2f);
        GetComponent<Text>().text = "سرباز:من هیچی نمیدونم،لعنتی!";
        GetComponent<Text>().text = Fa.faConvert(GetComponent<Text>().text);
        yield return new WaitForSeconds(4f);
        GetComponent<Text>().text = "میگی یا یه گلوله تو سرت خالی کنم؟؟؟";
        GetComponent<Text>().text = Fa.faConvert(GetComponent<Text>().text);
        yield return new WaitForSeconds(4f);
        GetComponent<Text>().text = "برو به...";
        GetComponent<Text>().text = Fa.faConvert(GetComponent<Text>().text);
    }
}
