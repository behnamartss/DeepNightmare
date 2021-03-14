using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraChange : MonoBehaviour
{
    [SerializeField]
    GameObject scootCamera;
    [SerializeField]
    GameObject mainCamera;
    // Use this for initialization

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.transform.GetComponentInChildren<Transform>().tag == "Player")
        {
            if (transform.name == "playerGoToScoot")
            {
              //  scootCamera.GetComponent<Camera>().depth = 0;

             //   mainCamera.GetComponent<Camera>().depth = -1;
            }
            else if(transform.name == "playerGoToIdle")
            {
              //  scootCamera.GetComponent<Camera>().depth = -1;

              //  mainCamera.GetComponent<Camera>().depth = 0;
            }
          //  Destroy(transform.gameObject);
            
        }
    }
}
