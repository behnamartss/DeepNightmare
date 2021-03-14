using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthScreenManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    float health;
    // Use this for initialization
    void Start()
    {
        health = player.GetComponent<PlayerController>().health;
    }

    // Update is called once per frame

    public void LowerHealth(float damage)
    {
        //GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r,
        //          GetComponent<SpriteRenderer>().color.g,
        //          GetComponent<SpriteRenderer>().color.b,
        //            GetComponent<SpriteRenderer>().color.a +2 * .01f);
        if (Application.platform == RuntimePlatform.Android)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r,
              GetComponent<Image>().color.g,
              GetComponent<Image>().color.b,
                GetComponent<Image>().color.a + (damage) * 4 * .01f);
        }
        else
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r,
              GetComponent<Image>().color.g,
              GetComponent<Image>().color.b,
                GetComponent<Image>().color.a + (damage) * 2 * .01f);
        }
    }

    public void IncreaseHealth()
    {
        //GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r,
        //          GetComponent<SpriteRenderer>().color.g,
        //          GetComponent<SpriteRenderer>().color.b,
        //            GetComponent<SpriteRenderer>().color.a - 2* .01f);
        if (Application.platform == RuntimePlatform.Android)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r,
                    GetComponent<Image>().color.g,
                    GetComponent<Image>().color.b,
                      GetComponent<Image>().color.a - 4 * .01f);
        }
        else
        {


            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r,
                    GetComponent<Image>().color.g,
                    GetComponent<Image>().color.b,
                      GetComponent<Image>().color.a - 2 * .01f);
        }
    }
}

