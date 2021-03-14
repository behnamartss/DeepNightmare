using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
    [SerializeField]
    GameObject[] enemies;
    [SerializeField]
    Transform spawnplace;
    [SerializeField]
    bool walkable = false;
    [SerializeField]
    float scaleX;
    [SerializeField]
    float scaleY;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            foreach (GameObject enemy in enemies)
            { 
               var newEnemy = Instantiate(enemy, spawnplace.position, enemy.transform.rotation);
                newEnemy.transform.localScale = new Vector3(scaleX, scaleY, 1);
                try
                {
                    if (walkable)
                        newEnemy.GetComponent<enemy1controller>().walkMode = true;
                }
                catch
                {

                }
            }
            Destroy(gameObject);
        }
    }
}
