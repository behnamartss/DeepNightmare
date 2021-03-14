using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnifeAnimations : MonoBehaviour {

    public bool idleMode = false;
    public bool run = true;
    public bool hit = false;
    public bool hit2 = false;
    public bool damage = false;
    public bool death = false;
    public bool jumpCover = false;
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
            anim.SetBool("run", false);
            anim.SetBool("hit", false);
            anim.SetBool("hit2", false);
            anim.SetBool("jumpCover", false);
            anim.SetBool("death", false);
        }
        if (run)
        {
            anim.SetBool("idle", false);
            anim.SetBool("run", true);
            anim.SetBool("hit", false);
            anim.SetBool("hit2", false);
            anim.SetBool("jumpCover", false);
            anim.SetBool("death", false);

        }
        if (hit)
        {
            anim.SetBool("idle", false);
            anim.SetBool("run", false);
            anim.SetBool("hit", true);
            anim.SetBool("hit2", false);
            anim.SetBool("jumpCover", false);
        }
        if (hit2)
        {
            anim.SetBool("idle", false);
            anim.SetBool("run", false);
            anim.SetBool("hit", false);
            anim.SetBool("hit2", true);
            anim.SetBool("jumpCover", false);
            anim.SetBool("death", false);
        }
        if (jumpCover)
        {
            anim.SetBool("idle", false);
            anim.SetBool("run", false);
            anim.SetBool("hit", false);
            anim.SetBool("hit2", false);
            anim.SetBool("jumpCover", true);
            anim.SetBool("death", false);
        }
        if (death)
        {
            anim.SetBool("idle", false);
            anim.SetBool("run", false);
            anim.SetBool("hit", false);
            anim.SetBool("hit2", false);
            anim.SetBool("jumpCover", false);
            anim.SetBool("death", true);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            // StartCoroutine(GoToDamageAndReturn());
            anim.SetTrigger("damage");
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
    //private IEnumerator GoToDamageAndReturn()
    //{
    //    temp1 = false;
    //    temp2 = false;
    //    //   var temp = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).GetHashCode();
    //    if (idleMode)
    //        temp1 = true;
    //    if (walk)
    //        temp2 = true;

    //    damage = true;
    //    walk = false;
    //    idleMode = false;
    //    yield return new WaitForSeconds(.4f);
    //    damage = false;
    //    if (temp1)
    //        idleMode = true;
    //    if (temp2)
    //    {
    //        walk = true;
    //        //    GameObject.Find("Enemy1").GetComponent<enemy1controller>().ZeroSpeed();
    //        GameObject.Find("Enemy1").SendMessage("NonZeroSpeed");
    //        try
    //        {
    //            GetComponentInParent<enemy1controller>().SendMessage("NonZeroSpeed");

    //        }

    //        catch { }


    //    }
    //    //     GetComponent<Animator>().CrossFade(temp, 0.2f);



    //}

    void OnTriggerEnter2D(Collider2D col2d)
    {
        if (col2d.gameObject.tag == "enemyStandPoint")
        {

            run = false;
            idleMode = true;
        }

    }
}
