using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject panel;
    string sceneToLoad;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MakeSure()
    {
        panel.SetActive(true);
    }
    public void Yes()
    {

    }
    public void No()
    {
        panel.SetActive(false);
    }
    public void Continue()
    {
        GameObject.Find("Continue").GetComponent<Button>().interactable = false;
        //  FindObjectOfType<ProgressSceneLoader>().LoadScene(sceneToLoad);
         GameObject.Find("saving").GetComponent<NewSaveData>().LoadGame("riseofbullets");
    }
}
