using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headDetector : MonoBehaviour
{
    Vector3 prePosition;
    //  GameObject camera;
    // Use this for initialization
    void Start()
    {
        // Debug.Log(GetComponentInParent<Transform>().name);
        //camera = GameObject.Find("Main Camera");
        float firstSize = Camera.main.GetComponent<Camera>().orthographicSize;
        StartCoroutine(die());
        prePosition = transform.position;
        GetComponent<Rigidbody2D>().velocity = transform.rotation * Vector2.up * 80;

    }

    private IEnumerator die()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        prePosition = transform.position;
        //  transform.Translate(transform.rotation * Vector3.up * 20);
        // RaycastHit[] hits = Physics.RaycastAll(new Ray(prePosition, (transform.position - prePosition).normalized), (transform.position - prePosition).magnitude);
        int mask = (1 << 8);
        RaycastHit2D hits = Physics2D.Raycast(prePosition, transform.rotation * Vector2.up * 80, 1000, mask);
        Debug.DrawRay(transform.position, prePosition, Color.blue);
        if (hits.collider)
        {
            if (hits.collider.gameObject.tag == "head")
            {

                Debug.Log("detector_headshot");
                try
                {
                    var bullet = GameObject.Find(gameObject.name);
                    if (bullet.tag == "playerBullet")
                        bullet.GetComponent<PlayerBullet>().SendMessage("HeadShot", hits.collider.transform);
                }
                catch { }
                //Camera.main.GetComponent<Camera>().enabled = false;
                //if (bullet.tag == "playerBullet") 
                //bullet.GetComponent<Camera>().enabled = true;
                //Camera.main.GetComponent<Camera>().orthographicSize = Mathf.Lerp(Camera.main.GetComponent<Camera>().orthographicSize,
                //   Camera.main.GetComponent<Camera>().orthographicSize - 1, Time.deltaTime * 500);

                //Camera.main.orthographicSize -= 5 * Time.deltaTime;
                //   Destroy(gameObject);
            }
            else
            {

               // Debug.Log(hits.collider.gameObject.name);

            }
            if (hits.collider.gameObject.tag != "playerBullet")
                Destroy(gameObject);
        }




    }
    

    //IEnumerator ZoomCoroutine(Camera camera, float targetSize, float duration)
    //{
       
    //        float startSize = camera.orthographicSize;

    //        for (float t = 0f; t < duration; t += Time.deltaTime)
    //        {
    //            float blend = t / duration;
    //            // A SmoothStep rather than a Lerp might look good here too.
    //            camera.orthographicSize = Mathf.Lerp(startSize, targetSize, blend);

    //            // Wait one frame, then resume.
    //            yield return null;
    //        }

    //        // Finish up our transition, and mark our work done.
    //        camera.orthographicSize = targetSize;
    //        zoomTween = null;
        
     
    
    //}

}
