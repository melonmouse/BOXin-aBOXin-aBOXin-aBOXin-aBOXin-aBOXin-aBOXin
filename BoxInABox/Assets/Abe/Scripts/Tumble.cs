using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumble : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    void Update()
    {
        transform.eulerAngles += speed * direction * Time.deltaTime;
    }
}
