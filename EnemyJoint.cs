using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyJoint : MonoBehaviour
{
    float angle;
    [SerializeField]
    GameObject head;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject leftHand;
    [SerializeField]
    GameObject enemy;

    [SerializeField]
    float AngleDeg = 0;






    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {


        if (enemy.GetComponent<Enemy1Animations>().damage == false &
            !GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(1).IsName("enemy1Reloading") &
             !GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(2).IsName("Grenade") &
             !GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(3).IsName("damage") 
            )
        {

            //  if (Input.GetMouseButton(0))
            //   {
            try
            {
                Vector3 lookAt;

                //  Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var player = GameObject.Find("Player");
              //  if (player.GetComponent<PlayerController>().behindCover)
               // {
                     lookAt = GameObject.Find("Head").gameObject.transform.position;
                  
              //  }
               // else
              //  {
                 //    lookAt = player.gameObject.transform.position;
                  
                 
              //  }
                float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);
                AngleDeg = (180 / Mathf.PI) * Time.timeScale * AngleRad;

                //Vector3 lookAt = mouseScreenPosition;

                //float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);



                //AngleDeg = (180 / Mathf.PI) * AngleRad;


            }
            catch { }

            //  }
            //Vector3 lookAt = GameObject.Find("Player").gameObject.transform.position;
            //float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);

            //  Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Vector3 lookAt = mouseScreenPosition;
            //float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);

            //AngleDeg = (180 / Mathf.PI) * AngleRad;





            if (GetComponentInParent<enemy1controller>().facingLeft)
            {
                if (AngleDeg >= 140 || AngleDeg <= -140)
                {
                    transform.rotation = Quaternion.Euler(0, 0, AngleDeg + 146);
                    //   transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, AngleDeg + 145),Time.timeScale );
                    head.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 80);

                    leftHand.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
                }
                else if (AngleDeg < 140 & AngleDeg > 90)
                {
                    transform.rotation = Quaternion.Euler(0, 0, -65);
                    head.transform.rotation = Quaternion.Euler(0, 0, -26 + 80);

                    leftHand.transform.rotation = Quaternion.Euler(0, 0, -223);
                }
                else if (AngleDeg < -90 & AngleDeg > -140)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 10);
                    head.transform.rotation = Quaternion.Euler(0, 0, 150);

                    leftHand.transform.rotation = Quaternion.Euler(0, 0, -126);
                }
            }
            else
            {

                if (AngleDeg <= 40.97 & AngleDeg >= -39)
                {
                    transform.rotation = Quaternion.Euler(0, 180, -AngleDeg - 33);
                    //   transform.rotation = Quaternion.Euler(0, 180, transform.rotation.z-142);

                    head.transform.rotation = Quaternion.Euler(0, 180, -AngleDeg + 90);

                    //      leftHand.transform.rotation = Quaternion.Euler(0, 180, -AngleDeg+178);
                    leftHand.transform.rotation = Quaternion.Euler(0, 180, -AngleDeg - 36 - 142); //bar asase ekhtelaf avalie jointe rast va chap
                                                                                                  // leftHand.transform.rotation = Quaternion.Euler(0, 0,AngleDeg );

                }
                else if (AngleDeg < -39 & AngleDeg > -90)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 10);

                    head.transform.rotation = Quaternion.Euler(0, 180, 130);

                    leftHand.transform.rotation = Quaternion.Euler(0, 180, -125);
                }

                else if (AngleDeg > 40.97 & AngleDeg < 90)
                {

                    transform.rotation = Quaternion.Euler(0, 180, -70);
                    head.transform.rotation = Quaternion.Euler(0, 180, 70);

                    leftHand.transform.rotation = Quaternion.Euler(0, 180, 140);
                }



            }





        }

    }

    // called by animation event


    void Update()
    {




    }





}
