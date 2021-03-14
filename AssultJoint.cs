using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AssultJoint : MonoBehaviour
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
    [SerializeField]
    Vector3 touchScreenPosition;

    Touch myTouch;
    int nbTouches;
    Vector3 mouseScreenPosition;
    //Clamping

    //public float zSpeed = 250.0f;

    //public float zMinLimit = -80f;
    //public float zMaxLimit = 80f;

    //private float x = 0.0f;
    //private float y = 0.0f;
    //private float z = 0;


    // clamping
   public void Start()
    {
     
        StartCoroutine(Normalize());
  
        //if (!GetComponentInParent<PlayerController>().facingLeft)
        //    touchScreenPosition = new Vector3(GetComponentInParent<PlayerAssult>().gameObject.transform.position.x - 1,
        //        GetComponentInParent<PlayerAssult>().gameObject.transform.position.y,
        //        GetComponentInParent<PlayerAssult>().gameObject.transform.position.z
        //        );
        //else
        //    touchScreenPosition = new Vector3(GetComponentInParent<PlayerAssult>().gameObject.transform.position.x + 1,
        //        GetComponentInParent<PlayerAssult>().gameObject.transform.position.y,
        //        GetComponentInParent<PlayerAssult>().gameObject.transform.position.z
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

    // Update is called once per frame
    void LateUpdate()
    {
        nbTouches = Input.touchCount;
        try
        {
            if (player.GetComponent<PlayerAssult>().assultRun || player.GetComponent<PlayerAssult>().assultAim)
            {
                if (Input.GetMouseButton(0) & !GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(1).IsName("assultReloading")
                    & !IsPointerOverUIObject()
                    )
                //if ((!GetComponentInParent<PlayerController>().facingLeft & touchScreenPosition.x < transform.position.x) ||
                //  (GetComponentInParent<PlayerController>().facingLeft & touchScreenPosition.x > transform.position.x)

                //  )
                {

                    //mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    if (nbTouches > 0)
                    {
                        for (int i = 0; i < nbTouches; i++)
                        {
                            int mask = 1 << 12;
                            Touch touch = Input.GetTouch(i);

                            //Vector3 ray = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                            //RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);




                            if (!IsPointerOverUIObject() & touch.position.y > Screen.height / 6 )

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
                    touchScreenPosition = Camera.main.ScreenToWorldPoint(myTouch.position);
                    Vector3 lookAt = touchScreenPosition;

                    float AngleRad = Mathf.Atan2((lookAt.y - this.transform.position.y) * -1, (lookAt.x - this.transform.position.x) * -1);

                    //AngleDeg = (180 / Mathf.PI) * AngleRad;
                    AngleDeg = (180 / Mathf.PI) * Time.timeScale * AngleRad;


                }
                if (!GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(1).IsName("assultReloading"))
                {
                    if (!GetComponentInParent<PlayerController>().facingLeft)
                    {
                        if (touchScreenPosition.x < transform.position.x)
                        {
                            //if (GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(1).IsName("assultReloading"))
                            //{
                            //    transform.rotation = Quaternion.Euler(0, 0, -50);

                            //    head.transform.rotation = Quaternion.Euler(0, 0, -43 + 85);

                            //}
                            //else
                            if (AngleDeg >= -36 & AngleDeg <= 45)
                            {
                                transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);

                                head.transform.rotation = Quaternion.Euler(0, 0, (AngleDeg + 60));
                                if (player.GetComponent<PlayerAssult>().assultAim || player.GetComponent<PlayerAssult>().assultRun)
                                    leftHand.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 20);
                            }
                            else if (AngleDeg <= -36)
                            {
                                transform.rotation = Quaternion.Euler(0, 0, -126);

                                head.transform.rotation = Quaternion.Euler(0, 0, 24);
                                if (player.GetComponent<PlayerAssult>().assultAim || player.GetComponent<PlayerAssult>().assultRun)
                                    leftHand.transform.rotation = Quaternion.Euler(0, 0, -56);
                            }
                            else if (AngleDeg >= 45)
                            {
                                transform.rotation = Quaternion.Euler(0, 0, -45);

                                head.transform.rotation = Quaternion.Euler(0, 0, 105);
                                if (player.GetComponent<PlayerAssult>().assultAim || player.GetComponent<PlayerAssult>().assultRun)
                                    leftHand.transform.rotation = Quaternion.Euler(0, 0, 25);
                            }
                        }
                        else
                        {
                            Start();
                        }
                    }
                    else     // y bayad beshe 180,tu bakhshe z ham fqt if e aval ,- angle deg+mokamemele meghdar sabete dar bakhshe mojaver ife qabli,
                             //baghie if ha b surate tajrobi mostaqim meghdar dade mishan

                    {
                        if (touchScreenPosition.x > transform.position.x)
                        {
                            if (AngleDeg >= 125 || AngleDeg <= -140)
                            {
                                transform.rotation = Quaternion.Euler(0, 180, -AngleDeg + 90);

                                head.transform.rotation = Quaternion.Euler(0, 180, (-AngleDeg - 120));
                                if (player.GetComponent<PlayerAssult>().assultAim || player.GetComponent<PlayerAssult>().assultRun)
                                    leftHand.transform.rotation = Quaternion.Euler(0, 180, -AngleDeg + 160);
                            }
                            else if (AngleDeg < 125 /*& AngleDeg>90*/ & AngleDeg > 0)
                            {
                                transform.rotation = Quaternion.Euler(0, 180, -35);

                                head.transform.rotation = Quaternion.Euler(0, 180, 110);
                                if (player.GetComponent<PlayerAssult>().assultAim || player.GetComponent<PlayerAssult>().assultRun)
                                    leftHand.transform.rotation = Quaternion.Euler(0, 180, 35);
                            }
                            else if (AngleDeg > -140 /*& AngleDeg<-90*/& AngleDeg < 0)
                            {
                                transform.rotation = Quaternion.Euler(0, 180, -129);

                                head.transform.rotation = Quaternion.Euler(0, 180, 20);
                                if (player.GetComponent<PlayerAssult>().assultAim || player.GetComponent<PlayerAssult>().assultRun)
                                    leftHand.transform.rotation = Quaternion.Euler(0, 180, -59);
                            }
                        }
                        else
                        {
                            Start();
                        }

                    }
                }

                //AngleDeg += zSpeed * Time.deltaTime;
                //AngleDeg = ClampAngle(AngleDeg, zMinLimit, zMaxLimit);

                //Quaternion newRot = Quaternion.Euler(x, y, AngleDeg);

                //transform.rotation = newRot;

            }
        }
        catch { }

    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
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
