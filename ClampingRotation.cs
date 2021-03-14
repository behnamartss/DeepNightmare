using UnityEngine;
using System.Collections;

public class ClampingRotation : MonoBehaviour
{
    public float zSpeed = 250.0f;

    public float zMinLimit = -80f;
    public float zMaxLimit = 80f;

    private float x = 0.0f;
    private float y = 0.0f;
    private float z = 0;

    void Start()
    {
        x = transform.eulerAngles.x;
        y = transform.eulerAngles.y;
        z = transform.eulerAngles.z;
    }

    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            z += zSpeed * Time.deltaTime;
          
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            z -= zSpeed * Time.deltaTime;
        }

        z = ClampAngle(z, zMinLimit, zMaxLimit);

        Quaternion newRot = Quaternion.Euler(x, y, z);

        transform.rotation = newRot;
    }

    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}