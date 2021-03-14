using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    string changeSceneTo;
    [SerializeField]
    string causeObject;
    [SerializeField]
    bool transitionInTime;
    [SerializeField]
    float time;
    [SerializeField]
    string destinationScene;
    // Use this for initialization
    void Start()
    {
        if (transitionInTime)
            StartCoroutine(Transition());

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Transition()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(destinationScene.ToString());
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.transform.gameObject.name == causeObject)
        {
            SceneManager.LoadScene(changeSceneTo.ToString());
            Debug.Log("ok");
        }

        else if (col.transform.gameObject.GetComponentInChildren<Transform>().tag == causeObject)
        {
            SceneManager.LoadScene(changeSceneTo.ToString());
            Debug.Log("ok");
        }

    }
}
