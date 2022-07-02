using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InifiniteCamera : MonoBehaviour
{
    public float speed;
    public float wrap_from;
    public float wrap_to;
    public RandomRotation rotationManager;
    public bool wrapBack;
    void Update()
    {
        float height = transform.position.y;
        height *= Mathf.Pow(speed, Time.deltaTime);
        if (wrapBack)
        {
            for (int i = 0; i < 10; i++)
            {
                if (height > wrap_from)
                    break;
                height += wrap_to - wrap_from;
                rotationManager.MoveAngleToParent();
            }
        }
        transform.Translate(new Vector3(0, height - transform.position.y, 0));

    }
}
