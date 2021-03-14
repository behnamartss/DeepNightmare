using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyKnifeController : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField]
    int speedX = -4;
    public bool hit = false;
    public float timeBetweenShots = .3333f;
    private float timestamp;


    private bool left;
    private bool right;
    public bool facingLeft;
    GameObject player;
    [SerializeField]
    public int health = 6;
    private bool jumpingCover = false;
    float stopNextToPlayer;
    int SpeedXTemp;
    bool damaging;
    // Use this for initialization
    void Start()
    {
        var currentScene = SceneManager.GetActiveScene().name;
        rb = GetComponent<Rigidbody2D>();
        // StartCoroutine(Knife());
        player = GameObject.Find("Player");
        StartCoroutine(Knife());
        StartCoroutine(checkDeath());
        //ScalingClass scalingClass = new ScalingClass();
        //scalingClass.ChooseScale(transform,currentScene);
        
    }

    private IEnumerator checkDeath()
    {

        while (true)
        {
            if (health <= 0)
            {
                GetComponent<EnemyKnifeController>().enabled = false;
                GetComponentInChildren<EnemyKnifeAnimations>().death = true;
                StartCoroutine(Death());
            }

            yield return null;

        }



    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {

        
        GetComponent<Rigidbody2D>().velocity = new Vector2(speedX, 0);
        if (hit & Time.time >= timestamp & GetComponentInChildren<EnemyKnifeAnimations>().damage == false

            )
        {

            timestamp = Time.time + timeBetweenShots;

        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            speedX = 0;
        }

        //original: if (transform.position.x > player.transform.position.x)
        if (transform.position.x > player.transform.position.x)
            GoLeft();
        else
            GoRight();

        //if (Input.GetKey(KeyCode.I))
        //    GoRight();
        //if (Input.GetKey(KeyCode.O))
        //    GoLeft();




    }



    private IEnumerator Knife()
    {




        //hit = true;
        //speedX = 0;
        //GetComponentInChildren<EnemyKnifeAnimations>().hit = true;
        //GetComponentInChildren<EnemyKnifeAnimations>().idleMode = false;
        //GetComponentInChildren<EnemyKnifeAnimations>().run = false;


        while (true)
        {
            var distance = Vector2.Distance(transform.position, player.transform.position);
            if (/*Mathf.Abs(transform.position.x - player.transform.position.x) <= transform.localScale.x*2+.5 &*/
                distance< transform.localScale.x * 2 + .5 &
                GetComponentInChildren<EnemyKnifeAnimations>().jumpCover == false)
            {
                hit = true;
                speedX = 0;
                SpeedXTemp = speedX;
                var t = UnityEngine.Random.Range(1, 3);
                //Debug.Log(t);

                if (t == 1)
                    GetComponentInChildren<EnemyKnifeAnimations>().hit = true;
                else
                    GetComponentInChildren<EnemyKnifeAnimations>().hit2 = true;

                GetComponentInChildren<EnemyKnifeAnimations>().idleMode = false;
                GetComponentInChildren<EnemyKnifeAnimations>().run = false;
                GetComponentInChildren<EnemyKnifeAnimations>().jumpCover = false;

                yield return new WaitForSeconds(1f);
                hit = false;
                GetComponentInChildren<EnemyKnifeAnimations>().hit = false;
                GetComponentInChildren<EnemyKnifeAnimations>().hit2 = false;
                GetComponentInChildren<EnemyKnifeAnimations>().idleMode = true;
                GetComponentInChildren<EnemyKnifeAnimations>().run = false;
                GetComponentInChildren<EnemyKnifeAnimations>().jumpCover = false;
                // GetComponentInChildren<EnemyKnifeAnimations>().idleMode = true;
                yield return new WaitForSeconds(1.5f);
            }
            else
            {
                // StopCoroutine(Knife());
                hit = false;
                GetComponentInChildren<EnemyKnifeAnimations>().hit = false;
                GetComponentInChildren<EnemyKnifeAnimations>().hit2 = false;
                GetComponentInChildren<EnemyKnifeAnimations>().idleMode = false;
                GetComponentInChildren<EnemyKnifeAnimations>().run = true;
                //  GetComponentInChildren<EnemyKnifeAnimations>().run = true;
                if (facingLeft)
                {
                    if (damaging == false)
                    { speedX = -4; SpeedXTemp = speedX; }
                }
                else
                     if (damaging == false)
                { speedX = 4; SpeedXTemp = speedX; }
            }
            yield return null;
        }







    }


    void OnTriggerEnter2D(Collider2D col2d)
    {
        if (col2d.gameObject.tag == "enemyStandPoint")
        {
            speedX = 0;
        }

    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.collider.tag == "cover" & jumpingCover == false)
        {
            if (facingLeft & target.transform.position.x < transform.position.x || !facingLeft & target.transform.position.x > transform.position.x)

                //  GetComponentInChildren<EnemyKnifeAnimations>().GetComponent<Animator>().SetTrigger("coverJump");
                ///
                GetComponentInChildren<EnemyKnifeAnimations>().jumpCover = true;
            GetComponentInChildren<EnemyKnifeAnimations>().run = false;
            GetComponentInChildren<EnemyKnifeAnimations>().hit = false;
            GetComponentInChildren<EnemyKnifeAnimations>().hit2 = false;
            GetComponentInChildren<EnemyKnifeAnimations>().idleMode = false;
            ///
            jumpingCover = true;
            StartCoroutine(BackToNormal());
        }
       
    }

    IEnumerator BackToNormal()
    {
        yield return new WaitForSeconds(2f);
        jumpingCover = false;
        ///
        GetComponentInChildren<EnemyKnifeAnimations>().jumpCover = false;
        GetComponentInChildren<EnemyKnifeAnimations>().run = true;
        GetComponentInChildren<EnemyKnifeAnimations>().hit = false;
        GetComponentInChildren<EnemyKnifeAnimations>().hit2 = false;
        GetComponentInChildren<EnemyKnifeAnimations>().idleMode = false;
        ///
        StopCoroutine(BackToNormal());
    }

    public void NonZeroSpeed()
    {

        speedX = -4;


    }

    public void GoLeft()
    {
        left = true;
        right = false;
        if (!facingLeft)
        {

            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * -1);
            transform.Rotate(Vector3.up * 180);

        }
        facingLeft = true;

    }

    public void GoRight()
    {
        left = false;
        right = true;
        if (facingLeft)
        {
            transform.Rotate(Vector3.up * 180);
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * -1);

        }
        facingLeft = false;
    }

    public void StopMovement()
    {
        left = false;
        right = false;
    }

    public void Damage(int amount)
    {
        damaging = true;
        health -= amount;
        GetComponentInChildren<Animator>().SetTrigger("damage");
        if (GetComponentInChildren<EnemyKnifeAnimations>().run )
            if (facingLeft)
                speedX += 2;
            else
                speedX -= 2;
        StartCoroutine(ResetSpeedX());
    }

    private IEnumerator ResetSpeedX()
    {
        yield return new WaitForSeconds(.5f);
        speedX = SpeedXTemp;
        damaging = false;
    }
}
