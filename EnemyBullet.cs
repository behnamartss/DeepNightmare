using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    public float power;
    Vector3 prePosition;
    Transform firstPoint;
    // Use this for initialization
    void Start () {
        StartCoroutine(die());
        GetComponent<Rigidbody2D>().velocity=transform.rotation * Vector2.up * 50;
        prePosition = transform.position;
        firstPoint = transform;
    }

    private IEnumerator die()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate () {
        prePosition = transform.position;
        int mask = (1 << 9 ) | (1 << 10);

        RaycastHit2D hits = Physics2D.Raycast(prePosition, transform.rotation * Vector2.up * 50, 50,mask);
        if (hits.collider == false || hits.collider.tag=="cover" )
            Destroy(gameObject);
        else if (hits.collider.gameObject.tag == "Player")
        {
            hits.collider.SendMessageUpwards("Damage", power, SendMessageOptions.DontRequireReceiver);
          //  Debug.Log("khord be" + hits.transform.name);
            Destroy(gameObject);
        }
     
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.GetComponent<Transform>().tag=="Player")
        {

            col.gameObject.GetComponent<PlayerController>().SendMessage("Damage", power);
        }

        if (col.collider.gameObject.GetComponent<Transform>().tag != "Enemy")
            Destroy(gameObject);

    }
}
