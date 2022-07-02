using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    void Start()
    {
        SetRandomAngle();
    }

    void SetRandomAngle()
    {
        float angle = Random.value * 360;
        transform.eulerAngles = new Vector3(0, angle, 0);
    }

}
