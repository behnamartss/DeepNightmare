using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
   

    public GameObject player;       //Public variable to store a reference to the player game object
    [SerializeField]
    float lowestX;
    [SerializeField]
    float HighestX;
    [SerializeField]
    float lowestStopX;
    [SerializeField]
    float highestStopX;
    [SerializeField]
    bool enableY;
   public bool rightToLeft;
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {

        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;

    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        //  transform.position = player.transform.position + offset;
        if (transform.name == "Main Camera")
        {
            if (enableY == false)
            {

                if (transform.position.x > lowestX & transform.position.x < HighestX)
                    transform.position = new Vector3(player.transform.position.x + offset.x, transform.position.y, transform.position.z);
                if (transform.position.x < lowestX)
                    transform.position = new Vector3(lowestStopX, transform.position.y, transform.position.z);
                if (transform.position.x > HighestX)
                    transform.position = new Vector3(highestStopX, transform.position.y, transform.position.z);





            }
            else
            {


                if (transform.position.x > lowestX & transform.position.x < HighestX)
                    transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y+offset.y+.35f , transform.position.z);
                   // transform.position = player.transform.position+offset;
                if (transform.position.x < lowestX)
                    transform.position = new Vector3(lowestStopX, transform.position.y, transform.position.z);
                if (transform.position.x > HighestX)
                    transform.position = new Vector3(highestStopX, transform.position.y, transform.position.z);



            }



        }
        else
            if (transform.name == "scootCamera" & gameObject.activeInHierarchy)
            transform.position = player.transform.position + offset;

    }

}