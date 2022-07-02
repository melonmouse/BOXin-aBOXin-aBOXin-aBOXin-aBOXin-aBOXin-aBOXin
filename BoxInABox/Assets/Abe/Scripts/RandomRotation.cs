using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public BoxAnim boxAnim;
    public RandomRotation childRandRotation;
    void Start()
    {
        SetRandomAngle();
    }

    void SetRandomAngle()
    {
        float angle = Random.value * 360;
        transform.eulerAngles = new Vector3(0, angle, 0);
        transform.GetComponent<Animator>();
        boxAnim.SetOpen(-0.1f);
    }

    void Update()
    {
        boxAnim.SetOpen(boxAnim.open + Time.deltaTime/10);
    }

    public void MoveAngleToParent()
    {
        if (transform.parent.GetComponent<RandomRotation>())
        {
            transform.parent.localEulerAngles = transform.localEulerAngles;
            transform.parent.GetComponent<RandomRotation>().boxAnim
                .SetOpen(boxAnim.open);
        }
        else
        {
            transform.parent.eulerAngles +=
                Vector3.up * transform.localEulerAngles.y;
        }

        if (childRandRotation == null)
        {
            SetRandomAngle();
        }
        else
        {
            childRandRotation.MoveAngleToParent();

            //transform.GetChild(1).GetComponent<Animator>()?.Play("box-open-anim");
            // Set animator to fixed state
        }
    }

}
