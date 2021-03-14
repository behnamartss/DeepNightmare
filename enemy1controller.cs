using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy1controller : MonoBehaviour
{
    bool idleMode = true;
   
   public bool walkMode = false;
    bool sitMode = false;
    Rigidbody2D rb;
    int speedX = -4;
    bool shoot = false;
    public float timeBetweenShots = .3333f;
    private float timestamp;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform bulletHole;
    [SerializeField]
    ParticleSystem shootParticle;
    [SerializeField]
    Transform jointTransofrm;

    [SerializeField]
    GameObject movementJoint1;
    [SerializeField]
    GameObject movementJoint2;
    [SerializeField]
    GameObject enemyGrenade;
    [SerializeField]
    GameObject grenadePlaces;
    private bool left;
    private bool right;
    public bool facingLeft;
    GameObject player;
    [SerializeField]
    int health = 6;
    [SerializeField]
    int bulletCount = 3;
    [SerializeField]
    int power = 1;
    float exchangeTime;
    Vector3 viewPos;
   
    [SerializeField]
    AudioSource shootvoice;
    //[SerializeField]
    // GameObject shovel;
    //[SerializeField]
    // GameObject shovelHole;

    // Use this for initialization
    void Start()
    {
        var currentScene = SceneManager.GetActiveScene().name;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(AI());

        if(SceneManager.GetActiveScene().name=="Level1")
        StartCoroutine(NormalShoot());
        else
        StartCoroutine(RandomShoot());

        StartCoroutine(Grenade());
        StartCoroutine(checkDeath());
        player = GameObject.Find("Player");
        //ScalingClass scalingClass = new ScalingClass();
        //scalingClass.ChooseScale(transform, currentScene);
     //   StartCoroutine(scalee());

    }

 
    //private IEnumerator scalee()
    //{
    //    yield return new WaitForSeconds(1f);
    //    var currentScene = SceneManager.GetActiveScene().name;
    //    if (currentScene=="Level4")
    //        transform.localScale = new Vector2(transform.localScale.x / 2.2f, transform.localScale.y / 2.2f);
    //}

    private IEnumerator checkDeath()
    {

        while (true)
        {
            if (health <= 0)
            {
                GetComponent<enemy1controller>().enabled = false;
                GetComponentInChildren<Enemy1Animations>().death = true;
                GetComponentInChildren<EnemyJoint>().enabled = false;
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
    private IEnumerator AI()
    {
        while (true)
        {
            if (walkMode == false)
            {
                 exchangeTime = UnityEngine.Random.Range(1, 8);
                int whichMode = UnityEngine.Random.Range(1, 3);

                switch (whichMode)
                {
                    case 1:
                        //  IdleMode();
                        sitMode = false;
                        sitMode = false;
                        idleMode = true;

                        break;
                    case 2:
                        // SitMode();
                        idleMode = false;
                        sitMode = false;
                        sitMode = true;
                        break;
                }
            }
            yield return new WaitForSeconds(exchangeTime);
        }
    }

    private IEnumerator Grenade()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {

            if (player.GetComponent<PlayerController>().behindCover &
                (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0))
            {
                int whichMode = UnityEngine.Random.Range(1, 4);
                switch (whichMode)
                {
                    case 1:
                        //  IdleMode();

                        GetComponentInChildren<Animator>().SetTrigger("grenade");
                        StartCoroutine(throwGrenade());
                        break;

                }
            }
            yield return new WaitForSeconds(3f);

        }
    }

    private IEnumerator throwGrenade()
    {
        yield return new WaitForSeconds(.7f);
        var newGrenade = Instantiate(enemyGrenade, grenadePlaces.transform.position, grenadePlaces.transform.rotation);
        //var currentScene = SceneManager.GetActiveScene().name;


        //ScalingClass scalingClass = new ScalingClass();
        //scalingClass.ChooseScale(newGrenade.transform, currentScene);
        StopCoroutine(throwGrenade());
    }




    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > player.transform.position.x)
            GoLeft();
        else
            GoRight();

        if (idleMode)
        {
            speedX = 0;
            GetComponentInChildren<Enemy1Animations>().SendMessage("IdleMode");
        }
        if (walkMode)
        {

            if (facingLeft)
                speedX = -4;
            else
                speedX = 4;
            GetComponent<Rigidbody2D>().velocity = new Vector2(speedX, 0);
            GetComponentInChildren<Enemy1Animations>().SendMessage("WalkMode");
        }

        else if (sitMode)
        {
            speedX = 0;
            GetComponentInChildren<Enemy1Animations>().SendMessage("SitMode");

        }
        //try
        //{
        viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (shoot & Time.time >= timestamp & GetComponentInChildren<Enemy1Animations>().GetComponent<Animator>().GetCurrentAnimatorStateInfo(3).IsName("damage") == false
                & !GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(1).IsName("enemy1Reloading")
                & (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)


                 )
            if (/*player.GetComponent<PlayerController>().assult == true || */(player.GetComponent<PlayerController>().handgunJump == false))


            {

                if (bulletCount > 0)
                {
                    shootvoice.Play();
                    //  Instantiate(shootParticle, bulletHole.transform);
                    Instantiate(shootParticle, bulletHole.transform.position, bulletHole.transform.rotation);
                    var newBullet = Instantiate(bullet, bulletHole.position, bulletHole.rotation);
                    newBullet.GetComponent<EnemyBullet>().power = power;
                    StartCoroutine(MoveArms());
                    bulletCount--;

                }
                else if (bulletCount == 0)
                    StartCoroutine(Enemy1Reloading());
                timestamp = Time.time + timeBetweenShots;
            }
        //}
        //catch { }

        if (Input.GetKeyDown(KeyCode.T))
        {
            speedX = 0;
        }

        if (transform.position.x > player.transform.position.x)
            GoLeft();
        else
            GoRight();

        //if (transform.position.x > player.transform.position.x)
        //if (Input.GetKey(KeyCode.I))
        //    GoRight();
        //if (Input.GetKey(KeyCode.O))
        //    GoLeft();


    }

    private IEnumerator Enemy1Reloading()
    {
     
        GetComponentInChildren<Animator>().SetTrigger("reload");
        //Instantiate(shovel, shovelHole.transform.position, shovelHole.transform.rotation);
        yield return new WaitForSeconds(2.4f);
        GetComponentInChildren<Animator>().ResetTrigger("reload");
        bulletCount = 11;
    }

    private IEnumerator NormalShoot()
    {
        while (true)
        {


            yield return new WaitForSeconds(3f);
            shoot = true;
            yield return new WaitForSeconds(2f);
            shoot = false;
        }

    }
    private IEnumerator RandomShoot()
    {
        while (true)
        {
            var timing = UnityEngine.Random.Range(1, 4);
            yield return new WaitForSeconds(timing);
            shoot = true;
            timing = UnityEngine.Random.Range(1, 4);
            yield return new WaitForSeconds(timing);
            shoot = false;

        }

    }

    private IEnumerator MoveArms()
    {

        movementJoint1.transform.position = new Vector2(movementJoint1.transform.position.x + .1f, movementJoint1.transform.position.y);
        movementJoint2.transform.position = new Vector2(movementJoint2.transform.position.x + .1f, movementJoint2.transform.position.y);
        yield return new WaitForSeconds(.3f);
        movementJoint1.transform.position = new Vector2(movementJoint1.transform.position.x + -.1f, movementJoint1.transform.position.y);
        movementJoint2.transform.position = new Vector2(movementJoint2.transform.position.x + -.1f, movementJoint2.transform.position.y);
    }


    void OnTriggerEnter2D(Collider2D col2d)
    {
        if (col2d.gameObject.tag == "enemyStandPoint")
        {
            speedX = 0;
            walkMode = false;
        }

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
        health -= amount;
        GetComponentInChildren<Animator>().SetTrigger("damage1");
    }
    void SitMode()
    {
        speedX = 0;
        GetComponentInChildren<Enemy1Animations>().SendMessage("SitMode");
    }
    void WalkMode()
    {
        if (facingLeft)
            speedX = -4;
        else
            speedX = 4;
        GetComponent<Rigidbody2D>().velocity = new Vector2(speedX, 0);
    }


}
