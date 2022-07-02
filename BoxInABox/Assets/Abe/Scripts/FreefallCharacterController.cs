using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreefallCharacterController : MonoBehaviour
{
    Vector3 speed = Vector2.zero;
    public float friction;
    public float forceFactor;
    void Update()
    {
        Vector2 input = Inputs.Direction();
        Vector3 force = new Vector3(input.x, 0, input.y);
        speed += force * Time.deltaTime * forceFactor;
        speed *= Mathf.Pow(friction, Time.deltaTime);
        transform.Translate(speed * Time.deltaTime);
    }
}
