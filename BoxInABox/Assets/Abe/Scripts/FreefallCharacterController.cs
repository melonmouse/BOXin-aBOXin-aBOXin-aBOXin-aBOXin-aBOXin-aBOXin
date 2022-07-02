using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreefallCharacterController : MonoBehaviour
{
    Vector3 speed = Vector2.zero;
    public float friction;
    public float forceFactor;
    public float smallSpeedForceFactor;
    public float smallSpeedTreshold;
    public float correctingForceFactor;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    void Update()
    {
        Vector2 input = Inputs.Direction();
        Vector3 force = new Vector3(input.x, 0, input.y);
        if (speed.magnitude < smallSpeedTreshold)
        {
            force *= smallSpeedForceFactor;
        }
        force += BoundingForce();
        speed += force * Time.deltaTime * forceFactor;
        speed *= Mathf.Pow(friction, Time.deltaTime);
        transform.Translate(speed * Time.deltaTime);
    }

    Vector3 BoundingForce()
    {
        Vector3 correctingForce = new Vector3();
        if (transform.position.x < minX)
        {
            float error = minX - transform.position.x;
            correctingForce += error * Vector3.right;
        }
        if (transform.position.x > maxX)
        {
            float error = maxX - transform.position.x;
            correctingForce += error * Vector3.right;
        }
        if (transform.position.z < minZ)
        {
            float error = minZ - transform.position.z;
            correctingForce += error * Vector3.forward;
        }
        if (transform.position.z > maxZ)
        {
            float error = maxZ - transform.position.z;
            correctingForce += error * Vector3.forward;
        }
        return correctingForce * correctingForceFactor;
    }
}
