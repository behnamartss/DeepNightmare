using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Animations : MonoBehaviour
{
    public bool idleMode = true;
    public bool walk = false;
    public bool damage = false;
    public bool sit = false;
    public bool death = false;
    Animator anim;

    bool temp1 = false;
    bool temp2 = false;




    //bool shoot = false;
    //public float timeBetweenShots = .3333f;
    //private float timestamp;
    //[SerializeField]
    //GameObject bullet;
    //[SerializeField]
    //Transform bulletHole;
    //[SerializeField]
    //Transform jointTransofrm;

    //[SerializeField]
    //GameObject movementJoint1;
    //[SerializeField]
    //GameObject movementJoint2;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();




        // StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (idleMode)
        {
            anim.SetBool("idle", true);
            anim.SetBool("walk", false);
            anim.SetBool("damage", false);
            //  if (GetComponentInParent<Transform>().name.Contains("Enemy1_2"))
            anim.SetBool("sit1_2", false);
            //     else
            anim.SetBool("sit", false);
            anim.SetBool("death", false);
        }
        if (walk)
        {
            anim.SetBool("idle", false);
            anim.SetBool("walk", true);
            anim.SetBool("damage", false);
            //   if (GetComponentInParent<Transform>().name.Contains("Enemy1_2"))
            anim.SetBool("sit1_2", false);
            // else
            anim.SetBool("sit", false);
            anim.SetBool("death", false);
        }
        if (damage)
        {
            anim.SetBool("idle", false);
            anim.SetBool("walk", false);
            anim.SetBool("damage", true);
            //   if (GetComponentInParent<Transform>().name.Contains("Enemy1_2"))
            anim.SetBool("sit1_2", false);
            // else
            anim.SetBool("sit", false);
            anim.SetBool("death", false);
        }
        if (sit)
        {
            anim.SetBool("idle", false);
            anim.SetBool("walk", false);
            anim.SetBool("damage", false);
            anim.SetBool("death", false);
            if (GetComponentInParent<enemy1controller>().transform.name.Contains("Enemy1_2"))
            {
                anim.SetBool("sit1_2", true);


            }
            else
            {
                anim.SetBool("sit", true);

            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(GoToDamageAndReturn());
        }
        if (death)
        {
            anim.SetBool("idle", false);
            anim.SetBool("walk", false);
            anim.SetBool("damage", false);
            //   if (GetComponentInParent<Transform>().name.Contains("Enemy1_2"))
            anim.SetBool("sit1_2", false);
            // else
            anim.SetBool("sit", false);
            anim.SetBool("death", true);
        }

        //if (shoot & Time.time >= timestamp & GetComponent<Enemy1Animations>().damage == false)
        //{
        //    var newBullet = Instantiate(bullet, bulletHole.position, bulletHole.rotation);
        //    newBullet.GetComponent<EnemyBullet>().power = 1;
        //    StartCoroutine(MoveArms());

        //    timestamp = Time.time + timeBetweenShots;
        //}

    }
    //private IEnumerator Shoot()
    //{
    //    yield return new WaitForSeconds(1f);
    //    while (true)
    //    {

    //        yield return new WaitForSeconds(3);
    //        shoot = true;
    //        yield return new WaitForSeconds(2f);
    //        shoot = false;

    //    }


    //}
    //private IEnumerator MoveArms()
    //{

    //    movementJoint1.transform.position = new Vector2(movementJoint1.transform.position.x + .1f, movementJoint1.transform.position.y);
    //    movementJoint2.transform.position = new Vector2(movementJoint2.transform.position.x + .1f, movementJoint2.transform.position.y);
    //    yield return new WaitForSeconds(.3f);
    //    movementJoint1.transform.position = new Vector2(movementJoint1.transform.position.x + -.1f, movementJoint1.transform.position.y);
    //    movementJoint2.transform.position = new Vector2(movementJoint2.transform.position.x + -.1f, movementJoint2.transform.position.y);
    //}
    private IEnumerator GoToDamageAndReturn()
    {
        temp1 = false;
        temp2 = false;
        //   var temp = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).GetHashCode();
        if (idleMode)
            temp1 = true;
        if (walk)
            temp2 = true;

        damage = true;
        walk = false;
        idleMode = false;
        yield return new WaitForSeconds(.4f);
        damage = false;
        if (temp1)
            idleMode = true;
        if (temp2)
        {
            walk = true;
            //    GameObject.Find("Enemy1").GetComponent<enemy1controller>().ZeroSpeed();
            // GameObject.Find("Enemy1").SendMessage("NonZeroSpeed");
            try
            {
                GetComponentInParent<enemy1controller>().SendMessage("NonZeroSpeed");

            }

            catch { }


        }
        //     GetComponent<Animator>().CrossFade(temp, 0.2f);



    }
    public void SitMode()
    {
        idleMode = false;
        walk = false;
        sit = true;

    }
    public void WalkMode()
    {
        idleMode = false;
        sit = false;
        walk = true;

    }
    public void IdleMode()
    {
        sit = false;
        walk = false;
        idleMode = true;
    }
    void OnTriggerEnter2D(Collider2D col2d)
    {
        if (col2d.gameObject.tag == "enemyStandPoint")
        {

            walk = false;
            sit = false;
            idleMode = true;
        }

    }
}
