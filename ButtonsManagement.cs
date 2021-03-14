using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonsManagement : MonoBehaviour
{
    [SerializeField]
    bool gunMode;
    GameObject player;
    [SerializeField]
    GameObject btnShootRight;
    [SerializeField]
    GameObject btnSitRight;
    [SerializeField]
    GameObject btnShootLeft;
    [SerializeField]
    GameObject btnSitLeft;
    float temp;
    [SerializeField]
    GameObject pausePanel;
    Button[] buttons;
    //[SerializeField]
    //GameObject conitune;
    //[SerializeField]
    //GameObject menu;
    // Use this for initialization
    void Start()
    {
        try
        {
            player = GameObject.Find("Player");

        }
        catch { }
        //if (gunMode)
        //{
        //    var camera = GameObject.Find("Main Camera");
        //    if (camera.GetComponent<CameraFollow>().rightToLeft)
        //    {
        //        try
        //        {
        //            GameObject.Find("btnShootRight").SetActive(false);
        //            GameObject.Find("btnShootLeft").SetActive(true);
        //            GameObject.Find("btnSitLeft").SetActive(true);
        //            GameObject.Find("btnSitRight").SetActive(false);
        //        }
        //        catch { }
        //    }
        //    else if (!camera.GetComponent<CameraFollow>().rightToLeft)
        //    {
        //        try
        //        {
        //            GameObject.Find("btnShootRight").SetActive(true);
        //            GameObject.Find("btnShootLeft").SetActive(false);
        //            GameObject.Find("btnSitLeft").SetActive(false);
        //            GameObject.Find("btnSitRight").SetActive(true);
        //        }
        //        catch { }
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        buttons = FindObjectsOfType<Button>();
        try
        {
            if (player.GetComponent<PlayerController>().headShotMode == true)
                for (int i = 0; i < buttons.Length; i++)
                    buttons[i].interactable = false;
            else
            {
                for (int i = 0; i < buttons.Length; i++)
                    buttons[i].interactable = true;
                if (player.GetComponent<PlayerController>().facingLeft)
                {
                    try
                    {
                        //GameObject.Find("btnShootRight").gameObject.SetActive(false);
                        //GameObject.Find("btnShootLeft").gameObject. SetActive(true);
                        //GameObject.Find("btnSitLeft").gameObject.SetActive(true);
                        //GameObject.Find("btnSitRight").gameObject.SetActive(false);
                        btnShootRight.SetActive(false);

                        btnShootLeft.gameObject.SetActive(true);
                        btnSitLeft.gameObject.SetActive(true);
                        btnSitRight.gameObject.SetActive(false);
                    }
                    catch { }
                }
                else if (!player.GetComponent<PlayerController>().facingLeft)
                {
                    try
                    {
                        //GameObject.Find("btnShootRight").gameObject.SetActive(true);
                        //GameObject.Find("btnShootLeft").gameObject.SetActive(false);
                        //GameObject.Find("btnSitLeft").gameObject.SetActive(false);
                        //GameObject.Find("btnSitRight").gameObject.SetActive(true);
                        if (GameObject.Find("Player").GetComponent<PlayerController>().headShotMode == false)
                            btnShootRight.gameObject.SetActive(true);
                        btnShootLeft.gameObject.SetActive(false);
                        btnSitLeft.gameObject.SetActive(false);
                        btnSitRight.gameObject.SetActive(true);
                    }
                    catch { }
                }
            }
        }
        catch { }
    }
    public void Pause()
    {
        temp = Time.timeScale;
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void Continue()
    {
        Time.timeScale = temp;
        pausePanel.SetActive(false);
    }
    public void Menu()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
