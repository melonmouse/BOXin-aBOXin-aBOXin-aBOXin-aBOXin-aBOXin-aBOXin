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

    public void MoveAngleToParent()
    {
        float residualAngle = 0;
        if (!transform.parent.GetComponent<RandomRotation>())
        {
            residualAngle = transform.localEulerAngles.y;
            transform.parent.eulerAngles += Vector3.up * residualAngle;
        }
        else
        {
            transform.parent.localEulerAngles = transform.localEulerAngles;
        }

        if (transform.childCount == 0)
        {
            SetRandomAngle();
        }
        else
        {
            transform.GetChild(0).GetComponent<RandomRotation>().MoveAngleToParent();
        }

        
    }

}
