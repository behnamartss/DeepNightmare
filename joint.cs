using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class joint : MonoBehaviour
{
    float angle;
    [SerializeField]
    GameObject head;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject leftHand;

    Quaternion q;
    public float AngleDeg;

    //Clamping

    //public float zSpeed = 250.0f;

    //public float zMinLimit = -80f;
    //public float zMaxLimit = 80f;

    //private float x = 0.0f;
    //private float y = 0.0f;
    //private float z = 0;

    Vector3 touchScreenPosition;
    Vector3 mouseScreenPosition;
    Vector3 finalScreenPosition;
    int nbTouches;
    // clamping
   public void Start()
    {
        StartCoroutine(Normalize());
        //if (!GetComponentInParent<PlayerController>().facingLeft)
        //    touchScreenPosition =new Vector3(GetComponentInParent<PlayerHandgun>().gameObject.transform.position.x - 1,
        //        GetComponentInParent<PlayerHandgun>().gameObject.transform.position.y,
        //        GetComponentInParent<PlayerHandgun>().gameObject.transform.position.z
        //        );
        //else
        //    touchScreenPosition = new Vector3(GetComponentInParent<PlayerHandgun>().gameObject.transform.position.x + 1,
        //        GetComponentInParent<PlayerHandgun>().gameObject.transform.position.y,
        //        GetComponentInParent<PlayerHandgun>().gameObject.transform.position.z
        //        );
        //x = transform.eulerAngles.x;
        //y = transform.eulerAngles.y;
        //z = transform.eulerAngles.z;
    }

    private IEnumerator Normalize()
    {
        yield return new WaitForSeconds(.1f);
        AngleDeg = 0;
        touchScreenPosition = new Vector3(0, 0, 0);
        myTouch.position = new Vector3(0, 0, 0);
    }

    Touch myTouch;
    // Update is called once per frame
    void LateUpdate()
    {
        nbTouches = Input.touchCount;
        

        try
        {
            if (player.GetComponent<PlayerHandgun>().handgunRun || player.GetComponent<PlayerHandgun>().handgunAim ||
                    player.GetComponent<PlayerHandgun>().idleMode || player.GetComponent<PlayerHandgun>().handgunScoot
                    || player.GetComponent<PlayerHandgun>().handgunJump
                    )
            {
                if (Input.GetMouseButton(0) & !GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(1).IsName("handgunReloading")
                 & !IsPointerOverUIObject()
                    )
                    //if ((!GetComponentInParent<PlayerController>().facingLeft & touchScreenPosition.x < transform.position.x) ||
                    //  (GetComponentInParent<PlayerController>().facingLeft & touchScreenPosition.x > transform.position.x)

                    //    )
                    {




                   

                        if (nbTouches > 0)
                    {
                        for (int i = 0; i < nbTouches; i++)
                        {
                            int mask = 1 << 12;
                            Touch touch = Input.GetTouch(i);

                            //Vector3 ray = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                            //RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);



                       
                                if (!IsPointerOverUIObject()& touch.position.y > Screen.height / 6)
                              
                            {

                                //  Debug.Log(touch.fingerId);

                                myTouch = touch;

                                break;
                            }



                            //else continue;





                        }
                    }
                    else if (nbTouches == 1)
                        myTouch = Input.GetTouch(0);

                    if (GetComponentInParent<PlayerHandgun>().handgunScoot)
                        AngleDeg = -20;
                    else
                    {
                        // mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        touchScreenPosition = Camera.main.ScreenToWorldPoint(myTouch.position);
                        Vector3 lookAt;
                        //   if (Application.platform == RuntimePlatform.Android)
                        //   {
                        lookAt = touchScreenPosition;
                        finalScreenPosition = touchScreenPosition;
                        //    }
                        //else
                        //{
                        //    lookAt = mouseScreenPosition;
                        //    finalScreenPosition = mouseScreenPosition;
                        //}
                        float AngleRad = Mathf.Atan2((lookAt.y - this.transform.position.y) * -1, (lookAt.x - this.transform.position.x) * -1);//control az posht
                                                                                                                                               //   AngleRad = Mathf.Atan2((lookAt.y - this.transform.position.y) , (lookAt.x - this.transform.position.x) * -1);
                                                                                                                                               //   AngleDeg = (180 / Mathf.PI) * AngleRad;
                        AngleDeg = (180 / Mathf.PI) * Time.timeScale * AngleRad;
                        //    mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    }




                    ////AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);//control az jlo
                    //   AngleRad = Mathf.Atan2((lookAt.y - this.transform.position.y) * -1, (lookAt.x - this.transform.position.x) * -1);//control az posht
                    // //   AngleRad = Mathf.Atan2((lookAt.y - this.transform.position.y) , (lookAt.x - this.transform.position.x) * -1);
                    //    //   AngleDeg = (180 / Mathf.PI) * AngleRad;
                    //    AngleDeg = (180 / Mathf.PI) * Time.timeScale * AngleRad;


                }


                if (!GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(1).IsName("handgunReloading"))
                {
                    if (!GetComponentInParent<PlayerController>().facingLeft)
                    {
                        if (finalScreenPosition.x < transform.position.x /*& !IsPointerOverUIObject()*/)
                        {

                            //AngleRad = Mathf.Atan2((lookAt.y - this.transform.position.y) * -1, (lookAt.x - this.transform.position.x) * -1);//control az posht
                            //                                                                                                                 //   AngleRad = Mathf.Atan2((lookAt.y - this.transform.position.y) , (lookAt.x - this.transform.position.x) * -1);
                            //                                                                                                                 //   AngleDeg = (180 / Mathf.PI) * AngleRad;
                            //AngleDeg = (180 / Mathf.PI) * Time.timeScale * AngleRad;

                            if (AngleDeg >= -43 & AngleDeg <= 44)
                            {
                                transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 10);

                                head.transform.rotation = Quaternion.Euler(0, 0, (AngleDeg + 65));
                                if (player.GetComponent<PlayerHandgun>().idleMode || player.GetComponent<PlayerHandgun>().handgunScoot)
                                    leftHand.transform.rotation = transform.rotation;
                            }
                            else if (AngleDeg <= -43)
                            {
                                transform.rotation = Quaternion.Euler(0, 0, -55);

                                head.transform.rotation = Quaternion.Euler(0, 0, -43 + 65);
                                if (player.GetComponent<PlayerHandgun>().idleMode || player.GetComponent<PlayerHandgun>().handgunScoot)
                                    leftHand.transform.rotation = transform.rotation;
                            }
                            else if (AngleDeg >= 44)
                            {
                                transform.rotation = Quaternion.Euler(0, 0, 32);

                                head.transform.rotation = Quaternion.Euler(0, 0, 44 + 65);
                                if (player.GetComponent<PlayerHandgun>().idleMode || player.GetComponent<PlayerHandgun>().handgunScoot)
                                    leftHand.transform.rotation = transform.rotation;
                            }
                        }


                    }
                    else //
                    {
                        if (finalScreenPosition.x > transform.position.x /*& !IsPointerOverUIObject()*/)
                        {
                            //AngleRad = Mathf.Atan2((lookAt.y - this.transform.position.y) * -1, (lookAt.x - this.transform.position.x));//control az posht
                            //                                                                                                            //   AngleRad = Mathf.Atan2((lookAt.y - this.transform.position.y) , (lookAt.x - this.transform.position.x) * -1);
                            //                                                                                                            //   AngleDeg = (180 / Mathf.PI) * AngleRad;
                            //AngleDeg = (180 / Mathf.PI) * Time.timeScale * AngleRad;
                            if (AngleDeg <= -135 || AngleDeg >= 140)
                            // if (AngleDeg <= 40 & AngleDeg >= -50)
                            {
                                transform.rotation = Quaternion.Euler(0, 180, -AngleDeg + 170);
                                //transform.rotation = Quaternion.Euler(0, 180, -AngleDeg);
                                head.transform.rotation = Quaternion.Euler(0, 180, (-AngleDeg + -115));
                                //  head.transform.rotation = Quaternion.Euler(0, 180, (AngleDeg + 68));
                                if (player.GetComponent<PlayerHandgun>().idleMode || player.GetComponent<PlayerHandgun>().handgunScoot)
                                    leftHand.transform.rotation = transform.rotation;
                            }
                            else if (AngleDeg >= -135 /*& AngleDeg < -90*/ & AngleDeg < 0)
                            // else if (AngleDeg >= -180 /*& AngleDeg < -90*/ & AngleDeg < 0)
                            {
                                transform.rotation = Quaternion.Euler(0, 180, -52);

                                head.transform.rotation = Quaternion.Euler(0, 180, 22);
                                if (player.GetComponent<PlayerHandgun>().idleMode || player.GetComponent<PlayerHandgun>().handgunScoot)
                                    leftHand.transform.rotation = transform.rotation;
                            }
                            else if (AngleDeg < 145 /*& AngleDeg > 90*/ & AngleDeg > 0)
                            //  else if (AngleDeg < 180 /*& AngleDeg > 90*/ & AngleDeg > 0)
                            {
                                // transform.rotation = Quaternion.Euler(0, 180, 28);
                                transform.rotation = Quaternion.Euler(0, 180, 39);

                                // head.transform.rotation = Quaternion.Euler(0, 180, 90);
                                head.transform.rotation = Quaternion.Euler(0, 180, 105);
                                if (player.GetComponent<PlayerHandgun>().idleMode || player.GetComponent<PlayerHandgun>().handgunScoot)
                                    leftHand.transform.rotation = transform.rotation;
                            }



                        }

                    }


                    //AngleDeg += zSpeed * Time.deltaTime;
                    //AngleDeg = ClampAngle(AngleDeg, zMinLimit, zMaxLimit);

                    //Quaternion newRot = Quaternion.Euler(x, y, AngleDeg);

                    //transform.rotation = newRot;
                }
            }
        }
        catch { }

    }


    //private bool IsPointerOverUIObject2(RaycastHit2D hit)
    //{
    //    PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
    //    eventDataCurrentPosition.position = new Vector2(hit.transform.position.x, hit.transform.position.y);
    //    List<RaycastResult> results = new List<RaycastResult>();
    //    EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
    //    return results.Count > 0;
    //}
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }


    //public bool ButtonContainsPosition(Vector2 xPos)
    //{

    //    float fMinX = m_xButtonRect.transform.position.x - ((m_xButtonRect.sizeDelta.x * 0.5f) * m_xMenuManager.GetCanvasScaleFactor());
    //    float fMaxX = m_xButtonRect.transform.position.x + ((m_xButtonRect.sizeDelta.x * 0.5f) * m_xMenuManager.GetCanvasScaleFactor());
    //    float fMinY = m_xButtonRect.transform.position.y - ((m_xButtonRect.sizeDelta.y * 0.5f) * m_xMenuManager.GetCanvasScaleFactor());
    //    float fMaxY = m_xButtonRect.transform.position.y + ((m_xButtonRect.sizeDelta.y * 0.5f) * m_xMenuManager.GetCanvasScaleFactor());

    //    if (xPos.x <= fMaxX && xPos.x >= fMinX)
    //    {
    //        if (xPos.y <= fMaxY && xPos.y >= fMinY)
    //        {
    //            return true;
    //        }
    //    }

    //    return false;
    //}

    //float ClampAngle(float angle, float min, float max)
    //{
    //    if (angle < -360)
    //        angle += 360;
    //    if (angle > 360)
    //        angle -= 360;

    //    return Mathf.Clamp(angle, min, max);
    //}



    void Update()
    {




    }





}
