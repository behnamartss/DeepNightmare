using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyflyingcontroller : MonoBehaviour
{
    Rigidbody2D rb;
    int speedX = -2;
    bool shoot = false;
    public float timeBetweenShots = 0.3333f;
    private float timestamp;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform bulletHole;
    GameObject player;
    [SerializeField]
    ParticleSystem shootParticle;
    [SerializeField]
    GameObject movementJoint1;
    [SerializeField]
    int power;
    private bool left;
    private bool right;
    public bool facingLeft;
    [SerializeField]
    int health = 6;
    [SerializeField]
    int bulletCount = 3;
    [SerializeField]
    AudioSource shootvoice;
    //[SerializeField]
    //GameObject shovel;
    //[SerializeField]
    //GameObject shovelHole;
    // Use this for initialization
    void Start()
    {
       
        var currentScene = SceneManager.GetActiveScene().name;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Shoot());
        StartCoroutine(checkDeath());
        player = GameObject.Find("Player");
        //ScalingClass scalingClass = new ScalingClass();
        //scalingClass.ChooseScale(transform, currentScene);
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            shoot = true;
            yield return new WaitForSeconds(2f);
            shoot = false;
        }


    }

    // Update is called once per frame
    void Update()
    {
        //try
        //{
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (shoot & Time.time >= timestamp & GetComponentInChildren<EnemyFlyingAnimations>().damage == false &
                !GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(1).IsName("enemy1Reloading") &
                    (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)&
                    (!player.GetComponent<PlayerController>().handgunJump)

                )
        {
            
            if (bulletCount > 0)
            {
                shootvoice.Play();
                Instantiate(shootParticle, bulletHole.transform.position, bulletHole.transform.rotation);
                var newBullet = Instantiate(bullet, bulletHole.position, bulletHole.rotation);
                newBullet.GetComponent<EnemyBullet>().power = power;

                StartCoroutine(MoveArms());
                bulletCount--;
                
            }
            else if (bulletCount == 0)
                StartCoroutine(EnemyFlyingReloading());
            timestamp = Time.time + timeBetweenShots;
        }
        //}
        //catch { }

        if (transform.position.x > player.transform.position.x)
            GoLeft();
        else
            GoRight();

        //if (Input.GetKey(KeyCode.I))
        //    GoRight();
        //if (Input.GetKey(KeyCode.O))
        //    GoLeft();




    }

    private IEnumerator EnemyFlyingReloading()
    {
      
        GetComponentInChildren<Animator>().SetTrigger("reload");
        //Instantiate(shovel, shovelHole.transform.position, shovelHole.transform.rotation);
        yield return new WaitForSeconds(2.4f);
       // GetComponentInChildren<Animator>().ResetTrigger("reload");
        bulletCount = 11;
 
    }
    private IEnumerator checkDeath()
    {

        while (true)
        {
            if (health <= 0)
            {
                GetComponent<Rigidbody2D>().gravityScale = 5;
                GetComponent<enemyflyingcontroller>().enabled = false;
                GetComponentInChildren<EnemyFlyingAnimations>().death = true;
                GetComponentInChildren<EnemyFlyingJoint>().enabled = false;
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
    private IEnumerator MoveArms()
    {

        movementJoint1.transform.position = new Vector2(movementJoint1.transform.position.x + .1f, movementJoint1.transform.position.y);

        yield return new WaitForSeconds(.3f);
        movementJoint1.transform.position = new Vector2(movementJoint1.transform.position.x + -.1f, movementJoint1.transform.position.y);

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

    public void Damage(int amount)
    {
        health -= amount;
    }

}






