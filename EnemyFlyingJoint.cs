using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyFlyingJoint : MonoBehaviour
{
    float angle;
    [SerializeField]
    GameObject head;
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject enemyFlying;

    [SerializeField]
    float AngleDeg = 0;




    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {


        if (enemyFlying.GetComponent<EnemyFlyingAnimations>().damage == false&
              !GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(1).IsName("enemy1Reloading"))
        {
          //  if (Input.GetMouseButton(0))
          //  {
                try
                {
                //Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                //Vector3 lookAt = mouseScreenPosition;

                //float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);
                Vector3 lookAt;
                ////AngleDeg = (180 / Mathf.PI) * AngleRad;
                //AngleDeg = (180 / Mathf.PI) * Time.timeScale * AngleRad;
                
                var player = GameObject.Find("Player");
                if (player.GetComponent<PlayerController>().behindCover)
                {
                    lookAt = GameObject.Find("Head").gameObject.transform.position;

                }
                else
                {
                    lookAt = player.gameObject.transform.position;

                }
                float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);
                AngleDeg = (180 / Mathf.PI) * Time.timeScale * AngleRad;
            }
                catch { }
           // }

            //Vector3 lookAt = GameObject.Find("Player").gameObject.transform.position;
            //float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);

            //AngleDeg = (180 / Mathf.PI) * AngleRad;





        }




        if (GetComponentInParent<enemyflyingcontroller>().facingLeft)
        {
            //if (AngleDeg >= 140 || AngleDeg <= -140)
            //{
            //    transform.rotation = Quaternion.Euler(0, 0, AngleDeg + 20);
            //    head.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);

            //    //   leftHand.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
            //}
            //else if (AngleDeg < 140 & AngleDeg > 90)
            //{
            //    transform.rotation = Quaternion.Euler(0, 0, 140);
            //    head.transform.rotation = Quaternion.Euler(0, 0, -26 + 80);


            //}
            //else if (AngleDeg < -90 & AngleDeg > -140)
            //{
            //    transform.rotation = Quaternion.Euler(0, 0, -140);
            //    head.transform.rotation = Quaternion.Euler(0, 0, 150);


            //}

            if (AngleDeg >= 90 || AngleDeg <= -90)
            {
                transform.rotation = Quaternion.Euler(0, 0, AngleDeg + 20);
                head.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);

                //   leftHand.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
            }
        }
        //else if (AngleDeg < -39 & AngleDeg > -90)
        //{
        //    transform.rotation = Quaternion.Euler(0, 180, -AngleDeg - 160);
        //    head.transform.rotation = Quaternion.Euler(0, 180, -AngleDeg + 90);
        //}


        else if (AngleDeg > -90 & AngleDeg < 90)
        {

            transform.rotation = Quaternion.Euler(0, 180, -AngleDeg - 160);
            head.transform.rotation = Quaternion.Euler(0, 180, -AngleDeg + 90);

        }



    }
    // called by animation event


    void Update()
    {




    }





}
