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

    public float windFriction;
    public float windSpeed;
    public float windAdditions;
    public float windAngle;
    public float windAngleAdditions;
    // TODO add particles
    // TODO consider adding wind angle speed
    // TODO switch to some noise function for wind angle and speed

    void Update()
    {
        Vector2 input = Inputs.Direction();
        Vector3 force = new Vector3(input.x, 0, input.y);
        if (speed.magnitude < smallSpeedTreshold)
        {
            force *= smallSpeedForceFactor;
        }

        speed *= Mathf.Pow(friction, Time.deltaTime);

        windSpeed += Random.Range(0f, 1f)* windAdditions * Time.deltaTime;
        windSpeed *= Mathf.Pow(windFriction, Time.deltaTime);
        windAngle += Random.Range(-1f, 1f)*windAngleAdditions*Time.deltaTime;
        windAngle %= 360;

        Vector3 windForce = windSpeed * new Vector3(
            Mathf.Cos(windAngle * Mathf.Deg2Rad),
            0,
            Mathf.Sin(windAngle * Mathf.Deg2Rad)
        );

        force += windForce;
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
